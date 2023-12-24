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
<<<<<<< Updated upstream:BusinessLogicLayer/DTOs/BookDTO.cs
        public DateTime PublicationDate { get; set; }
=======
      /*  public int  AuthorId { get; set; }*/
      /*  public DateTime PublicationDate { get; set; }*/
>>>>>>> Stashed changes:BusinessLogicLayer/DTOs/BookDTO/BookDTODetails.cs
        public float Price { get; set; }
  
        public string Genre { get; set; }

<<<<<<< Updated upstream:BusinessLogicLayer/DTOs/BookDTO.cs
        public List<CartDTO?> Carts { get; set; }
        public List<AuthorDTO> Authors { get; set; }
=======
       

        /* public List<CartDTODetails?> Carts { get; set; }
         public List<AuthorDTODetails> Authors { get; set; }*/
>>>>>>> Stashed changes:BusinessLogicLayer/DTOs/BookDTO/BookDTODetails.cs
    }
}
