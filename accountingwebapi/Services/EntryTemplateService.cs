using accountingwebapi.Dtos.EntryTemplate;
using accountingwebapi.Dtos.EntryTemplateLine;
using accountingwebapi.Dtos.Result;
using accountingwebapi.Dtos.SearchParam;
using accountingwebapi.Extensions;
using accountingwebapi.Interfaces.Repositories;
using accountingwebapi.Interfaces.Services;
using accountingwebapi.Migrations;
using accountingwebapi.Models.App;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace accountingwebapi.Services
{
    public class EntryTemplateService : IEntryTemplateService
    {
        private readonly IUnitOfWork _unitOfWork;
        public EntryTemplateService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<PaginatedResult<GetEntryTemplateDto>>> GetAll(GetEntryTemplateInputDto input)
        {
            var query = _unitOfWork.EntryTemplate.GetQueryable()
                .WhereIf(!string.IsNullOrWhiteSpace(input.FilterText), e => false || e.EntryType.ToLower().Replace(" ", "").Contains(input.FilterText));
            //.Select(e => new GetEntryTemplateDto
            //{
            //    EntryType = e.EntryType,
            //    Id = e.Id
            //});

            var score = _unitOfWork.EntryTemplateUsageStats.GetQueryable();
            var line = _unitOfWork.EntryTemplateLine.GetQueryable();

            var join = from t in query
                       join s in score on t.Id equals s.EntryTemplateId into sGrouped
                       from s in sGrouped.DefaultIfEmpty()
                       join l in line on s.Id equals l.TemplateId into lGrouped
                       select new
                       {
                           Template = t,
                           Score = s,
                           Lines = lGrouped
                       } into temp
                       group temp by temp.Template.Id into g
                       select new GetEntryTemplateDto
                       {
                           Id = g.Key,
                           EntryType = g.First().Template.EntryType,
                           Score = g.First().Score != null ? g.First().Score.UsageCount : 0,
                           GetEntryTemplateLineDtos = g.SelectMany(x => x.Lines)
                                                       .Select(l => new GetEntryTemplateLineDto
                                                       {
                                                           AccountId = l.AccountId,
                                                           Id = l.Id,
                                                           IsDebit = l.IsDebit,
                                                       }).ToList()
                       };

            var sortedAndPaged = join
                .OrderByDescending(e => e.Score)
                .ToPaginatedResult(input.PageNumber, input.PageSize);

            var count = await join.CountAsync();
            var list = await sortedAndPaged.ToListAsync();

            if (await join.AnyAsync())
            {
                return Result<PaginatedResult<GetEntryTemplateDto>>.Success(new PaginatedResult<GetEntryTemplateDto>(
                    new List<GetEntryTemplateDto>(), 0, input.PageNumber, input.PageSize));
            }

            return Result<PaginatedResult<GetEntryTemplateDto>>.Success(new PaginatedResult<GetEntryTemplateDto>(list, count, input.PageNumber, input.PageSize));
        }

        public async Task<Result<Ulid>> CreateOrEdit(CreateOrEditEntryTemplateDto input)
        {
            if (input.Id is null)
            {
                return await Create(input);
            }
            return await Edit(input);
        }

        public async Task<Result<Ulid>> CheckIfExisting(List<CreateOrEditEntryTemplateLineDto> lines)
        {
            var query = _unitOfWork.EntryTemplate.GetQueryable();
            var score = _unitOfWork.EntryTemplateUsageStats.GetQueryable();
            var line = _unitOfWork.EntryTemplateLine.GetQueryable();

            var join = from t in query
                       join s in score on t.Id equals s.EntryTemplateId into sGrouped
                       from s in sGrouped.DefaultIfEmpty()
                       join l in line on t.Id equals l.TemplateId into lGrouped // fix join: line is tied to template
                       select new
                       {
                           Template = t,
                           Score = s,
                           Lines = lGrouped
                       } into temp
                       group temp by temp.Template.Id into g
                       select new GetEntryTemplateDto
                       {
                           Id = g.Key,
                           EntryType = g.First().Template.EntryType,
                           Score = g.First().Score != null ? g.First().Score.UsageCount : 0,
                           GetEntryTemplateLineDtos = g.SelectMany(x => x.Lines)
                                                       .Select(l => new GetEntryTemplateLineDto
                                                       {
                                                           AccountId = l.AccountId,
                                                           Id = l.Id,
                                                           IsDebit = l.IsDebit,
                                                       }).ToList()
                       };

            // Normalize the input lines (sort by AccountId and IsDebit for consistent matching)
            var inputNormalized = lines
                .OrderBy(x => x.AccountId)
                .ThenBy(x => x.IsDebit)
                .Select(x => new { x.AccountId, x.IsDebit })
                .ToList();

            foreach (var template in await join.ToListAsync())
            {
                var templateNormalized = template.GetEntryTemplateLineDtos
                    .OrderBy(x => x.AccountId)
                    .ThenBy(x => x.IsDebit)
                    .Select(x => new { x.AccountId, x.IsDebit })
                    .ToList();

                // Compare using sequence equality
                if (inputNormalized.SequenceEqual(templateNormalized))
                {
                    return Result<Ulid>.Success(template.Id);
                }
            }

            return Result<Ulid>.Failure(Errors.Errors.EntryTemplate.DoesNotExist); // Or return null/empty ID if nothing matches
        }

        private async Task<Result<Ulid>> Create(CreateOrEditEntryTemplateDto input)
        {
            try
            {
                if (!input.EntryTemplateLineDtos.Any())
                {
                    return Result<Ulid>.Failure(Errors.Errors.Validation.RequiredField("EntryTemplateLines", "EntryTemplate.Create"));
                }

                EntryTemplate entryTemplate = new EntryTemplate
                {
                    Id = Ulid.NewUlid(),
                    EntryType = input.EntryType,
                };

                List<EntryTemplateLine> entryTemplateLines = new List<EntryTemplateLine>();
                foreach (var tempLine in input.EntryTemplateLineDtos)
                {
                    EntryTemplateLine entryTemplateLine = new EntryTemplateLine
                    {
                        AccountId = tempLine.AccountId,
                        IsDebit = tempLine.IsDebit,
                        TemplateId = entryTemplate.Id,
                    };

                    entryTemplateLines.Add(entryTemplateLine);
                }

                await _unitOfWork.EntryTemplate.AddAsync(entryTemplate);
                await _unitOfWork.EntryTemplateLine.AddRangeAsync(entryTemplateLines);

                await _unitOfWork.CompleteAsync();
                return Result<Ulid>.Success(entryTemplate.Id);
            }
            catch (Exception ex)
            {

                return Result<Ulid>.Failure(Errors.Errors.Generic.GenericError("EntryTemplate.Create", ex.Message));
            }
        }

        private async Task<Result<Ulid>> Edit(CreateOrEditEntryTemplateDto input)
        {
            return Result<Ulid>.Failure(Errors.Errors.UninmplementedFunction);
        }

    }
}
