using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ZxVentures.BackendChallenge.Application.Repository;
using ZxVentures.BackendChallenge.Infrastructure.Data;

namespace ZxVentures.BackendChallenge.Infrastructure
{
    public abstract class BaseRepository<T> : IBaseRepository<T>
            where T : class
    {
        readonly DatabaseContext databaseContext;

        public BaseRepository(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        protected IMongoCollection<T> GetCollection()
        {
            return databaseContext.GetDatabase().GetCollection<T>(typeof(T).Name);
        }

        public virtual async Task Add(T model)
        {
            await GetCollection().InsertOneAsync(model);
        }

        public virtual async Task AddRange(List<T> model)
        {
            await GetCollection().InsertManyAsync(model);
        }

        public virtual async Task<T> FirstOrDefault(Expression<Func<T, bool>> filter)
        {
            using (var cursor = await GetCollection().FindAsync(filter))
            {
                return await cursor.FirstOrDefaultAsync();
            }
        }

        public virtual async Task<List<T>> Find(Expression<Func<T, bool>> filter)
        {
            using (var cursor = await GetCollection().FindAsync(filter))
            {
                return await cursor.ToListAsync();
            }
        }

        public virtual async Task<List<T>> ToList()
        {
            using (var cursor = await GetCollection().FindAsync(t => true))
            {
                return await cursor.ToListAsync();
            }
        }

        public virtual async Task Replace(Expression<Func<T, bool>> filter, T model)
        {
            await GetCollection().ReplaceOneAsync(filter, model);
        }

        public virtual async Task Remove(Expression<Func<T, bool>> filter)
        {
            await GetCollection().DeleteOneAsync(filter);
        }

        public virtual async Task RemoveRange(Expression<Func<T, bool>> filter)
        {
            await GetCollection().DeleteManyAsync(filter);

            var x = new List<int>();
        }
    }
}
