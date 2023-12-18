using AutoMapper;
using DataAccessLayer;
using DataAccessLayer.Models;
using BusinessLogicLayer.DTOs;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.BookService
{
    public interface IBookService
    {
    Task<BookDTO> GetBookByIdAsync(int bookId);
    Task<List<BookDTO>> GetAllBooksAsync();
    Task AddBookAsync(BookDTO bookDTO);
    Task UpdateBookAsync(BookDTO bookDTO);
    Task DeleteBookAsync(int bookId);
    }
}
