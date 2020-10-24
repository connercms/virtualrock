using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VirtualRock.Domain.Communication;
using VirtualRock.Domain.Models;

namespace VirtualRock.Domain.Services
{
    public interface IService<T>
    {
        Task<IEnumerable<T>> GetAsync();
        Task<T> GetByIdAsync(int id);
        Task<T> GetByIdAsync(Guid id);
        Task<SaveResponse<T>> AddAsync(T entity);
        Task<SaveResponse<T>> DeleteAsync(T entity);
        Task<SaveResponse<T>> UpdateAsync(int id, T entity);
        Task<SaveResponse<T>> UpdateAsync(Guid id, T entity);
    }
}
