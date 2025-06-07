using accountingwebapi.Dtos.Company;
using accountingwebapi.Dtos.Customer;
using accountingwebapi.Dtos.Result;
using accountingwebapi.Dtos.SearchParam;
using accountingwebapi.Extensions;
using accountingwebapi.Interfaces.Repositories;
using accountingwebapi.Interfaces.Services;
using accountingwebapi.Models.App;
using Microsoft.EntityFrameworkCore;

namespace accountingwebapi.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CustomerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<PaginatedResult<GetCustomerOutput>>> GetAll(GetCustomerInput input)
        {
            var query = _unitOfWork.CustomerRepository.GetQueryable()
                .Include(e => e.CustomerContactDetails)
                .Include(e => e.AffiliatedCompanies)
                .WhereIf(string.IsNullOrWhiteSpace(input.FilterText),
                e => false || e.FirstName.ToLower().Contains(input.FilterText) || e.LastName.ToLower().Contains(input.FilterText)
                || e.CustomerContactDetails.Select(e => e.Details).Contains(input.FilterText)
                || e.AffiliatedCompanies.Select(e => e.Name).Contains(input.FilterText)
                ).Select(e => new GetCustomerOutput
                {
                    Id = e.Id,
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    AffiliatedCompanies = e.AffiliatedCompanies.Select(e => e.Name).ToList(),
                    ContactDetails = e.CustomerContactDetails.Select(e => e.Details).ToList(),
                });

            if (await query.AnyAsync())
            {
                return Result<PaginatedResult<GetCustomerOutput>>.Success(new
                PaginatedResult<GetCustomerOutput>(new List<GetCustomerOutput>(), 0, input.PageNumber, input.PageSize));
            }
            //.WhereIf(string.IsNullOrWhiteSpace(input),)
            //.WhereIf(string.IsNullOrWhiteSpace(input),)
            //.WhereIf(string.IsNullOrWhiteSpace(input),)
            //.WhereIf(string.IsNullOrWhiteSpace(input),)
            //.WhereIf(string.IsNullOrWhiteSpace(input),)

            var result = await query.OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .ToPaginatedResult(input.PageNumber, input.PageSize)
                .ToListAsync();

            var count = await query.CountAsync();

            return Result<PaginatedResult<GetCustomerOutput>>.Success(new
                PaginatedResult<GetCustomerOutput>(result, count, input.PageNumber, input.PageSize));
        }

        public async Task<Result<Ulid>> CreateOrEdit(CreateOrEditCustomerDto input)
        {
            if (input.Id is null)
            {
                return await Create(input);
            }

            return await Edit(input);
        }

        private async Task<Result<Ulid>> Create(CreateOrEditCustomerDto input)
        {
            try
            {
                if (!input.ContactDetails.Any())
                {
                    return Result<Ulid>.Failure(Errors.Errors.Validation.RequiredField("Contact Details", "Customer.Create"));
                }

                Customer customer = new Customer
                {
                    Id = Ulid.NewUlid(),
                    FirstName = input.FirstName,
                    LastName = input.LastName,
                };

                List<CustomerContactDetail> customerContactDetails = new List<CustomerContactDetail>();
                foreach (var contact in input.ContactDetails)
                {
                    CustomerContactDetail customerContactdetail = new CustomerContactDetail
                    {
                        Details = contact.Details,
                        CustomerId = customer.Id,
                        Type = contact.Type,
                    };

                    customerContactDetails.Add(customerContactdetail);
                }

                List<Company> companies = new List<Company>();

                if (input.CompanyIds.Any())
                {
                     companies = await _unitOfWork.Company.GetQueryable()
                        .Where(e => input.CompanyIds.Contains(e.Id)).ToListAsync();

                }

                customer.AffiliatedCompanies = companies;
                customer.CustomerContactDetails = customerContactDetails;

                await _unitOfWork.CustomerRepository.AddAsync(customer);
                await _unitOfWork.CompleteAsync();

                return Result<Ulid>.Success(customer.Id);
            }
            catch (Exception ex)
            {

                return Result<Ulid>.Failure(Errors.Errors.Generic.GenericError("Customer.Create", ex.Message));
            }
        }

        private async Task<Result<Ulid>> Edit(CreateOrEditCustomerDto input)
        {
            return Result<Ulid>.Failure(Errors.Errors.UninmplementedFunction);
        }
    }
}
