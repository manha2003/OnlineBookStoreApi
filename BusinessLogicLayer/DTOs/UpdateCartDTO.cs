using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessLogicLayer.DTOs.BookDTO;
using BusinessLogicLayer.DTOs.OrderDTO;
using System.Threading.Tasks;

using DataAccessLayer.Models;


namespace BusinessLogicLayer.DTOs.CartDTO
{
    public class UpdateCartDTO
    {
        public int CartId { get; set; }

        public int Quantity { get; set; }
        
     
        public List<BookDTODetails?> Books { get; set; }
    }
}
