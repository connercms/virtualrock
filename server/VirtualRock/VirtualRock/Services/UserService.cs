using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VirtualRock.Domain.Communication;
using VirtualRock.Domain.Models;
using VirtualRock.Domain.Repositories;
using VirtualRock.Domain.Services;

namespace VirtualRock.Services
{
    public class UserService: IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<SaveResponse<User>> AddAsync(User entity)
        {
            throw new NotImplementedException();
        }

        public Task<SaveResponse<User>> DeleteAsync(User entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetAsync()
        {
            throw new NotImplementedException();
        }

        public Task<User> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<SaveResponse<User>> UpdateAsync(int id, User entity)
        {
            throw new NotImplementedException();
        }

        public Task<SaveResponse<User>> UpdateAsync(Guid id, User entity)
        {
            throw new NotImplementedException();
        }
    }
}
