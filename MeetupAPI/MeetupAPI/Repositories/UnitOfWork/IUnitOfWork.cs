using MeetupAPI.Repositories.Repository;

namespace MeetupAPI.Repositories.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task CommitAsync();

        Repository<T> GetRepository<T>() where T : class;
    }
}
