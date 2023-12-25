using System;
using System.Collections.Generic;
using System.Linq;
using BusinessLogicLayer.DTOs.CartDTO;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DTOs.OrderDTO
{
    public class OrderDTODetails
    {
        public int OrderId { get; set; }
        
        public int CartId { get; set; }
   
        
        public DateTime OrderDate { get; set; }

        public float Payment { get; set; }
        public string PaymentStatus { get; set; }


        public CartAdditionalDetails Cart { get; set; }
    }
}
