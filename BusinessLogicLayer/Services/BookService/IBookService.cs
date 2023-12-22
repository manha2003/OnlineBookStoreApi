using AutoMapper;
using DataAccessLayer;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLogicLayer.DTOs.BookDTO;

namespace BusinessLogicLayer.Services.BookService
{
    public interface IBookService
    {
    Task<BookDTODetails> GetBookByIdAsync(int bookId);
    Task<List<BookDTODetails>> GetAllBooksAsync();
    Task AddBookAsync(BookDTODetails bookDTO);
    Task UpdateBookAsync(BookDTODetails bookDTO);
    Task DeleteBookAsync(int bookId);
    Task<bool> IsBookTitleUnique(string title);
    }
}
