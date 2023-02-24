using AutoMapper;
using mustafarbackend.Modules.Users.Entities;
using Mustafarbackend.Modules.Users.Dtos;

namespace mustafarbackend.Mappings
{
    public class EntityToDtoProfile : Profile
    {
        public EntityToDtoProfile()
        {
            CreateMap<UserDto, UserEntity>().ReverseMap();
            CreateMap<UserDtoCreateResult, UserEntity>().ReverseMap();
            CreateMap<UserDtoUpdateResult, UserEntity>().ReverseMap();
        }
    }
}