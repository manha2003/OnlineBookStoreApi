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
    public class OrderRepository : IOrderRepository
    {
        private readonly OnlineBookStoreDbContext _context;

        public OrderRepository(OnlineBookStoreDbContext context)
        {
            _context = context;
        }

        public async Task<Order> GetByIdAsync(int orderId)
        {
            return await _context.Orders
                .Include(o => o.Cart)
              
                .FirstOrDefaultAsync(o => o.OrderId == orderId);
        }

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            return await _context.Orders
                
                .ToListAsync();
        }

        public async Task AddAsync(Order order)
        {
            _context.Orders.Add(order);


            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Order order)
        {
            _context.Orders.Update(order);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int orderId)
        {
            var order = await GetByIdAsync(orderId);
            if (order != null)
            {
                _context.Orders.Remove(order);
                await _context.SaveChangesAsync();
            }
        }
    }
}
