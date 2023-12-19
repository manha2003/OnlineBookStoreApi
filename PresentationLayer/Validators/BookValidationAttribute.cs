using System.ComponentModel.DataAnnotations;

namespace PresentationLayer.Validators
{
    public class BookValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            return base.IsValid(value, validationContext);
        }
    }
}
