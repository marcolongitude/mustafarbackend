using Microsoft.EntityFrameworkCore;
using mustafarbackend.Entity;
using mustafarbackend.Context;

namespace Mustafarbackend.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly MyContext _context;
        private DbSet<T> _dataset;
        public BaseRepository(MyContext context)
        {
            _context = context;
            _dataset = _context.Set<T>();
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            try
            {
                var result = await _dataset.SingleOrDefaultAsync(p => p.Id.Equals(id));
                if (result == null) return false;

                _dataset.Remove(result);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public async Task<T> InsertAsync(T item)
        {
            if (item.Id == Guid.Empty)
            {
                item.Id = Guid.NewGuid();
            }
            item.CreateAt = DateTime.UtcNow;

            _dataset.Add(item);

            await _context.SaveChangesAsync();

            return item;
        }

        public async Task<T> SelectAsync(Guid id)
        {
            var result = await _dataset.SingleOrDefaultAsync<T>(p => p.Id.Equals(id));
            return result!;
        }

        public async Task<IEnumerable<T>> SelectAsync()
        {
            return await _dataset.AsQueryable().ToArrayAsync();
        }

        public async Task<T> UpdateAsync(T item)
        {
            var result = await _dataset.SingleOrDefaultAsync(p => p.Id.Equals(item.Id));

            item.UpdateAt = DateTime.UtcNow;
            item.CreateAt = result.CreateAt;

            _context.Entry(result).CurrentValues.SetValues(item);
            await _context.SaveChangesAsync();

            return item;
        }

        public async Task<bool> ExistAsync(Guid id)
        {
            return await _dataset.AnyAsync(p => p.Id.Equals(id));
        }
    }
}