using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessLogicLayer.DTOs.BookDTO;
using BusinessLogicLayer.DTOs.OrderDTO;
using System.Threading.Tasks;
using BusinessLogicLayer.DTOs.UserDTO;

namespace BusinessLogicLayer.DTOs.CartDTO
{
    public class CartDTOAdditionalDetails
    {
        public int CartId { get; set; }


        public int UserId { get; set; }
        public int BookId { get; set; }
        public int TotalBooks { get; set; }
        public int TotalPrice { get; set; }

        public UserDTODetails User { get; set; }
 
        public List<BookDTODetails> Books { get; set; }
    }
}
