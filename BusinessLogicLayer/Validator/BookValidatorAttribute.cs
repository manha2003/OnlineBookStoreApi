using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Validator
{
    public class BookValidatorAttribute : ValidationAttribute
    {
        [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
        public class DateFormatAttribute : ValidationAttribute 
        {
            private const string DefaultErrorMessage = "Invalid date format. Use DD/MM/YYYY.";
            
            public DateFormatAttribute() : base(DefaultErrorMessage) { }

            public override bool IsValid(object value)
            {
                if ( value is DateTime datetime)
                {
                    return datetime <= DateTime.Now.Date;
                }
                return false;
            }

            

        }
        public class BookTitleAttribute : ValidationAttribute
        {
            private const string DefaultErrorMessage = "BookTitle Must be from {10} character";
            public BookTitleAttribute() : base(DefaultErrorMessage) { }

            public override bool IsValid(object value)
            {
                if (value is string bookTitle)
                {
                    return !string.IsNullOrEmpty(bookTitle) && bookTitle.Length >= 10 && bookTitle.Length <= 50;
                }
                return false;
            }
        }

        public class BookStockAttribute : ValidationAttribute 
        {
            private const int MinimumStock = 1;
            private const int MaximumStock= 100;

            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                if ( value is int stock )
                {
                    if ( stock < MinimumStock )
                    {
                        return new ValidationResult(" Stock Must be at least 1. ");
                    }
                    if ( stock > MaximumStock ) 
                    {
                        return new ValidationResult(" Stock can not exceed 100. ");
                    }
                    return ValidationResult.Success;
                }
                return new ValidationResult(" Invalid Stock value. ");
            }
        }

        public class BookPriceAttribute : ValidationAttribute
        {

        }

        public class BookGenreAttribute : ValidationAttribute
        {
            private readonly List<string> ValidGenres = new() { "Action", "History", "Engineering", "Cooking", "Fiction", "Technology" };

            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                if (value is string genre)
                {
                    if (ValidGenres.Contains(genre))
                    {
                        return ValidationResult.Success;
                    }
                    else
                    {
                        return new ValidationResult("Invalid book genre.");
                    }
                }

                return new ValidationResult("Invalid genre value.");
            }
        }
    }
}
