using AutoMapper;
using Mustafarbackend.Modules.Users.Dtos;
using Mustafarbackend.Modules.Users.Models;

namespace mustafarbackend.Mappings
{
    public class DtoToModelProfile : Profile
    {
        public DtoToModelProfile()
        {
            CreateMap<UserModel, UserDto>().ReverseMap();
            CreateMap<UserModel, UserDtoCreate>().ReverseMap();
            CreateMap<UserModel, UserDtoUpdate>().ReverseMap();
        }
    }
}