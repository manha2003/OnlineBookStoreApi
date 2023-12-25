using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Validator
{
    internal class CartValidatorAttribute : ValidationAttribute
    {
        public class TotalBooksValidationAttribute : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                int totalBooks = (int)value;

                if (totalBooks <= 0)
                {
                    return new ValidationResult("Total books must be start from 1.");
                }

                return ValidationResult.Success;
            }
        }

        public class TotalPriceValidationAttribute : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                int totalPrice = (int)value;

                if (totalPrice <= 0)
                {
                    return new ValidationResult("Total price must be a positive value.");
                }

                return ValidationResult.Success;
            }
        }
    }
}
