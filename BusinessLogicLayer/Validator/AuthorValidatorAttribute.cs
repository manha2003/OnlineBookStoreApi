using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Validator
{
    internal class AuthorValidatorAttribute : ValidationAttribute
    {
       
        public class AuthorNameAttribute :ValidationAttribute
        {
            private const string ErrorMessage = "Author Name must be at least {10} characters";
            public AuthorNameAttribute() :base(ErrorMessage) { }

            public override bool IsValid(object value)
            {
                if (value is string authorName)
                {
                    return !string.IsNullOrEmpty(authorName) && authorName.Length >= 10 && authorName.Length <= 50;
                }
                return false;
            }
        }

        public class AuthorDoBAttribute : ValidationAttribute
        {
            private const string ErrorMessage = "Invalid date format. Use DD/MM/YYYY.";

            public AuthorDoBAttribute() :base(ErrorMessage) { }
            public override bool IsValid(object value)
            {
                if ( value is DateTime date )
                {
                    return date <= DateTime.Now.Date;
                }
                return false;
            }
        }
    }
}
