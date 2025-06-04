using accountingwebapi.Dtos.IndividualAccount;
using accountingwebapi.Dtos.Result;
using accountingwebapi.Errors;
using accountingwebapi.Extensions;
using accountingwebapi.Interfaces.Repositories;
using accountingwebapi.Models.App;
using Microsoft.EntityFrameworkCore;

namespace accountingwebapi.Services
{
    public class IndividualAccountService
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
        }

        private async Task<Result> Create(CreateOrEditIndividualAccount input)
        {
            IndividualAccount individualAccount = new IndividualAccount()
            {
                SubAccountId = input.SubAccountId,
                Description = input.Description,
            };

            await _unitOfWork.IndividualAccount.AddAsync(individualAccount);
        }

        private async Task<Result<bool>> CheckIfExisting(CreateOrEditIndividualAccount input)
        {
            return Result<bool>.Success(await _unitOfWork.IndividualAccount.GetQueryable()
                .WhereIf(input.Id is not null, e => e.Id != input.Id)
                .AnyAsync(e => e.Description == input.Description && e.SubAccountId == input.SubAccountId));
        }
    }
}
