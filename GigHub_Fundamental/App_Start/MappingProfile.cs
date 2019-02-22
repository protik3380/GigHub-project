using AutoMapper;
using GigHub_Fundamental.Dto;
using GigHub_Fundamental.Models;

namespace GigHub_Fundamental.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<ApplicationUser, UserDto>();
            Mapper.CreateMap<Gig, GigDto>();
            Mapper.CreateMap<Notification, NotificationDto>();
        }
    }
}