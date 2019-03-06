namespace BookingSystem.Commands.Infrastructure.Validators
{
    public class ValidationResult
    {
        public bool IsSuccessful { get; set; }
    }

    public interface IValidator<T>
    {
        ValidationResult Validate(T instance);
    }
}
