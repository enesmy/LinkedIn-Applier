using LinkedIn_Applier.DataAccess.Abstract;
using LinkedIn_Applier.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LinkedIn_Applier.DataAccess.Concrete
{
    public class GenericRepository<T> : IAsyncRepository<T> where T : class
    {
        private DbContext _context = null;
        private DbSet<T> table = null;


        public GenericRepository(DbContext context)
        {
            this._context = context;
            table = _context.Set<T>();
        }

        public async Task<int> SaveChanges()
        {
            var res = await _context.SaveChangesAsync();
            return res;
        }

        public async Task<T> GetByPrimaryKey(object id)
        {
            return await table.FindAsync(id);
        }

        public async Task<T> FirstOrDefault(Expression<Func<T, bool>> predicate)
        {
            var result = await table.FirstOrDefaultAsync<T>(predicate);
            return result;
        }

        async Task IAsyncRepository<T>.Add(T entity)
        {

            await table.AddAsync(entity);
            await SaveChanges();
        }

        public async Task Update(T entity)
        {
            table.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await SaveChanges();
        }

        public async Task Remove(int entityID)
        {
            T existing = await table.FindAsync(entityID);
            if (existing is BaseEntity x)
            {
                x.IsDeleted = true;
                x.DeleteDateTime = DateTime.Now;
            }
            await Update(existing);
        }

        public async Task HardRemove(int entityID)
        {
            T existing = await table.FindAsync(entityID);
            table.Remove(existing);
            await SaveChanges();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            var res = await table.ToListAsync();
            return res;
        }

        public async Task<IEnumerable<T>> GetAllWithNoTrack()
        {
            var res = await table.AsNoTracking().ToListAsync();
            return res;
        }

        public async Task<IEnumerable<T>> GetWhere(Expression<Func<T, bool>> predicate)
        {
            var res = await table.Where(predicate).ToListAsync();
            return res;
        }

        public async Task<IEnumerable<T>> GetWhereWithNoTrack(Expression<Func<T, bool>> predicate)
        {
            var res = await table.AsNoTracking().Where(predicate).ToListAsync();
            return res;
        }

        public async Task<int> CountAll()
        {
            var res = await table.AsNoTracking().CountAsync();
            return res;
        }

        public async Task<int> CountWhere(Expression<Func<T, bool>> predicate)
        {
            var res = await table.AsNoTracking().CountAsync(predicate);
            return res;
        }
    }
}
