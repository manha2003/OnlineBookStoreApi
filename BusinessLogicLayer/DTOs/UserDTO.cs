using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DTOs
{
    public class UserDTO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Username must be between {2} and {1} characters", MinimumLength = 3)]
        public string? UserName { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Invalid email format or email must be unique.")]
        public string UserEmail { get; set; }

        //public DateTime UserDob { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Address must be less than or equal to {1} characters")]
        public string? UserAddress { get; set; }

        [Required]
        [RegularExpression(@"^(?:\+84|0)\d{1,13}$", ErrorMessage = "Invalid phone number format. Use international format or start with 0.")]
        public string? UserPhoneNumber { get; set; }

      /*  public CartDTO? Cart { get; set; }
        public OrderDTO? Order { get; set; }*/
    }
}
