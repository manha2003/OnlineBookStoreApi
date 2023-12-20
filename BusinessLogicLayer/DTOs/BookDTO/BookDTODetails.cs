using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessLogicLayer.DTOs.CartDTO;
using BusinessLogicLayer.DTOs.AuthorDTO;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BusinessLogicLayer.DTOs.BookDTO
{
    public class BookDTODetails
    {
        public int BookId { get; set; }

 
        public string Title { get; set; }
        public string AuthorId { get; set; }
        public DateTime PublicationDate { get; set; }
        public float Price { get; set; }
        public int Stock { get; set; }
        public string Genre { get; set; }

       /* public List<CartDTODetails?> Carts { get; set; }
        public List<AuthorDTODetails> Authors { get; set; }*/
    }
}
