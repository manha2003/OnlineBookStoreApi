using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLogicLayer.Services.BookService;
using BusinessLogicLayer.DTOs.BookDTO;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.Filter;

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
                return NotFound("Book can not be found");
            }

            return StatusCode(200);
        }

        [HttpGet]
        public async Task<ActionResult<List<BookDTODetails>>> GetAllBooks([FromQuery] BookFilter filter)
        {
            var allBooks = await _bookService.GetAllBooksAsync();
            var filteredBooks = filter.ApplyFilter(allBooks);
            return Ok(filteredBooks);
        }

        [HttpPost]
        public async Task<ActionResult> AddBook([FromBody] BookDTODetails bookDTO)
        {
            await _bookService.AddBookAsync(bookDTO);
            return Ok("Book added successfully");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateBook(int id, [FromBody] BookDTODetails  bookDTO)
        {
            if (id != bookDTO.BookId)
            {
                return BadRequest("There is no Book with {id}");
            }

            await _bookService.UpdateBookAsync(bookDTO);
            return Ok("Book Updated");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBook(int id)
        {
            await _bookService.DeleteBookAsync(id);
            return Ok("Book Deleted");
        }
    }
}