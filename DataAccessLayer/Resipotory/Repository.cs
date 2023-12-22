using DataAccessLayer.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Data;
using Microsoft.EntityFrameworkCore;
using DataAccessLayer.Models;

namespace DataAccessLayer.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly OnlineBookStoreDbContext _context;

        public Repository(OnlineBookStoreDbContext context)
        {
            _context = context;
        }

        public async Task<T> GetByIdAsync(int Id)
        {
            if (typeof(T) == typeof(Cart))
            {
                return await _context.Carts
                    .Include(c => ((Cart)(object)c).User)
                    .Include(c => ((Cart)(object)c).Books)
                    .FirstOrDefaultAsync(c => ((Cart)(object)c).CartId == Id) as T;
            }

            if (typeof(T) == typeof(Book))
            {
                return await _context.Set<Book>()
                    .Include(b => b.Authors)
                    .FirstOrDefaultAsync(b => ((Book)(object)b).BookId == Id) as T;
            }

            if (typeof(T) == typeof(Order))
            {
                return await _context.Set<Order>()
                    .Include(o => o.Cart)
                    .FirstOrDefaultAsync(o => ((Order)(object)o).OrderId == Id) as T;
            }

            return null;
        }

            public async Task<IEnumerable<T>> GetAllAsync() => await _context.Set<T>().ToListAsync();

        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                _context.Set<T>().Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

     
        public bool GetBookByTitle( string  title )
        {
            return !_context.Set<Book>().Any( book => book.Title == title );
        }

        Book IRepository<T>.GetBookByTitle(string title)
        {
            throw new NotImplementedException();
        }
    }
}
