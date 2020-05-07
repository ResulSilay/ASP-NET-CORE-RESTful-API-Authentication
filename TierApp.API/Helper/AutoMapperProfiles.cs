using AutoMapper;
using TierApp.Entity.Models;
using TierApp.Core.DTOs;

namespace TierApp.API.Helper
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<UserLoginDto, User>();
            CreateMap<UserRegisterDto, User>();
            CreateMap<UserProfileDto, User>();
            CreateMap<User, UserProfileDto>();
        }
    }
}