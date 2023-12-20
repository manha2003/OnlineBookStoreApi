using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DTOs.OrderDTO
{
    public class OrderDTODetails
    {
        public int OrderId { get; set; }
        
        public int CartId { get; set; }
        public int TotalBooks { get; set; }
        
        public DateTime OrderDate { get; set; }

        public int Payment { get; set; }
        public string PaymentStatus { get; set; }
        
/*
        public CartDTO? Cart { get; set; }*/
    }
}
