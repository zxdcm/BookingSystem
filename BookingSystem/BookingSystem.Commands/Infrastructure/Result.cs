using System.Collections.Generic;
using BookingSystem.Commands.Properties;

namespace BookingSystem.Commands.Infrastructure
{

    public class Result<T>
    {
        public T Value { get; }
        public bool IsSuccessful { get;  }
        public string ErrorMessage { get; }
        public IEnumerable<string> Errors { get; }

        public Result(T value,
            bool isSuccessful, 
            string errorMessage, 
            IEnumerable<string> errors)
        {
            Value = value;
            IsSuccessful = isSuccessful;
            ErrorMessage = errorMessage;
            Errors = errors;
        }

        public static Result<T> Ok(T value) 
            => new Result<T>(value, true, null, null);
    }



    public class Result : Result<int?>
    {
        private Result(int? value, bool isSuccessful, string errorMessage)
            : base(value, isSuccessful, errorMessage, null)
        { }


        private Result(string errorMessage)
            : base(null, false, errorMessage, null)
        { }


        private Result(int? value, string errorMessage, IEnumerable<string> errors)
            : base(value, false, errorMessage, errors)
        { }

        public static Result Ok()
            => new Result(null, true, null);

        public static Result Ok(int id) 
            => new Result(id, true, null);

        public static Result Error(string errorMessage)
            => new Result(errorMessage);

        public static Result NullEntityError(string entityType, int id)
            => new Result(id, string.Format(ErrorsResources.NullEntityResult, entityType, id), null);
    }
}
