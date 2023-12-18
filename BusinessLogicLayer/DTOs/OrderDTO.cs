using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DTOs
{
    public class OrderDTO
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public int CartId { get; set; }
        public int TotalBooks { get; set; }
        public int TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
        public bool PaymentStatus { get; set; }
        public int Payment { get; set; }
        
        public CartDTO? Cart { get; set; }
    }
}
