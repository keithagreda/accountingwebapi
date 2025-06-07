using accountingwebapi.Dtos.Result;
using accountingwebapi.Dtos.SubAccount;
using accountingwebapi.Interfaces.Repositories;
using accountingwebapi.Interfaces.Services;
using accountingwebapi.Models.App;
using Microsoft.EntityFrameworkCore;


namespace accountingwebapi.Services
{
    public class SubAccountService : ISubAccountService
    {
        private readonly IUnitOfWork _unitOfWork;
        public SubAccountService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> CreateOrEdit(CreateOrEditSubAccountDto input)
        {
            if (input.Id is null)
            {
                //create
                return await Create(input);
            }

            //edit
            return Result.Success();
        }

        public async Task<Result<List<GetSubAccountForViewDto>>> GetAll()
        {
            var subAccount = await _unitOfWork.SubAccount.GetQueryable().Select(e => new GetSubAccountForViewDto
            {
                Id = e.Id,
                AccountCategory = e.AccountCateg.ToString(),
                CreatedBy = "",
                CreationTime = e.CreationTime,
                Name = e.Name
            }).ToListAsync();
            return Result<List<GetSubAccountForViewDto>>.Success(subAccount);
        }

        private async Task<Result> Create(CreateOrEditSubAccountDto input)
        {
            if (string.IsNullOrWhiteSpace(input.Name))
                return Result.Failure(Errors.Errors.Validation.RequiredField("Sub Account Name", "SubAccount.Create"));

            SubAccount subAccount = new SubAccount
            {
                AccountCateg = input.AccountCateg,
                Name = input.Name,
            };

            await _unitOfWork.SubAccount.AddAsync(subAccount);
            await _unitOfWork.CompleteAsync();
            await _unitOfWork.DisposeAsync();
            return Result.Success();
        }

        public async Task<Result> SeedSubAccount()
        {
            var listOfSubAccounts = new List<SubAccount>
            {
                new SubAccount
                {
                    Name = "Current Assets",
                    AccountCateg = Enum.AccountCategory.Assets
                },
                new SubAccount
                {
                    Name = "Fixed Assets",
                    AccountCateg = Enum.AccountCategory.Assets
                },
                new SubAccount
                {
                    Name = "Current Liabilities",
                    AccountCateg = Enum.AccountCategory.Liabilities
                },
                new SubAccount
                {
                    Name = "Fixed Liabilities",
                    AccountCateg = Enum.AccountCategory.Liabilities
                },
                new SubAccount
                {
                    Name = "Equity",
                    AccountCateg = Enum.AccountCategory.Equity
                },
                new SubAccount
                {
                    Name = "Expenses",
                    AccountCateg = Enum.AccountCategory.Expenses
                },
                new SubAccount
                {
                    Name = "Revenue",
                    AccountCateg = Enum.AccountCategory.Revenue
                },
                new SubAccount
                {
                    Name = "Contra Revenue",
                    AccountCateg = Enum.AccountCategory.Revenue
                }
            };

                    // Add to DB
            await _unitOfWork.SubAccount.AddRangeAsync(listOfSubAccounts);
            await _unitOfWork.CompleteAsync();

            return Result.Success();
        }
    }
}
