using Mariusz.Piotrowski.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Mariusz.Piotrowski.Application.Interfaces.IRepository
{
    public interface IRepository<T> where T : class
    {
        Task<T?> GetByIdAsync(Guid id);
        Task<IEnumerable<T>> GetAllAsync();
        Task AddAsync(T entity);
        void Update(T entity);
        void DeleteById(T entity);
        Task<bool> ExistsAsync(Guid id);
        Task<IEnumerable<Article>> FindAsync(Expression<Func<T, bool>> predicate);
    }
}
