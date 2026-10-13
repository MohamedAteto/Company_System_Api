using Company_System_Api.Data;
using Company_System_Api.Reposatories.Interface;
using Microsoft.EntityFrameworkCore;

namespace Company_System_Api.Reposatories.Implmentaion
{
    public class GenericRepo<T> : IGenericRepo<T> where T : class
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;
        public GenericRepo(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }


        public async Task Add(T entity)
        {
            if(entity is null)
                throw new ArgumentNullException(nameof(entity));
            
            await _dbSet.AddAsync(entity);

        }

        public async Task Delete(int id)
        {
            var item = await _dbSet.FindAsync(id);

            if (item is null)
                throw new ArgumentNullException("Not Good");

            _dbSet.Remove(item);
            

        }

        public async Task<List<T>> GetAllAsync()
        {
            var items = await _dbSet.ToListAsync();
            if (items is null)
                throw new ArgumentNullException(nameof(items));
            return items;
        }

        public async Task<T> GetByID(int id)
        {
            var item = await _dbSet.FindAsync(id);
            if (item is null)
                throw new ArgumentNullException(nameof(item));
            return item;
        }

        public async Task Update(int id, T entity)
        {
            var item = await _dbSet.FindAsync(id);
            if (item is null)
                throw new ArgumentNullException(nameof(item));

            _context.Entry(item).CurrentValues.SetValues(entity);

        }
    }
}
