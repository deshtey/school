namespace schoolapp.Application.Common.Models
{
    public class Result<T>
    {
        public bool IsSuccess { get; }
        public T Value { get; }
        public IEnumerable<string> Errors { get; }

        protected Result(bool isSuccess, T value, IEnumerable<string> errors)
        {
            IsSuccess = isSuccess;
            Value = value;
            Errors = errors;
        }

        public static Result<T> Success(T value) =>
            new(true, value, Enumerable.Empty<string>());

        public static Result<T> Failure(IEnumerable<string> errors) =>
            new Result<T>(false, default, errors);
    }
}

