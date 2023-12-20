using AutoMapper;
using DataAccessLayer;
using DataAccessLayer.Models;
using BusinessLogicLayer.DTOs.OrderDTO;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccessLayer.IRepository;

namespace BusinessLogicLayer.Services.OrderService
{
    public class OrderService : IOrderService
    {
        private readonly IRepository<Order> _orderRepository;
        private readonly IMapper _mapper;

        public OrderService(IRepository<Order> orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<OrderDTODetails> GetOrderByIdAsync(int orderId)
        {
            var orderEntity = await _orderRepository.GetByIdAsync(orderId);
            return _mapper.Map<OrderDTODetails>(orderEntity);
        }

        public async Task<List<OrderDTODetails>> GetAllOrdersAsync()
        {
            var orderEntities = await _orderRepository.GetAllAsync();
            return _mapper.Map<List<OrderDTODetails>>(orderEntities);
        }

        public async Task AddOrderAsync(OrderDTODetails orderDTO)
        {
            var orderEntity = _mapper.Map<Order>(orderDTO);
            await _orderRepository.AddAsync(orderEntity);
        }

        public async Task UpdateOrderAsync(OrderDTODetails orderDTO)
        {
            var existingOrderEntity = await _orderRepository.GetByIdAsync(orderDTO.OrderId);

            if (existingOrderEntity != null)
            {
                _mapper.Map(orderDTO, existingOrderEntity);
                await _orderRepository.UpdateAsync(existingOrderEntity);
            }
        }

        public async Task DeleteOrderAsync(int orderId)
        {
            await _orderRepository.DeleteAsync(orderId);
        }
    }
}
