using AutoMapper;
using DataAccessLayer;
using DataAccessLayer.Models;
using BusinessLogicLayer.DTOs.OrderDTO;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.OrderService
{
    public interface IOrderService
    {
        Task<OrderDTODetails> GetOrderByIdAsync(int orderId);
        Task<List<OrderDTODetails>> GetAllOrdersAsync();
        Task AddOrderAsync(OrderDTODetails orderDTO);
        Task UpdateOrderAsync(OrderDTODetails orderDTO);
        Task DeleteOrderAsync(int orderId);
    }
}
