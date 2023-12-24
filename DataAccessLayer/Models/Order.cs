using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Models
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderId { get; set; }
        [ForeignKey("Cart")]
        public int CartId { get; set; }
        public int TotalBooks { get; set; }
        public int TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
        
        
        public float Payment {  get; set; }
        public string PaymentStatus { get; set; }
        // Navigation properties

        public Cart Cart { get; set; }
    }
}
