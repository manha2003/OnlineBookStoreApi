using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    

    public class Book
        {
            public int BookId { get; set; }
            public string Title { get; set; }
            public DateTime PublicationDate { get; set; }
            public int AuthorId { get; set; }
            public float Price { get; set; }
            public int Stock { get; set; }
            public string Genre { get; set; }

            public List<Author> Authors { get; set; }
    }
    
}
