namespace App.Utils.EntityFrameworkCore.Core.BaseRepository
{
    public interface IBaseRepository<T, TContext> where T : class 
                                                     where TContext : DbContext
    {
        /// <summary>
        /// Add a new Entity
        /// </summary>
        /// <param name="entity">generic class</param>
        Task<T?> Add(T entity);

        /// <summary>
        /// Add a new list of items
        /// </summary>
        /// <param name="listItems">list of items of type T</param>
        /// <returns>Lists of object T Inserted</returns>
        Task<List<T>?> AddList(List<T> listItems);

        /// <summary>
        /// Update an Entity
        /// </summary>
        /// <param name="entity">generic class</param>
        Task Update(T entity);

        /// <summary>
        /// Update a list of items
        /// </summary>
        /// <param name="listItems">list of items of type T</param>
        Task UpdateRange(List<T> listItems);

        /// <summary>
        /// Remove an Entity
        /// </summary>
        /// <param name="entity">generic class</param>
        Task Remove(T entity);

        /// <summary>
        /// Get a IQueryable type objects list according to an expression
        /// </summary>
        /// <param name="expression">Linq expression</param>
        /// <returns>IQueryable object</returns>
        IQueryable<T> Get(Expression<Func<T, bool>> expression);

        /// <summary>
        /// Get a IQueryable type objects list
        /// </summary>
        /// <returns>IQueryable object</returns>
        IQueryable<T> GetAsNoTracking();

        /// <summary>
        /// Get a IQueryable type objects list according to an expression but without tracking
        /// </summary>
        /// <param name="expression">Linq expression</param>
        /// <returns>IQueryable object</returns>
        IQueryable<T> GetAsNoTracking(Expression<Func<T, bool>> expression);

        /// <summary>
        /// Get an object by searching for its identification
        /// </summary>
        /// <param name="id">Identifier</param>
        /// <returns>IQueryable object</returns>
        Task<T?> FindById(int id);

        /// <summary>
        /// method for saving changes using entity framework tracking
        /// </summary>
        Task SaveChanges();

        Task AddListFromJsonFile(string urlFile);
    }
}
