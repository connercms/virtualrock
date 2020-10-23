using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VirtualRock.Core.Models;
using VirtualRock.Core.Services;
using VirtualRock.Core.Repositories;

namespace VirtualRock.Services
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> CreateUser(User user)
        {
            await _userRepository.AddAsync(user);

            await _userRepository.SaveChangesAsync();

            return user;
        }

        public async Task DeleteUser(User user)
        {
            _userRepository.Remove(user);

            await _userRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _userRepository.GetAllAsync();
        }

        public async Task<User> GetUserById(int id)
        {
            return await _userRepository.GetByIdAsync(id);
        }

        public async Task UpdateUser(User userToBeUpdated, User user)
        {
            userToBeUpdated.Name = user.Name;
            userToBeUpdated.Email = user.Email;

            await _userRepository.SaveChangesAsync();
        }
    }
}
