using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    

    public class Book
        {
            [Key]
            public int BookId { get; set; }
            public string Title { get; set; }
            public DateTime PublicationDate { get; set; }
            [ForeignKey("Author")]
            public int AuthorId { get; set; }
            public float Price { get; set; }
            public int Stock { get; set; }
            public string Genre { get; set; }

            public List<Author> Authors { get; set; }
    }
    
}
