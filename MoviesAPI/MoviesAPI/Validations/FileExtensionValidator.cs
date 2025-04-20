using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Validations
{
    public class FileExtensionValidator : ValidationAttribute
    {
        private readonly string[] _validExtensions;
        public FileExtensionValidator(string[] validExtensions)
        {
            _validExtensions = validExtensions;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is IFormFile file)
            {
                var fileExtension = Path.GetExtension(file.FileName);
                if (!_validExtensions.Contains(fileExtension.ToLower()))
                {
                    return new ValidationResult($"The file extension is not valid. Valid extensions are: {string.Join(", ", _validExtensions)}");
                }
            }
            return ValidationResult.Success;
        }
    }
}
