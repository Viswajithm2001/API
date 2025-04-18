using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Validations
{
    public class FirstLetterUpperCaseAttribute: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if(value == null|| string.IsNullOrEmpty(value.ToString()))
            {
                return new ValidationResult("The field cannot be empty");
            }
            var firstLetter = value.ToString()[0];
            if(char.IsUpper(firstLetter))
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("The first letter must be uppercase");
            }
        }
    }
}
