using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public interface ICartRepository
    {
        Task<Cart> GetByIdAsync(int cartId);
        Task<IEnumerable<Cart>> GetAllAsync();
        Task AddAsync(Cart cart);
        Task UpdateAsync(Cart cart);
        Task DeleteAsync(int cartId);
    }
}
