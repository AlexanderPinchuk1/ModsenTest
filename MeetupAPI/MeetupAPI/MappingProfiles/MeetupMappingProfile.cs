using AutoMapper;
using MeetupAPI.Models;
using MeetupAPI.ViewModels;

namespace MeetupAPI.Profiles
{
    public class MeetupMappingProfile : Profile
    {
        public MeetupMappingProfile()
        {
            CreateMap<Meetup, MeetupViewModel>().ReverseMap();
        }
    }
}
