using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLogicLayer.Services.CartService;
using BusinessLogicLayer.Services.UserService;
using BusinessLogicLayer.Services.BookService;
using BusinessLogicLayer.DTOs.CartDTO;
using Microsoft.AspNetCore.Mvc;
using DataAccessLayer.Models;
using AutoMapper;
using BusinessLogicLayer.DTOs.BookDTO;

namespace PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;
        private readonly IUserService _userService;
        private readonly IBookService _bookService;



        public CartController(ICartService cartService, IUserService userService, IBookService bookService)
        {
            _cartService = cartService;
            _userService = userService;
            _bookService = bookService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CartDTOAdditionalDetails>> GetCartById(int id)
        {
            var cart = await _cartService.GetCartByIdAsync(id);

            if (cart == null)
            {
                return NotFound();
            }

            // Populate UserId in the DTO based on the associated user
            

            return Ok(cart);
        }

        [HttpGet]
        public async Task<ActionResult<List<CartDTODetails>>> GetAllCarts()
        {
            var carts = await _cartService.GetAllCartsAsync();
            return Ok(carts);
        }


        [HttpPost]
        public async Task<IActionResult> AddCart([FromBody] CartDTODetails cartItemDTO)
        {

           
            // Add the new cart
            await _cartService.AddCartAsync(cartItemDTO);
            return Ok("Cart added successfully");

        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCart(int id, [FromBody] UpdateCartDTO cartDTO)
        {
            if (id != cartDTO.CartId)
            {
                return BadRequest();
            }

            await _cartService.UpdateCartAsync(cartDTO);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCart(int id)
        {
            await _cartService.DeleteCartAsync(id);
            return Ok();
        }
    }
}