using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VirtualRock.Core.Models;

namespace VirtualRock.Core.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllUsers();
        Task<User> GetUserById(int id);
        Task<User> CreateUser(User user);
        Task UpdateUser(User userToBeUpdated, User user);
        Task DeleteUser(User user);
    }
}
