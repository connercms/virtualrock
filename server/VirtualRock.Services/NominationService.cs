using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VirtualRock.Core.Models;
using VirtualRock.Core.Services;
using VirtualRock.Core.Repositories;

namespace VirtualRock.Services
{
    public class NominationService : INominationService
    {
        private readonly INominationRepository _nominationRepository;

        public NominationService(INominationRepository nominationRepository)
        {
            _nominationRepository = nominationRepository;
        }

        public async Task<Nomination> CreateNomination(Nomination nomination)
        {
            await _nominationRepository.AddAsync(nomination);

            await _nominationRepository.SaveChangesAsync();

            return nomination;
        }

        public async Task DeleteNomination(Nomination nomination)
        {
            _nominationRepository.Remove(nomination);

            await _nominationRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<Nomination>> GetAllWithUser()
        {
            return await _nominationRepository.GetAllWithUserAsync();
        }

        public async Task<Nomination> GetNominationById(int id)
        {
            return await _nominationRepository.GetWithUserByIdAsync(id);
        }

        public async Task<IEnumerable<Nomination>> GetNominationsByUserId(int userId)
        {
            return await _nominationRepository.GetAllWithUserByUserIdAsync(userId);
        }

        public async Task UpdateNomination(Nomination nominationToBeUpdated, Nomination nomination)
        {
            nominationToBeUpdated.ExpirationDate = nomination.ExpirationDate;

            await _nominationRepository.SaveChangesAsync();
        }
    }
}
