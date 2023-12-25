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
    public class BookDTOTemp
    {
        public int BookId { get; set; }


        public string Title { get; set; }

        public float Price { get; set; }

        public string Genre
        {
            get; set;
        }
    }
}