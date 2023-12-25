using DataAccessLayer.Data;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class CartRepository : ICartRepository
    {
        private readonly OnlineBookStoreDbContext _context;

        public CartRepository(OnlineBookStoreDbContext context)
        {
            _context = context;
        }

        public async Task<Cart> GetByIdAsync(int cartId)
        {
            return await _context.Carts
                .Include(c => c.User)
                .Include(c => c.Books)
                .FirstOrDefaultAsync(c => c.CartId == cartId);
        }

        public async Task<IEnumerable<Cart>> GetAllAsync()
        {
            return await _context.Carts
               
                .ToListAsync();
        }

        public async Task AddAsync(Cart cart)
        {
            _context.Carts.Add(cart);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Cart cart)
        {
            _context.Carts.Update(cart);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int cartId)
        {
            var cart = await GetByIdAsync(cartId);
            if (cart != null)
            {
                _context.Carts.Remove(cart);
                await _context.SaveChangesAsync();
            }
        }
    }
}
