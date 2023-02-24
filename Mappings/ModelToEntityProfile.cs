using AutoMapper;
using mustafarbackend.Modules.Users.Entities;
using Mustafarbackend.Modules.Users.Models;

namespace mustafarbackend.Mappings
{
    public class ModelToEntityProfile : Profile
    {
        public ModelToEntityProfile()
        {
            CreateMap<UserEntity, UserModel>().ReverseMap();
        }
    }
}