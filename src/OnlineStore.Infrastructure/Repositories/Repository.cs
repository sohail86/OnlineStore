using Microsoft.EntityFrameworkCore;
using OnlineStore.Domain.Repositories;
using OnlineStore.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly StoreContext _storeContext;
        public Repository(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _storeContext.Set<T>().ToListAsync();
        }
        public async Task<T> GetByIdAsync(int id)
        {
            return await _storeContext.Set<T>().FindAsync(id);
        }
        public async Task<T> AddAsync(T entity)
        {
            await _storeContext.Set<T>().AddAsync(entity);
            await _storeContext.SaveChangesAsync();
            return entity;
        }
        public async Task<T> DeleteAsync(T entity)
        {
            _storeContext.Set<T>().Remove(entity);
            await _storeContext.SaveChangesAsync();
            return entity;
        }
        public async Task<T> UpdateAsync(T entity)
        {
            _storeContext.Set<T>().Update(entity);
            await _storeContext.SaveChangesAsync();
            return entity;
        }

    }
}
