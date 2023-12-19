using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DTOs
{
    public class CartDTO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CartId { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }
        [Required]
        public int TotalBooks { get; set; }
        [Required]
        public int TotalPrice { get; set; }

        public UserDTO? User { get; set; }
        public OrderDTO? Order { get; set; }
        public List<BookDTO?> Books { get; set; }

    }
}
