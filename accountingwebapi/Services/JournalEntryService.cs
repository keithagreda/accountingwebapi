using accountingwebapi.Dtos.EntryTemplate;
using accountingwebapi.Dtos.EntryTemplateLine;
using accountingwebapi.Dtos.JournalEntry;
using accountingwebapi.Dtos.Result;
using accountingwebapi.Dtos.SearchParam;
using accountingwebapi.Extensions;
using accountingwebapi.Interfaces.Repositories;
using accountingwebapi.Interfaces.Services;
using accountingwebapi.Models.App;
using Microsoft.EntityFrameworkCore;

namespace accountingwebapi.Services
{
    public class JournalEntryService : IJournalEntryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAccountingPeriodService _accountingPeriodService;
        private readonly IEntryTemplateService _entryTemplateService;
        private readonly IEntryTemplateUsageStatsService _entryTemplateUsageStatsService;
        public JournalEntryService(IUnitOfWork unitOfWork, IAccountingPeriodService accountingPeriodService, IEntryTemplateService entryTemplateService, IEntryTemplateUsageStatsService entryTemplateUsageStatsService)
        {
            _unitOfWork = unitOfWork;
            _accountingPeriodService = accountingPeriodService;
            _entryTemplateService = entryTemplateService;
            _entryTemplateUsageStatsService = entryTemplateUsageStatsService;
        }

        public async Task<Result<PaginatedResult<JournalEntryDto>>> GetAll(GetJournalEntryInput input)
        {
            try
            {
                var lines = _unitOfWork.JournalEntryLine.GetQueryable()
                .Include(e => e.JournalEntryFk)
                .WhereIf(input.IndividualAccountId != null, e => e.IndividualAccountId == input.IndividualAccountId)
                .WhereIf(input.CompanyId != null, e => e.JournalEntryFk.CompanyId == input.CompanyId)
                .WhereIf(input.CustomerId != null, e => e.JournalEntryFk.CustomerId == input.CustomerId)
                .WhereIf(!string.IsNullOrWhiteSpace(input.FilterText), e => false || e.JournalEntryFk.Description.Contains(input.FilterText)
                )
                .GroupBy(e => e.JournalEntryFk)
                .Select(e => new JournalEntryDto
                {
                    Id = e.Key.Id,
                    Description = e.Key.Description,
                    AccountingPeriodId = e.Key.AccountingPeriodId,
                    AdjustsEntryId = e.Key.AdjustsEntryId,
                    CompanyId = e.Key.CompanyId,
                    CustomerId = e.Key.CustomerId,
                    IsAdjustment = e.Key.IsAdjustment,
                    IsVoided = e.Key.IsVoided,
                    TransactionDate = e.Key.TransactionDate,
                    VoidedBy = e.Key.VoidedBy,
                    VoidedOn = e.Key.VoidedOn,
                    VoidedReason = e.Key.VoidedReason,
                    Lines = e.Select(e => new JournalEntryLineDto
                    {
                        Amount = e.Amount,
                        Id = e.Id,
                        IsDebit = e.IsDebit,
                        JournalEntryId = e.JournalEntryId,
                        IndividualAccountDesc = e.IndividualAccountFk.Description,
                        Remarks = e.Remarks
                    }).ToList()
                })
                .OrderByDescending(e => e.Id)
                .ToPaginatedResult(input.PageNumber, input.PageSize);

                var count = await lines.CountAsync();
                var list = await lines.ToListAsync();

                return Result<PaginatedResult<JournalEntryDto>>
                   .Success(new PaginatedResult<JournalEntryDto>(list, count, input.PageNumber, input.PageSize));
            }
            catch (Exception ex)
            {

                return Result<PaginatedResult<JournalEntryDto>>.Failure(
                    Errors.Error.Custom($"JournalEntry.GetAll", $"Something went wrong... {ex.Message}")
                );
            }
        }

        public async Task<Result> CreateOrEdit(CreateOrEditJournalEntryDto input, Ulid? templateId)
        {
            if (!input.Lines.Any())
            {
                return Result.Failure(Errors.Errors.JournalEntryLine.IsEmpty);
            }
            if (templateId is null)
            {
                CreateOrEditEntryTemplateDto entryTemplate = new CreateOrEditEntryTemplateDto
                {
                    EntryType = input.Description,
                };

                List<CreateOrEditEntryTemplateLineDto> entryTemplateLines = new List<CreateOrEditEntryTemplateLineDto>();

                foreach(var line in input.Lines)
                {
                    CreateOrEditEntryTemplateLineDto res = new CreateOrEditEntryTemplateLineDto
                    {
                        AccountId = line.IndividualAccountId,
                        IsDebit = line.IsDebit,
                    };
                    entryTemplateLines.Add(res);
                }

                entryTemplate.EntryTemplateLineDtos = entryTemplateLines;

                var existingTemp = await _entryTemplateService.CheckIfExisting(entryTemplateLines);

                //means that template is still not existing 
                //and can still create template
                if (existingTemp.IsFailure)
                {
                    var tempId = await _entryTemplateService.CreateOrEdit(entryTemplate);
                    
                    ////set param templateId 
                    //templateId = tempId.Value;
                    ////after that add or create score for this template
                    //if (tempId.IsSuccess)
                    //{
                    //    //score
                    //    await _entryTemplateUsageStatsService.AddUsage(tempId.Value);
                    //}
                }
            }
            if (input.Id == null)
            {
                return await Create(input, (Ulid)templateId);
            }

            return await Edit(input, (Ulid)templateId);
        }

        private async Task<Result> Edit(CreateOrEditJournalEntryDto input, Ulid templateId)
        {
            return Result.Failure(Errors.Errors.UninmplementedFunction);
        }

        private async Task<Result> Create(CreateOrEditJournalEntryDto input, Ulid templateId)
        {
            

            var accountingPeriod = await _accountingPeriodService.GetCurrentOpenedAccountingPeriod();

            if (accountingPeriod.IsFailure)
            {
                return Result.Failure(Errors.Errors.AccountingPeriod.NoOpen);
            }

            //have to automatically get accounting period id
            var journalEntry = new JournalEntry
            {
                Id = Ulid.NewUlid(),
                AccountingPeriodId = accountingPeriod.Value.Id,
                Description = input.Description,
                CustomerId = input.CustomerId,
                CompanyId = input.CompanyId,
            };

            var lines = new List<JournalEntryLine>();
            foreach (var item in input.Lines)
            {
                var line = new JournalEntryLine
                {
                    Amount = item.Amount,
                    IsDebit = item.IsDebit,
                    IndividualAccountId = item.IndividualAccountId,
                    JournalEntryId = journalEntry.Id,
                    Remarks = item.Remarks,
                };
                lines.Add(line);
            }

            await _unitOfWork.JournalEntry.AddAsync(journalEntry);
            await _unitOfWork.JournalEntryLine.AddRangeAsync(lines);

            //addscore 
            await _entryTemplateUsageStatsService.AddUsage(templateId);

            await _unitOfWork.CompleteAsync();
            return Result.Success();
        }
    }
}
