using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Mustafarbackend.Modules.Users.Dtos;

namespace Mustafarbackend.Modules.Users.Interfaces.Services
{
    public interface IUserService
    {
        Task<UserDto> Get(Guid id);
        Task<IEnumerable<UserDto>> GetAll();
        Task<UserDtoCreateResult> Post(UserDtoCreate user);
        Task<UserDtoUpdateResult> Put(UserDtoUpdate user);
        Task<bool> Delete(Guid id);
    }
}