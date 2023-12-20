using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLogicLayer.Services.OrderService;
using BusinessLogicLayer.DTOs.OrderDTO;
using Microsoft.AspNetCore.Mvc;
using DataAccessLayer.Models;
using AutoMapper;
using BusinessLogicLayer.DTOs.BookDTO;
namespace PresentationLayer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderDTODetails>>> GetOrders()
        {
            try
            {
                var orders = await _orderService.GetAllOrdersAsync();
                return Ok(orders);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error retrieving orders: {ex.Message}");
            }
        }

        [HttpGet("{orderId}")]
        public async Task<ActionResult<OrderDTODetails>> GetOrderById(int orderId)
        {
            try
            {
                var order = await _orderService.GetOrderByIdAsync(orderId);

                if (order == null)
                    return NotFound($"Order with ID {orderId} not found");

                return Ok(order);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error retrieving order: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult> PlaceOrder([FromBody] OrderDTODetails orderDTO)
        {
            try
            {
                // Validate the orderDTO before placing the order
                // Example: You can use a validation service or validate within the OrderService

                // Place the order
                await _orderService.AddOrderAsync(orderDTO);

                return Ok("Order placed successfully");
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to place order: {ex.Message}");
            }
        }

        [HttpPut("{orderId}")]
        public async Task<ActionResult> UpdateOrder(int orderId, [FromBody] OrderDTODetails orderDTO)
        {
            try
            {
                // Validate the updatedOrderDTO before updating the order
                // Example: You can use a validation service or validate within the OrderService

                // Update the order
                await _orderService.UpdateOrderAsync(orderDTO);

                return Ok($"Order with ID {orderId} updated successfully");
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to update order: {ex.Message}");
            }
        }

        [HttpDelete("{orderId}")]
        public async Task<ActionResult> DeleteOrder(int orderId)
        {
            try
            {
                // Delete the order
                await _orderService.DeleteOrderAsync(orderId);

                return Ok($"Order with ID {orderId} deleted successfully");
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to delete order: {ex.Message}");
            }
        }
    }
}
