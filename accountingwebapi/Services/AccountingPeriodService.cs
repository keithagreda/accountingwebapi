using accountingwebapi.Dtos.AccountingPeriod;
using accountingwebapi.Dtos.Result;
using accountingwebapi.Errors;
using accountingwebapi.Interfaces.Repositories;
using accountingwebapi.Interfaces.Services;
using accountingwebapi.Models.App;
using Microsoft.EntityFrameworkCore;

namespace accountingwebapi.Services
{
    public class AccountingPeriodService : IAccountingPeriodService
    {
        private readonly IUnitOfWork _unitOfWork;
        public AccountingPeriodService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        ///Purpose of this function is to keep the accounting period cycle open
        ///An accounting period can only happen once each period
        ///returns id on success
        public async Task<Result<int>> AccountingPeriodHandler()
        {
            var utcNow = DateTimeOffset.UtcNow;

            var manilaTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Asia/Manila");
            var manilaTime = TimeZoneInfo.ConvertTime(utcNow, manilaTimeZone);

            //ONE MONTH
            const int PERIODNUMBEROFDAYS = 30;

            var currentOpened = await GetCurrentOpenedAccountingPeriod();

            if (currentOpened.IsFailure)
            {
                //create new accounting period
                var create = await Create(PERIODNUMBEROFDAYS);

                if (create.IsFailure)
                {
                    return Result<int>.Failure(create.Error);
                }

                return create;
            }

            //if sobra na sa end date close current then create new
            if (currentOpened.Value.EndDate <= manilaTime)
            {
                return Result<int>.Failure(Errors.Errors.AccountingPeriod.ReachedEndDate);
            }

            return Result<int>.Success(currentOpened.Value.Id);

            //check if theres an open accounting period

            //if theres no open accounting period create new

            //if theres an open accounting period check if it should close
            //if it should be closed update its status
            //if its still not within closing period get id and return

        }
        /// <summary>
        /// A function that creates accounting period
        /// </summary>
        /// <param name="periodNumOfDays"></param>
        /// <returns></returns>
        private async Task<Result<int>> Create(int periodNumOfDays)
        {
            try
            {
                AccountingPeriod accountingPeriod = new AccountingPeriod
                {
                    EndDate = DateTimeOffset.UtcNow.AddDays(periodNumOfDays),
                };

                return Result<int>.Success(await _unitOfWork.AccountingPeriod.InsertAndGetIdAsync(accountingPeriod));
            }
            catch (Exception ex)
            {

                return Result<int>.Failure(Errors.Errors.Generic.GenericError("AccountingPeriod.Create", ex.Message));
            }
        }
        /// <summary>
        /// Purpose of this to get currently opened accounting period
        /// </summary>
        /// <returns>accountingperiodid int</returns>
        public async Task<Result<AccountingPeriodDto>> GetCurrentOpenedAccountingPeriod()
        {
            var context = await _unitOfWork.AccountingPeriod.GetQueryable().Where(e => e.IsClosed == false)
                .Select(e => new AccountingPeriodDto
                {
                    ClosedBy = e.ClosedBy,
                    ClosedOn = e.ClosedOn,
                    EndDate = e.EndDate,
                    Id = e.Id,
                    IsClosed = e.IsClosed
                }).FirstOrDefaultAsync();

            if (context is null)
            {
                return Result<AccountingPeriodDto>.Failure(Errors.Errors.AccountingPeriod.NoOpen);
            }
            return Result<AccountingPeriodDto>.Success(context);
        }

        public async Task<Result> CloseCurrentAccountingPeriod()
        {
            var context = await _unitOfWork.AccountingPeriod.FirstOrDefaultAsync(e => e.IsClosed == false);

            if (context is null) return Result.Failure(Errors.Errors.AccountingPeriod.NoOpen);

            context.IsClosed = true;
            context.ClosedOn = DateTimeOffset.UtcNow;

            await _unitOfWork.CompleteAsync();
            return Result.Success();
        }
    }
}
