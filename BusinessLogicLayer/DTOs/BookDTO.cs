using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DTOs
{
    public class BookDTO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookId { get; set; }
        [Required]
        public string Title { get; set; }
        public DateTime? PublicationDate { get; set; }
        public float Price { get; set; }
        [Required]
        public int Stock { get; set; }
        [Required]
        public string Genre { get; set; }

        //public List<CartDTO?> Carts { get; set; }
        //public List<AuthorDTO> Authors { get; set; }
    }
}
