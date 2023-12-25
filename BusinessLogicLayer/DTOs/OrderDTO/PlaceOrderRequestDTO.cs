using System;
using System.Collections.Generic;
using System.Linq;
using BusinessLogicLayer.DTOs.CartDTO;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DTOs.OrderDTO
{
    public class PlaceOrderRequestDTO
    {
 
        public int UserId { get; set; }
        public int CartId { get; set; }

    }
}
