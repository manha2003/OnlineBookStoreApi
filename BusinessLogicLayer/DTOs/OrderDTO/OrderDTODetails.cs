using BusinessLogicLayer.Validator;
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
        [ForeignKey("CartDTODetails")]
        public int CartId { get; set; } // FK
        [OrderValidatorAttribute.TotalBookCheck]
        public int TotalBooks { get; set; } // !<0

        [OrderValidatorAttribute.DateFormat]
        public DateTime OrderDate { get; set; }

        [OrderValidatorAttribute.PaymentValidation]
        public float Payment { get; set; }
        [OrderValidatorAttribute.PaymentStatusValidation]
        public string PaymentStatus { get; set; }
        
/*
        public CartDTO? Cart { get; set; }*/
    }
}
