using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mustafarbackend.Modules.Users.Entities;
using Mustafarbackend.Repository;

namespace mustafarbackend.Modules.Auth.Interfaces
{
    public interface ILoginRepository
    {
        Task<UserEntity> Login(string email);
    }
}