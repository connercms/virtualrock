using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VirtualRock.Core.Models;

namespace VirtualRock.Core.Services
{
    public interface INominationService
    {
        Task<IEnumerable<Nomination>> GetAllWithUser();
        Task<Nomination> GetNominationById(int id);
        Task<IEnumerable<Nomination>> GetNominationsByUserId(int userId);
        Task<Nomination> CreateNomination(Nomination nomination);
        Task UpdateNomination(Nomination nominationToBeUpdated, Nomination nomination);
        Task DeleteNomination(Nomination nomination);
    }
}
