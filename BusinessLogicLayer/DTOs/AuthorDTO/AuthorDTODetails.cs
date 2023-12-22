using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessLogicLayer.DTOs.BookDTO;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessLogicLayer.DTOs.AuthorDTO
{
    public class AuthorDTODetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AuthorId { get; set; }
        [Required]
        public string AuthorName { get; set; }
        [Required]
        public DateTime AuthorDob { get; set; }
        
       /* public List<AuthorDTODetails> AuthorDetails { get; set; }*/
    }
}
