namespace MeetupAPI.Repositories.UnitOfWork
{
    public class MeetupUnitOfWork : UnitOfWork
    {
        public MeetupUnitOfWork(MeetupDbContext meetupDbContext)
            : base(meetupDbContext)
        {
        }
    }
}
