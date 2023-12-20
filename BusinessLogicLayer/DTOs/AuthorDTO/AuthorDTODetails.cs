using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessLogicLayer.DTOs.BookDTO;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DTOs.AuthorDTO
{
    public class AuthorDTODetails
    {
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public DateTime AuthorDob { get; set; }
        
       /* public List<AuthorDTODetails> AuthorDetails { get; set; }*/
    }
}
