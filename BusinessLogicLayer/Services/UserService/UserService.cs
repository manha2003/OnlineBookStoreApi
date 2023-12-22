using AutoMapper;
using DataAccessLayer;
using DataAccessLayer.Models;
using BusinessLogicLayer.Validator;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccessLayer.IRepository;
using BusinessLogicLayer.DTOs.UserDTO;

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

        public async Task<UserDTODetails> GetUserByIdAsync(int userId)
        {
            var userEntity = await _userRepository.GetByIdAsync(userId);
            return _mapper.Map<UserDTODetails>(userEntity);
        }

        public async Task<List<UserDTODetails>> GetAllUsersAsync()
        {
            var userEntities = await _userRepository.GetAllAsync();
            return _mapper.Map<List<UserDTODetails>>(userEntities);
        }

        public async Task AddUserAsync(UserDTODetails userDTO)
        {
            var userEntity = _mapper.Map<User>(userDTO);
            await _userRepository.AddAsync(userEntity);
        }

        public async Task UpdateUserAsync(UserDTODetails userDTO)
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

        public async Task<bool> IsPhoneNumberUniqueAsync(string phoneNumber)
        {
            return !(await _userRepository.GetAllAsync()).Any(u => u.UserPhoneNumber == phoneNumber);
        }

        public async Task<bool> IsAddressUniqueAsync(string address)
        {
            return !(await _userRepository.GetAllAsync()).Any(u => u.UserAddress == address);
        }

        public async Task<bool> IsEmailUniqueAsync(string email)
        {

            return !(await _userRepository.GetAllAsync()).Any(u => u.UserEmail == email);
        }

    }
}
