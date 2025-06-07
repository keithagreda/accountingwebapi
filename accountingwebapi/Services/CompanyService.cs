using accountingwebapi.Dtos.Company;
using accountingwebapi.Dtos.Result;
using accountingwebapi.Dtos.SearchParam;
using accountingwebapi.Extensions;
using accountingwebapi.Interfaces.Repositories;
using accountingwebapi.Interfaces.Services;
using accountingwebapi.Models.App;
using Microsoft.EntityFrameworkCore;

namespace accountingwebapi.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CompanyService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<Ulid>> CreateOrEdit(CreateOrEditCompanyDto input)
        {
            if (input.Id == null)
            {
                return await Create(input);
            }

            return await Edit(input);
        }

        public async Task<Result<PaginatedResult<CompanyDto>>> GetAll(GetCompanyInput input)
        {
            var query = _unitOfWork.Company.GetQueryable()
                .WhereIf(!string.IsNullOrWhiteSpace(input.FilterText), e => e.Name.Contains(input.FilterText))
                .Select(e => new CompanyDto
                {
                    Id = e.Id,
                    Name = e.Name,
                });

            if (!await query.AnyAsync())
            {
                return Result<PaginatedResult<CompanyDto>>
                    .Success(new PaginatedResult<CompanyDto>(new List<CompanyDto>(), 0, input.PageNumber, input.PageSize));
            }

            var sorted = query.OrderByDescending(e => e.Id)
                .ToPaginatedResult(input.PageNumber, input.PageSize);

            var list = await sorted.ToListAsync();
            var count = await query.CountAsync();

            return Result<PaginatedResult<CompanyDto>>.Success(
                new PaginatedResult<CompanyDto>(list, count, input.PageNumber, input.PageSize)
                );
        }

        private async Task<Result<Ulid>> Create(CreateOrEditCompanyDto input)
        {
            try
            {
                Company company = new Company
                {
                    Id = Ulid.NewUlid(),
                    Name = input.Name
                };

                await _unitOfWork.Company.AddAsync(company);
                await _unitOfWork.CompleteAsync();
                return Result<Ulid>.Success(company.Id);

            }
            catch (Exception ex)
            {

                return Result<Ulid>.Failure(Errors.Errors.Generic.GenericError("Company.Create", ex.Message));
            }

        }

        private async Task<Result<Ulid>> Edit(CreateOrEditCompanyDto input)
        {
            return Result<Ulid>.Failure(Errors.Errors.UninmplementedFunction);
        }
    }
}
