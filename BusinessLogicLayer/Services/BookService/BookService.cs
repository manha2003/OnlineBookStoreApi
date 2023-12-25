using AutoMapper;
using DataAccessLayer;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccessLayer.Repository;
using BusinessLogicLayer.DTOs.BookDTO;

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

        public async Task<BookDTODetails> GetBookByIdAsync(int bookId)
        {
            var bookEntity = await _bookRepository.GetByIdAsync(bookId);
            return _mapper.Map<BookDTODetails>(bookEntity);
        }

        public async Task<List<BookDTODetails>> GetAllBooksAsync()
        {
            var bookEntities = await _bookRepository.GetAllAsync();
            return _mapper.Map<List<BookDTODetails>>(bookEntities);
        }

        public async Task AddBookAsync(BookDTODetails bookDTO)
        {
            var bookEntity = _mapper.Map<Book>(bookDTO);
            await _bookRepository.AddAsync(bookEntity);
        }

        public async Task UpdateBookAsync(BookDTODetails bookDTO)
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
