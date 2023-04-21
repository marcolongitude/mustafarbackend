using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mustafarbackend.Modules.Users.Entities;
using Mustafarbackend.Repository;

namespace mustafarbackend.Repository
{
    public interface IUserRepository : IRepository<UserEntity>
    {
        Task<UserEntity> FindByLogin(string email);
    }
}