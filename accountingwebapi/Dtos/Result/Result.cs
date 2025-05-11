using accountingwebapi.Errors;

namespace accountingwebapi.Dtos.Result
{
    public class Result
    {
        public bool IsSuccess { get; }
        public Error Error { get; }

        public bool IsFailure => !IsSuccess;

        protected Result(bool isSuccess, Error error)
        {
            if (isSuccess && error != null)
                throw new InvalidOperationException("Successful result must not have an error.");

            if (!isSuccess && error == null)
                throw new InvalidOperationException("Failed result must have an error.");

            IsSuccess = isSuccess;
            Error = error;
        }

        public static Result Success() => new Result(true, null);

        public static Result Failure(Error error) => new Result(false, error);
    }

    public class Result<T> : Result
    {
        public T Value { get; }

        private Result(T value, bool isSuccess, Error error)
            : base(isSuccess, error)
        {
            Value = value;
        }

        public static Result<T> Success(T value) => new Result<T>(value, true, null);

        public static new Result<T> Failure(Error error) => new Result<T>(default, false, error);
    }
}
