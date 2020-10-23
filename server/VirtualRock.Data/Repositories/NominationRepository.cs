using System;
using System.Linq;
using VirtualRock.Core.Repositories;
using VirtualRock.Core.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace VirtualRock.Data.Repositories
{
    public class NominationRepository: Repository<Nomination>, INominationRepository
    {
        public NominationRepository(VirtualRockDataContext context): base(context)
        {
        }
        public async Task<IEnumerable<Nomination>> GetAllWithUserAsync()
        {
            return await VirtualRockDataContext.Nominations.Include(x => x.User).ToListAsync();
        }

        public async Task<IEnumerable<Nomination>> GetAllWithUserByUserIdAsync(int userId)
        {
            return await VirtualRockDataContext.Nominations.Include(x => x.User).Where(x => x.Id == userId).ToListAsync();
        }

        public async Task<Nomination> GetWithUserByIdAsync(int id)
        {
            return await VirtualRockDataContext.Nominations.Include(x => x.User).SingleOrDefaultAsync(x => x.Id == id);
        }
    }
}
