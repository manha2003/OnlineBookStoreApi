using AutoMapper;
using DataAccessLayer;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLogicLayer.DTOs.UserDTO;

namespace BusinessLogicLayer.Services.UserService
{
    public interface IUserService
    {
        Task<UserDTODetails> GetUserByIdAsync(int userId);
        Task<List<UserDTODetails>> GetAllUsersAsync();
        Task AddUserAsync(UserDTODetails userDTO);
        Task UpdateUserAsync(UserDTODetails userDTO);
        Task DeleteUserAsync(int userId);

        Task<bool> IsPhoneNumberUniqueAsync(string phoneNumber);
        Task<bool> IsAddressUniqueAsync(string address);
        Task<bool> IsEmailUniqueAsync(string email);

    }
}
