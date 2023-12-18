using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DTOs
{
    public class BookDTO
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public DateTime PublicationDate { get; set; }
        public float Price { get; set; }
        public int Stock { get; set; }
        public string Genre { get; set; }

        public List<CartDTO?> Carts { get; set; }
        public List<AuthorDTO> Authors { get; set; }
    }
}
