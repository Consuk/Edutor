using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BookSummary.Application.Dtos;
using BookSummary.Application.Interfaces;
using BookSummary.Domain.Entities;

namespace BookSummary.Application.Services
{
    public class UserService : IUserInterface
    {
        private readonly IRepository<User> _userRepository;
        private readonly IMapper _mapper;

        public UserService(IRepository<User> userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserDto> GetUserByIdAsync(int userId)
        {
            try
            {
                var user = await _userRepository.GetByIdAsync(userId);
                return _mapper.Map<UserDto>(user);
            }
            catch (Exception ex)
            {
                // Consider logging the exception here
                throw new ApplicationException($"Failed to retrieve user by ID: {userId}", ex);
            }
        }

        public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<UserDto>>(users);
        }

        public async Task<UserDto> CreateUserAsync(UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            var result = await _userRepository.AddAsync(user);
            return _mapper.Map<UserDto>(result);
        }

        public async Task UpdateUserAsync(UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            await _userRepository.UpdateAsync(user);
        }

        public async Task DeleteUserAsync(int userId)
        {
            try
            {
                var user = await _userRepository.GetByIdAsync(userId);
                if (user != null)
                {
                    await _userRepository.DeleteAsync(user);
                }
            }
            catch (Exception ex)
            {
                // Consider logging the exception here
                throw new ApplicationException($"Failed to delete user with ID: {userId}", ex);
            }
        }
    }
}
