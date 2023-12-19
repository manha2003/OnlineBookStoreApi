using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Order
    {
        public int OrderId { get; set; }
      
        public int CartId { get; set; }
        public int TotalBooks { get; set; }
      
        public DateTime OrderDate { get; set; }
        public bool PaymentStatus { get; set; }
        public int Payment { get; set; }

        // Navigation properties
        
        public Cart? Cart { get; set; }
    }
}
