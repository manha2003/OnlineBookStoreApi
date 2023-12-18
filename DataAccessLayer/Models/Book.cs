using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public enum BookGenre
    {
        SciFi,
        Fantasy ,
        Romance ,
        Thriller,
        NonFiction,
    }

    public class Book
        {
            public int BookId { get; set; }
            public string Title { get; set; }
            public DateTime PublicationDate { get; set; }
            public int AuthorId { get; set; }
            public float Price { get; set; }
            public int Stock { get; set; }
            public BookGenre Genre { get; set; }

        // Navigation property
            public ICollection<Cart> Carts { get; set; } // Navigation property for N:1 relationship
            public ICollection<Author> Authors { get; set; }
    }
    
}
