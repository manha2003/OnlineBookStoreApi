using AutoMapper;
using DataAccessLayer;
using DataAccessLayer.Models;
using BusinessLogicLayer.DTOs.CartDTO;
using BusinessLogicLayer.DTOs.BookDTO;
using Microsoft.EntityFrameworkCore;
using BusinessLogicLayer.DTOs.OrderDTO;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccessLayer.Repository;

namespace BusinessLogicLayer.Services.OrderService
{
    public class OrderService:  IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IRepository<User> _userRepository;
        private readonly ICartRepository _cartRepository;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepository, IRepository<User>  userRepository, ICartRepository cartRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _userRepository = userRepository;
            _cartRepository = cartRepository;
            _mapper = mapper;
        }

        public async Task PlaceOrderAsync(PlaceOrderRequestDTO requestModel)
        {
            var user = await _userRepository.GetByIdAsync(requestModel.UserId);
            var cart = await _cartRepository.GetByIdAsync(requestModel.CartId);

            if (user == null || cart == null)
            {
                throw new ("User or Cart not found.");
            }

            float totalCost = CalculateTotalCost(cart.Books);

           
            user.UserBalance -= totalCost;

            var orderDTO = new OrderDTOTemp
            {
                CartId = requestModel.CartId,
                OrderDate = DateTime.UtcNow,
                Payment = totalCost,
                PaymentStatus = user.UserBalance >= 0 ? "Paid" : "PendingPayment",
               

            };

            await _orderRepository.AddAsync(_mapper.Map<Order>(orderDTO));

            await _userRepository.UpdateAsync(user);
           


        }
        public async Task<OrderDTOTemp> GetOrderByIdAsync(int orderId)
        {
            var order = await _orderRepository.GetByIdAsync(orderId);
            return _mapper.Map<OrderDTOTemp>(order);
        }

        public async Task<IEnumerable<OrderDTODetails>> GetAllOrdersAsync()
        {
            var orders = await _orderRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<OrderDTODetails>>(orders);
        }

        public async Task UpdateOrderAsync(OrderDTODetails orderDTO)
        {
            var existingOrder = await _orderRepository.GetByIdAsync(orderDTO.OrderId);

            
            // Update properties of existingOrder with orderDTO properties
            // Assuming AutoMapper is configured to handle the mapping

            await _orderRepository.UpdateAsync(existingOrder);
        }

        public async Task DeleteOrderAsync(int orderId)
        {
            await _orderRepository.DeleteAsync(orderId);
        }

     

    private float CalculateTotalCost(List<Book> books)
        {
            return books.Sum(book => book.Price);
        }
    }

        
}
