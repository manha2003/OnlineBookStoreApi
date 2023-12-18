using AutoMapper;
using DataAccessLayer;
using DataAccessLayer.Models;
using BusinessLogicLayer.DTOs;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccessLayer.IRepository;

namespace BusinessLogicLayer.Services.BookService
{
    public class BookService : IBookService
    {

        private readonly IRepository<Book> _bookRepository;
        private readonly IMapper _mapper;

        public BookService(IRepository<Book> bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<BookDTO> GetBookByIdAsync(int bookId)
        {
            var bookEntity = await _bookRepository.GetByIdAsync(bookId);
            return _mapper.Map<BookDTO>(bookEntity);
        }

        public async Task<List<BookDTO>> GetAllBooksAsync()
        {
            var bookEntities = await _bookRepository.GetAllAsync();
            return _mapper.Map<List<BookDTO>>(bookEntities);
        }

        public async Task AddBookAsync(BookDTO bookDTO)
        {
            var bookEntity = _mapper.Map<Book>(bookDTO);
            await _bookRepository.AddAsync(bookEntity);
        }

        public async Task UpdateBookAsync(BookDTO bookDTO)
        {
            var existingBookEntity = await _bookRepository.GetByIdAsync(bookDTO.BookId);

            if (existingBookEntity != null)
            {
                _mapper.Map(bookDTO, existingBookEntity);
                await _bookRepository.UpdateAsync(existingBookEntity);
            }
        }

        public async Task DeleteBookAsync(int bookId)
        {
            await _bookRepository.DeleteAsync(bookId);
        }
    }
}
