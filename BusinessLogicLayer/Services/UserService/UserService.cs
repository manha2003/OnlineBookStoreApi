using AutoMapper;
using DataAccessLayer;
using DataAccessLayer.Models;
using BusinessLogicLayer.DTOs;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccessLayer.IRepository;

namespace BusinessLogicLayer.Services.UserService
{
    public class UserService: IUserService
    {
        private readonly IRepository<User> _userRepository;
        private readonly IMapper _mapper;

        public UserService(IRepository<User> userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserDTO> GetUserByIdAsync(int userId)
        {
            var userEntity = await _userRepository.GetByIdAsync(userId);
            return _mapper.Map<UserDTO>(userEntity);
        }

        public async Task<List<UserDTO>> GetAllUsersAsync()
        {
            var userEntities = await _userRepository.GetAllAsync();
            return _mapper.Map<List<UserDTO>>(userEntities);
        }

        public async Task AddUserAsync(UserDTO userDTO)
        {
            var userEntity = _mapper.Map<User>(userDTO);
            await _userRepository.AddAsync(userEntity);
        }

        public async Task UpdateUserAsync(UserDTO userDTO)
        {
            var existingUserEntity = await _userRepository.GetByIdAsync(userDTO.UserId);

            if (existingUserEntity != null)
            {
                _mapper.Map(userDTO, existingUserEntity);
                await _userRepository.UpdateAsync(existingUserEntity);
            }
        }

        public async Task DeleteUserAsync(int userId)
        {
            await _userRepository.DeleteAsync(userId);
        }
    }
}
