namespace App.Utils.EntityFrameworkCore.Core.BaseRepository
{
    public class BaseRepository<T, TContext> : IBaseRepository<T, TContext> where T : class
                                                                                  where TContext : DbContext
    {
        #region Properties

        protected readonly TContext _context;

        #endregion

        #region Constructor

        public BaseRepository(TContext context)
        {
            _context = context;
        }

        #endregion

        #region Implementation IGenericRepository

        public async Task<T?> Add(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<List<T>?> AddList(List<T> listItems)
        {
            await _context.Set<T>().AddRangeAsync(listItems);
            await _context.SaveChangesAsync();
            return listItems;
        }

        public async Task Update(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateRange(List<T> listItems)
        {
            _context.Set<T>().UpdateRange(listItems);
            await _context.SaveChangesAsync();
        }

        public async Task Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public IQueryable<T> Get(Expression<Func<T, bool>> expression) 
            => _context.Set<T>().Where(expression);

        public IQueryable<T> GetAsNoTracking(Expression<Func<T, bool>> expression) 
            => Get(expression).AsNoTracking();

        public IQueryable<T> GetAsNoTracking() => _context.Set<T>().AsNoTracking();

        public async Task<T?> FindById(int id) 
            => await _context.Set<T>().FindAsync(id);

        public async Task SaveChanges() 
            => await _context.SaveChangesAsync();

        #endregion
    }
}
