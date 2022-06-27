using MeetupAPI.Models;
using MeetupAPI.Repositories.UnitOfWork;
using MeetupAPI.Services.Interfaces;

namespace MeetupAPI.Services
{
    public class MeetupService : IMeetupService
    {
        private IUnitOfWork _unitOfWork;


        public MeetupService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task<List<Meetup>> GetAllMeetupsAsync()
        {
            return (await _unitOfWork.GetRepository<Meetup>().All()).ToList();
        }

        public async Task<Meetup?> GetMeetupByIdAsync(Guid id)
        {
            return await _unitOfWork.GetRepository<Meetup>().GetById(id);
        }

        public async Task UpdateMeetupAsync(Meetup meetup)
        {
            _unitOfWork.GetRepository<Meetup>().Update(meetup);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteMeetupAsync(Meetup meetup)
        {
            _unitOfWork.GetRepository<Meetup>().Delete(meetup);
            await _unitOfWork.CommitAsync();
        }

        public async Task AddMeetupAsync(Meetup meetup)
        {
            await _unitOfWork.GetRepository<Meetup>().Add(meetup);
            await _unitOfWork.CommitAsync();
        }
    }
}
