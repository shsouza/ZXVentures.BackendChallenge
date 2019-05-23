using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ZxVentures.BackendChallenge.Application.Repository
{
    public interface IBaseRepository<T> where T : class
    {
        Task Add(T model);

        Task AddRange(List<T> model);

        Task<T> FirstOrDefault(Expression<Func<T, bool>> filter);

        Task<List<T>> Find(Expression<Func<T, bool>> filter);

        Task<List<T>> ToList();

        Task Replace(Expression<Func<T, bool>> filter, T model);

        Task Remove(Expression<Func<T, bool>> filter);

        Task RemoveRange(Expression<Func<T, bool>> filter);
    }
}
