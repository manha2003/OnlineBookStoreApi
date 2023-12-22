using System;
using BusinessLogicLayer.Services.UserService;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DataAccessLayer.Repository;
using DataAccessLayer.IRepository;
using DataAccessLayer.Models;

namespace BusinessLogicLayer.Validator
{
    public class UserValidatorAttribute : ValidationAttribute
    {
        private const string DefaultErrorMessage = "Username must be between {2} and {1} characters.";

        [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
        public class UsernameAttribute : ValidationAttribute
        {


            public UsernameAttribute() : base(DefaultErrorMessage)
            {
            }

            public override bool IsValid(object value)
            {
                if (value is string username)
                {
                    return !string.IsNullOrEmpty(username) && username.Length >= 3 && username.Length <= 50;
                }

                return false;
            }
        }


        [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
        public class EmailAttribute : ValidationAttribute
        {
           
            private const string DefaultErrorMessage = "Invalid email format or email must be unique.";

            public EmailAttribute() : base(DefaultErrorMessage)
            {
              
            }


            public override bool IsValid(object value)
            {
                if (value is string email)
                {
                    if (string.IsNullOrEmpty(email)) 
                    {
                        return false;
                    }
                    string emailRegex = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.com$";
                    Regex regex = new(emailRegex);
                    return regex.IsMatch(email);
                }
                return false;
            }
        }

        [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
        public class DateFormatAttribute : ValidationAttribute
        {
            private const string DefaultErrorMessage = "Invalid date format. Use DD/MM/YYYY.";

            public DateFormatAttribute() : base(DefaultErrorMessage)
            {
            }

            public override bool IsValid(object value)
            {
                if (value is DateTime dateTime)
                {
                    dateTime = dateTime.Date;
                    return dateTime <= DateTime.Now.Date;
                }

                return false;
            }



            [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
            public class AddressAttribute : ValidationAttribute
            {
                private const string DefaultErrorMessage = "Address must be less than or equal to {1} characters.";

                public AddressAttribute() : base(DefaultErrorMessage)
                {
                }

                public override bool IsValid(object value)
                {
                    if (value is string address)
                    {
                        return !string.IsNullOrEmpty(address) && address.Length <= 50;
                    }

                    return false;
                }
            }

            [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
            public class PhoneNumberAttribute : ValidationAttribute
            {
                private const string DefaultErrorMessage = "Invalid phone number format. Use international format or start with 0.";

                private const string PhoneNumberRegex = @"^(?:\+84|0)\d{1,10}$";

                public PhoneNumberAttribute() : base(DefaultErrorMessage)
                {
                }

                public override bool IsValid(object value)
                {
                    if (value is string phoneNumber)
                    {

                        return Regex.IsMatch(phoneNumber, PhoneNumberRegex);
                    }

                    return false;
                }

                // đang sửa coi lại IRepository, IUserService (còn paging) chưa làm filter cho Book Order và Author, Book cần Validation

            }




        }

    }
}
