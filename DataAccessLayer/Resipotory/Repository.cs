using DataAccessLayer.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Data;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly OnlineBookStoreDbContext _context;

        public Repository(OnlineBookStoreDbContext context)
        {
            _context = context;
        }

<<<<<<< Updated upstream
        public async Task<T> GetByIdAsync(int id) => await _context.Set<T>().FindAsync(id);

=======
        public async Task<T> GetByIdAsync(int Id)
        {
            if (typeof(T) == typeof(Cart))
            {
             return await _context.Carts
            .Include(c => c.User)
            .Include(c => c.Books)  // Include the Books navigation property
            .FirstOrDefaultAsync(c => c.CartId == Id) as T;
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

            if (typeof(T) == typeof(User))
            {
                return await _context.Set<User>()
                    .Include(c => c.Cart)
                
                .FirstOrDefaultAsync(u => ((User)(object)u).UserId == Id) as T;

                
            }

            return null;
        }

>>>>>>> Stashed changes
        public async Task<IEnumerable<T>> GetAllAsync() => await _context.Set<T>().ToListAsync();

        public async Task AddAsync(T entity)
        {
            _context.Set<T>().AddAsync(entity);
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
    }
}
