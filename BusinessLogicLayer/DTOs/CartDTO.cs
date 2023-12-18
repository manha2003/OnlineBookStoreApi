using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DTOs
{
    public class CartDTO
    {
        public int CartId { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }
        public int TotalBooks { get; set; }
        public int TotalPrice { get; set; }

        public UserDTO? User { get; set; }
        public OrderDTO? Order { get; set; }
        public List<BookDTO?> Books { get; set; }

    }
}
