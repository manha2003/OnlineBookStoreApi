using AutoMapper;
using DataAccessLayer;
using DataAccessLayer.Models;
using BusinessLogicLayer.DTOs;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLogicLayer.DTOs.CartDTO;
using BusinessLogicLayer.DTOs.BookDTO;

namespace BusinessLogicLayer.Services.CartService
{
    public interface ICartService
    {
        Task<CartDTOAdditionalDetails> GetCartByIdAsync(int cartId);
        Task<List<CartDTODetails>> GetAllCartsAsync();
        Task AddCartAsync(CartDTODetails cartDTO);
        Task UpdateCartAsync(CartDTODetails cartDTO);
        Task DeleteCartAsync(int cartId);
    }

}
