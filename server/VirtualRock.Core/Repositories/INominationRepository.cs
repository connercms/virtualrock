using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VirtualRock.Core.Models;

namespace VirtualRock.Core.Repositories
{
    public interface INominationRepository: IRepository<Nomination>
    {
        Task<IEnumerable<Nomination>> GetAllWithUserAsync();
        Task<Nomination> GetWithUserByIdAsync(int id);
        Task<IEnumerable<Nomination>> GetAllWithUserByUserIdAsync(int userId);
    }
}
