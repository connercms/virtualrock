using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VirtualRock.Domain.Communication;
using VirtualRock.Domain.Models;
using VirtualRock.Domain.Repositories;
using VirtualRock.Domain.Services;

namespace VirtualRock.Services
{
    public class NominationService: INominationService
    {
        private readonly IUnitOfWork _unitOfWork;

        public NominationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<SaveResponse<Nomination>> AddAsync(Nomination entity)
        {
            throw new NotImplementedException();
        }

        public Task<SaveResponse<Nomination>> DeleteAsync(Nomination entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Nomination>> GetAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Nomination> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Nomination> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<SaveResponse<Nomination>> UpdateAsync(int id, Nomination entity)
        {
            throw new NotImplementedException();
        }

        public Task<SaveResponse<Nomination>> UpdateAsync(Guid id, Nomination entity)
        {
            throw new NotImplementedException();
        }
    }
}
