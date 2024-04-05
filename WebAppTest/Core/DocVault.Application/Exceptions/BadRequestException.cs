using FluentValidation.Results;

namespace DocVault.Application.Exceptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException(string message) : base(message)
        {

        }

        public BadRequestException(string message, Exception ex) : base(message)
        {
            Detail = ex.InnerException.ToString();
        }

        public BadRequestException(string message, ValidationResult validationResult) : base(message)
        {
            ValidationError = validationResult.ToDictionary();
        }

        public String Detail { get; set; }

        public IDictionary<string, string[]> ValidationError { get; set; }
    }
}
