using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DTOs
{
    public class AuthorDTO
    {
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public DateTime AuthorDob { get; set; }
        public List<BookDTO> Books { get; set; }   
    }
}
