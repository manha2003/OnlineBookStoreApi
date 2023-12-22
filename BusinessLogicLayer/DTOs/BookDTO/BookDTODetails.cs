using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessLogicLayer.DTOs.CartDTO;
using BusinessLogicLayer.DTOs.AuthorDTO;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BusinessLogicLayer.Validator;

namespace BusinessLogicLayer.DTOs.BookDTO
{
    public class BookDTODetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookId { get; set; }
        [Required]
        [BookValidatorAttribute.BookTitle]
        public string Title { get; set; }
        [Required]
        public string AuthorId { get; set; }
        [BookValidatorAttribute.DateFormat]
        public DateTime PublicationDate { get; set; }
        [Required]
        [BookValidatorAttribute.BookPrice]
        public float Price { get; set; }
        [Required]
        [BookValidatorAttribute.BookStock]
        public int Stock { get; set; }
        [Required]
        [BookValidatorAttribute.BookGenre]
        public string Genre { get; set; }

    }
}
