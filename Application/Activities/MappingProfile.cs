using System.Linq;
using AutoMapper;
using Domain;

namespace Application.Activities
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Activity, ActivityDto>();
            CreateMap<UserActivity, AttendeeDto>()
            .ForMember(d => d.Username, opt => opt.MapFrom(s => s.AppUser))
            .ForMember(d => d.DisplayName, opt => opt.MapFrom(s => s.AppUser.DisplayName))
            .ForMember(d => d.Image, opt => 
            opt.MapFrom(s => s.AppUser.Photos.FirstOrDefault(x => x.IsMain).Url));
        }
    }
}