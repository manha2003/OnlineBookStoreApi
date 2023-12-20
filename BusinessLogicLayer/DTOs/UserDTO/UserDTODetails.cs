using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessLogicLayer.DTOs.OrderDTO;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DTOs.UserDTO
{
    public class UserDTODetails
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        //public DateTime UserDob { get; set; }
        public string? UserAddress { get; set; }
        public string? UserPhoneNumber { get; set; }

        public float? UserBalance { get; set; }

      /*  public OrderDTODetails? Order { get; set; }*/

        /*  public CartDTO? Cart { get; set; }
          public OrderDTO? Order { get; set; }*/
    }
}
