using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLogicLayer.Services.BookService;
using BusinessLogicLayer.DTOs.BookDTO;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookDTODetails>> GetBookById(int id)
        {
            var book = await _bookService.GetBookByIdAsync(id);

            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        [HttpGet]
        public async Task<ActionResult<List<BookDTODetails>>> GetAllBooks()
        {
            var books = await _bookService.GetAllBooksAsync();
            return Ok(books);
        }

        [HttpPost]
        public async Task<ActionResult> AddBook([FromBody] BookDTODetails bookDTO)
        {
            await _bookService.AddBookAsync(bookDTO);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateBook(int id, [FromBody] BookDTODetails  bookDTO)
        {
            if (id != bookDTO.BookId)
            {
                return BadRequest();
            }

            await _bookService.UpdateBookAsync(bookDTO);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBook(int id)
        {
            await _bookService.DeleteBookAsync(id);
            return Ok();
        }
    }
}