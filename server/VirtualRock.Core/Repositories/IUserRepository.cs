using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VirtualRock.Core.Models;

namespace VirtualRock.Core.Repositories
{
    public interface IUserRepository: IRepository<User>
    {
        Task<IEnumerable<User>> GetAllWithNominationsAsync();
        Task<User> GetWithNominationsByIdAsync(int id);
    }
}
