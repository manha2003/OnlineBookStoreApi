using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessLogicLayer.DTOs.BookDTO;
using BusinessLogicLayer.DTOs.OrderDTO;
using System.Threading.Tasks;
using BusinessLogicLayer.DTOs.UserDTO;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BusinessLogicLayer.Validator;

namespace BusinessLogicLayer.DTOs.CartDTO
{
    public class CartDTODetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CartId { get; set; }

        [ForeignKey("UserDTODetails")]
        public int UserId { get; set; }
        [ForeignKey("BookDTODetails")]
        public int BookId { get; set; }
        [CartValidatorAttribute.TotalBooksValidation]
        public int TotalBooks { get; set; }
        [CartValidatorAttribute.TotalPriceValidation]
        public int TotalPrice { get; set; }

       /* public UserDTODetails? User { get; set; }
        public OrderDTODetails? Order { get; set; }
        public List<BookDTODetails?> Books { get; set; }*/

    }
}
