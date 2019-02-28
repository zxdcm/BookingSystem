namespace BookingSystem.Commands.Infrastructure
{
    public class Result<T>
    {
        public T Value { get; set; } 
        public bool IsSuccessful { get; set; }
        public string ErrorMessage { get; set; }

        public Result() { }
        public Result(T value, bool isSuccessful, string errorMessage)
        {
            Value = value;
            IsSuccessful = isSuccessful;
            ErrorMessage = errorMessage;
        }

        public static Result<T> Ok(T value) => new Result<T>(value, true, null);
       
    }

    public class Result : Result<string>
    {
        private Result(bool isSuccessful, string errorMessage)
            : base(null, isSuccessful, errorMessage)
        {
        }

        public static Result Ok() => new Result(true, null);

        public static Result Error(string errorMessage) => new Result(false, errorMessage);
    }

}
