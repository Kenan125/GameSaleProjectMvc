using System.Linq.Expressions;

namespace GameSaleProject_Entity.Interfaces
{
    public interface IRepository<T> where T : class
    {

        Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null, params Expression<Func<T, object>>[] includes);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<T> Get(Expression<Func<T, bool>> filter);

        Task Add(T entity);
        void Update(T entity);
        void Delete(int id);
        void Delete(T entity);
    }
}