using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Validator
{
    internal class OrderValidatorAttribute : ValidationAttribute
    {
        public class TotalBookCheckAttribute : ValidationAttribute 
        {
            public TotalBookCheckAttribute() { }

            private const int MinimumStock = 1;
            private const int MaximumStock = 20;

            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                if (value is int stock)
                {
                    if (stock < MinimumStock)
                    {
                        return new ValidationResult(" Total Book Must be at least 1. ");
                    }
                    if (stock > MaximumStock)
                    {
                        return new ValidationResult(" Total Book can not exceed 20. ");
                    }
                    return ValidationResult.Success;
                }
                return new ValidationResult(" Invalid Total Book value. ");
            }
        }

        public class DateFormatAttribute : ValidationAttribute
        {
            private const string ErrorMessage = "Invalid date format. Use DD/MM/YYYY.";

            public DateFormatAttribute() : base(ErrorMessage) { }
            public override bool IsValid(object value)
            {
                if (value is DateTime date)
                {
                    return date <= DateTime.Now.Date;
                }
                return false;
            }
        }

        public class PaymentValidationAttribute : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                float payment = (float)value;

                if (payment <= 0)
                {
                    return new ValidationResult("Payment must be a positive value.");
                }

                return ValidationResult.Success;
            }
        }

        public class PaymentStatusValidationAttribute : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                string paymentStatus = (string)value;

                if (paymentStatus != "Pending" && paymentStatus != "Completed")
                {
                    return new ValidationResult("Invalid payment status.");
                }

                return ValidationResult.Success;
            }
        }
    }
}
