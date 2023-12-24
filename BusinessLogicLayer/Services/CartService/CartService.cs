using AutoMapper;
using DataAccessLayer;
using DataAccessLayer.Models;
using BusinessLogicLayer.DTOs;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.CartService
{
    public class CartService
    {
<<<<<<< Updated upstream
=======
        private readonly IRepository<Cart> _cartRepository;
        /*  private readonly IRepository<Book> _bookRepository;
         *  
          private readonly IRepository<User> _userRepository;*/


        private readonly IMapper _mapper;

        public CartService(IRepository<Cart> cartRepository, IMapper mapper)
        {
            _cartRepository = cartRepository;
            _mapper = mapper;
           
        }

        public async Task<CartDTOAdditionalDetails> GetCartByIdAsync(int cartId)
        {
            var cart = await _cartRepository.GetByIdAsync(cartId);

            return _mapper.Map<CartDTOAdditionalDetails>(cart);
        }

        public async Task<List<CartDTODetails>> GetAllCartsAsync()
        {
            var cartEntities = await _cartRepository.GetAllAsync();
            return _mapper.Map<List<CartDTODetails>>(cartEntities);
        }


        public async Task AddCartAsync(CartDTODetails cartItemDTO)
        {

            var cartEntity = _mapper.Map<Cart>(cartItemDTO);

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
>>>>>>> Stashed changes
    }
}
