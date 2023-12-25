using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessLogicLayer.DTOs.BookDTO;
using BusinessLogicLayer.DTOs.OrderDTO;
using System.Threading.Tasks;
using BusinessLogicLayer.DTOs.UserDTO;
using Microsoft.Identity.Client;

namespace BusinessLogicLayer.DTOs.CartDTO
{
   public class CartAdditionalDetails
    {
        public int CartId { get; set; }

        public int UserId { get; set; }

        public int Quantity { get; set; }
       

       public UserDTOTemp User { get; set; }
       
       public List<BookDTODetails?> Books { get; set; }
    }
}
