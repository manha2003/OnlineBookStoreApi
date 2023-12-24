using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Cart
    {
        public int CartId { get; set; }
        public int UserId { get; set; }
      
        // Navigation properties
        public int Quantity {  get; set; }
        public User User { get; set; }
<<<<<<< Updated upstream
        public Order? Order { get; set; }
        public ICollection<Book?> Books { get; set; }
=======

        public List<Book> Books { get; set; }

>>>>>>> Stashed changes
    }
}
