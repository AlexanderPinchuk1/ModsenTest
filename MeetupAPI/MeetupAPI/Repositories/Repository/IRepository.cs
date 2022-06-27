using System.Linq.Expressions;

namespace MeetupAPI.Repositories.Repository
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> All();

        Task<T?> GetById(Guid id);

        Task Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate);
    }
}
