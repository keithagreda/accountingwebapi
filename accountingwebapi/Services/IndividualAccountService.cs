using accountingwebapi.Dtos.IndividualAccount;
using accountingwebapi.Dtos.Result;
using accountingwebapi.Dtos.SearchParam;
using accountingwebapi.Errors;
using accountingwebapi.Extensions;
using accountingwebapi.Interfaces.Repositories;
using accountingwebapi.Interfaces.Services;
using accountingwebapi.Models.App;
using Microsoft.EntityFrameworkCore;

namespace accountingwebapi.Services
{
    public class IndividualAccountService : IIndividualAccountService
    {
        private readonly IUnitOfWork _unitOfWork;
        public IndividualAccountService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> CreateOrEdit(CreateOrEditIndividualAccount input)
        {
            Result<bool> existing = await CheckIfExisting(input);
            if (existing.Value)
                return Result.Failure(Errors.Errors.Validation.AlreadyExists("Individual Account"));
            if (input.Id is null)
            {
                return await Create(input);
            }
            return Result.Success();
        }

        public async Task<Result<PaginatedResult<IndividualAccountDto>>> GetAllIndividualAccount(GenericSearchParam input)
        {
            var query = _unitOfWork.IndividualAccount.GetQueryable()
                .Include(e => e.SubAccountFk)
                .WhereIf(!string.IsNullOrWhiteSpace(input.FilterText), e => e.Description.Contains(input.FilterText))
                .Select(e => new IndividualAccountDto
                {
                    Description = e.Description,
                    Id = e.Id,
                    SubAccountName = e.SubAccountFk.Name,
                });

            var paginated = await query.ToPaginatedResult(input.PageNumber, input.PageSize).ToListAsync();
            var count = await query.CountAsync();

            var res = new PaginatedResult<IndividualAccountDto>(paginated, count, (int)input.PageNumber, (int)input.PageSize);

            return Result<PaginatedResult<IndividualAccountDto>>.Success(res);
        }

        private async Task<Result> Create(CreateOrEditIndividualAccount input)
        {
            IndividualAccount individualAccount = new IndividualAccount()
            {
                SubAccountId = input.SubAccountId,
                Description = input.Description,
            };

            await _unitOfWork.IndividualAccount.AddAsync(individualAccount);
            return Result.Success();
        }

        private async Task<Result<bool>> CheckIfExisting(CreateOrEditIndividualAccount input)
        {
            return Result<bool>.Success(await _unitOfWork.IndividualAccount.GetQueryable()
                .WhereIf(input.Id is not null, e => e.Id != input.Id)
                .AnyAsync(e => e.Description == input.Description && e.SubAccountId == input.SubAccountId));
        }

        public async Task<Result> SeedIndividualAccount()
        {
            var subAccounts = _unitOfWork.SubAccount.GetQueryable();

            var listOfIndividualAccount = new List<IndividualAccount>
            {
                new IndividualAccount
                {
                    Description = "Purchase Order",
                    SubAccountId = subAccounts.FirstOrDefaultAsync(e => e.Name == "Current Assets").Result.Id,
                },
                new IndividualAccount
                {
                    Description = "Inventory",
                    SubAccountId = subAccounts.FirstOrDefaultAsync(e => e.Name == "Current Assets").Result.Id,
                },
                new IndividualAccount
                {
                    Description = "Bank",
                    SubAccountId = subAccounts.FirstOrDefaultAsync(e => e.Name == "Current Assets").Result.Id,
                },
                new IndividualAccount
                {
                    Description = "Equity",
                    SubAccountId = subAccounts.FirstOrDefaultAsync(e => e.Name == "Current Assets").Result.Id,
                },
                new IndividualAccount
                {
                    Description = "Sales",
                    SubAccountId = subAccounts.FirstOrDefaultAsync(e => e.Name == "Revenue").Result.Id,
                },

            };

            // Add to DB
            await _unitOfWork.IndividualAccount.AddRangeAsync(listOfIndividualAccount);
            await _unitOfWork.CompleteAsync();

            return Result.Success();
        }
    }
}
