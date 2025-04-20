using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Validations
{
    public class FileSizeValidator : ValidationAttribute
    {
        private readonly int _maxFileSize;
        public FileSizeValidator(int maxFileSize)
        {
            _maxFileSize = maxFileSize;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is IFormFile file)
            {
                if (file.Length > _maxFileSize)
                {
                    return new ValidationResult($"The file size cannot exceed {_maxFileSize / 1024} KB.");
                }
            }
            return ValidationResult.Success;
        }
    }
}
