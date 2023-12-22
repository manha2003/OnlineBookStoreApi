using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DTOs.OrderDTO
{
    public class OrderDTODetails
    {
        [Key]
        public int OrderId { get; set; }
       
        public int CartId { get; set; } // FK
        public int TotalBooks { get; set; } // !<0
        
        public DateTime OrderDate { get; set; }

        public float Payment { get; set; }
        public string PaymentStatus { get; set; }
        
/*
        public CartDTO? Cart { get; set; }*/
    }
}
