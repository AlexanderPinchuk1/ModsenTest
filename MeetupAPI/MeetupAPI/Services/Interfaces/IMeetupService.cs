using MeetupAPI.Models;

namespace MeetupAPI.Services.Interfaces
{
    public interface IMeetupService
    {
        Task<List<Meetup>> GetAllMeetupsAsync();

        Task<Meetup?> GetMeetupByIdAsync(Guid id);

        Task UpdateMeetupAsync(Meetup meetup);

        Task DeleteMeetupAsync(Meetup meetup);

        Task AddMeetupAsync(Meetup meetup);       
    }
}
