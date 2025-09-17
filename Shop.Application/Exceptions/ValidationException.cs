namespace Shop.Application.Exceptions
{
    public class ValidationException : ApplicationException
    {
        public List<string> Errors { get; set; } = new();

        public ValidationException(FluentValidation.Results.ValidationResult validationResult)
        {
            validationResult.Errors.ForEach(err => Errors.Add(err.ErrorMessage));
        }
    }
}
