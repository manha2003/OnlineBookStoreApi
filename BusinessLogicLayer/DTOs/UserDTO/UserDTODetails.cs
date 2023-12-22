using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessLogicLayer.DTOs.OrderDTO;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using BusinessLogicLayer.Validator;
using BusinessLogicLayer.Services.UserService;
using DataAccessLayer.IRepository;
using DataAccessLayer.Models;

namespace BusinessLogicLayer.DTOs.UserDTO
{
    public class UserDTODetails
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        [UserValidatorAttribute.Username]
        public string UserName { get; set; }
        [UserValidatorAttribute.Email]
        public string UserEmail { get; set; }

        [UserValidatorAttribute.DateFormat]
        public DateTime UserDob { get; set; }

        [Required]
        public string? UserAddress { get; set; }

        [Required, RegularExpression(@"^(?:\+84|0)\d{1,10}$")]
        public string? UserPhoneNumber { get; set; }

        [Required]
        [Range(0, 50000)]
        public float? UserBalance { get; set; }

      /*  public OrderDTODetails? Order { get; set; }*/

        /*  public CartDTO? Cart { get; set; }
          public OrderDTO? Order { get; set; }*/
    }
}
