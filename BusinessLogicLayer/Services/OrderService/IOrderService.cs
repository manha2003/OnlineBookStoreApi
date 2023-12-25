using AutoMapper;
using DataAccessLayer;
using DataAccessLayer.Models;
using BusinessLogicLayer.DTOs.CartDTO;
using Microsoft.EntityFrameworkCore;
using BusinessLogicLayer.DTOs.OrderDTO;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccessLayer.Repository;

namespace BusinessLogicLayer.Services.OrderService
{
    public interface IOrderService
    {
        Task PlaceOrderAsync(PlaceOrderRequestDTO requestModel);
        Task<OrderDTOTemp> GetOrderByIdAsync(int orderId);
        Task<IEnumerable<OrderDTODetails>> GetAllOrdersAsync();
        Task UpdateOrderAsync(OrderDTODetails orderDTO);
        Task DeleteOrderAsync(int orderId);
       
    }
}
