using AutoMapper;
using DataAccessLayer;
using DataAccessLayer.Models;
using BusinessLogicLayer.DTOs.CartDTO;
using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccessLayer.Repository;
using BusinessLogicLayer.DTOs.BookDTO;

namespace BusinessLogicLayer.Services.CartService
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;
        private readonly IMapper _mapper;

        public CartService(ICartRepository cartRepository, IMapper mapper)
        {
            _cartRepository = cartRepository;
            _mapper = mapper;
        }

        public async Task<CartAdditionalDetails> GetCartByIdAsync(int cartId)
        {
            var cartEntity = await _cartRepository.GetByIdAsync(cartId);
            return _mapper.Map<CartAdditionalDetails>(cartEntity);
        }

        public async Task<List<CartDTODetails>> GetAllCartsAsync()
        {
            var cartEntities = await _cartRepository.GetAllAsync();
            return _mapper.Map<List<CartDTODetails>>(cartEntities);
        }


        public async Task AddCartAsync(CartDTODetails cartDTO)
        {
           
            var cartEntity = _mapper.Map<Cart>(cartDTO);

            await _cartRepository.AddAsync(cartEntity);
        }

        // Other methods of the CartService...


        public async Task UpdateCartAsync(UpdateCartDTO cartDTO)
        {
            var existingCartEntity = await _cartRepository.GetByIdAsync(cartDTO.CartId);

            if (existingCartEntity != null)
            {
                _mapper.Map(cartDTO, existingCartEntity);
                await _cartRepository.UpdateAsync(existingCartEntity);
            }
        }

        public async Task DeleteCartAsync(int cartId)
        {
            await _cartRepository.DeleteAsync(cartId);
        }
    }
}

