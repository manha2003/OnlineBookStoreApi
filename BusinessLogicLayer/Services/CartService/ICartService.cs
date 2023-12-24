using AutoMapper;
using DataAccessLayer;
using DataAccessLayer.Models;
using BusinessLogicLayer.DTOs;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.CartService
{
    public interface ICartService
    {
<<<<<<< Updated upstream
=======
        Task<CartDTOAdditionalDetails> GetCartByIdAsync(int cartId);
        Task<List<CartDTODetails>> GetAllCartsAsync();
        Task AddCartAsync(CartDTODetails cartDTO);
        Task UpdateCartAsync(UpdateCartDTO cartDTO);
        Task DeleteCartAsync(int cartId);
>>>>>>> Stashed changes
    }
}
