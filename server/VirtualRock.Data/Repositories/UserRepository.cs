using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using VirtualRock.Core.Models;
using VirtualRock.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace VirtualRock.Data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(VirtualRockDataContext context) : base(context)
        {
        }
        public async Task<IEnumerable<User>> GetAllWithNominationsAsync()
        {
            return await VirtualRockDataContext.Users.Include(x => x.Nominations).ToListAsync();
        }

        public async Task<User> GetWithNominationsByIdAsync(int id)
        {
            return await VirtualRockDataContext.Users.Include(x => x.Nominations).SingleOrDefaultAsync(x => x.Id == id);
        }
    }
}
