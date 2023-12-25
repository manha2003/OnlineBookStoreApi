using BusinessLogicLayer.DTOs.BookDTO;
using BusinessLogicLayer.DTOs.UserDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DTOs.CartDTO
{
    public class UpdateCartDTO
    {
        public int CartId { get; set; }
        
       

        public List<BookDTODetails?> Books { get; set; }
    }
}
