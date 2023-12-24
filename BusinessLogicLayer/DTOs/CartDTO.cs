using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
<<<<<<< Updated upstream:BusinessLogicLayer/DTOs/CartDTO.cs
=======
using BusinessLogicLayer.DTOs.UserDTO;
using DataAccessLayer.Models;
>>>>>>> Stashed changes:BusinessLogicLayer/DTOs/CartDTO/CartDTOAdditionalDetails.cs

namespace BusinessLogicLayer.DTOs
{
    public class CartDTO
    {
        public int CartId { get; set; }
<<<<<<< Updated upstream:BusinessLogicLayer/DTOs/CartDTO.cs
        public int UserId { get; set; }
        public int BookId { get; set; }
        public int TotalBooks { get; set; }
        public int TotalPrice { get; set; }

        public UserDTO? User { get; set; }
        public OrderDTO? Order { get; set; }
        public List<BookDTO?> Books { get; set; }

=======


       
        public int UserId {  get; set; }
      
        public int Quantity { get; set; }
    
        public UserDTOTemp User { get; set; }
        public List<BookDTODetails?> Books { get; set; }



        /*   public List<int> BookIds { get; set; }*/
>>>>>>> Stashed changes:BusinessLogicLayer/DTOs/CartDTO/CartDTOAdditionalDetails.cs
    }
}
