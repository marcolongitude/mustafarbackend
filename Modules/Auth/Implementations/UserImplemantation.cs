using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using mustafarbackend.Context;
using mustafarbackend.Modules.Users.Entities;
using mustafarbackend.Repository;
using Mustafarbackend.Repository;

namespace mustafarbackend.Modules.Auth.Implementations
{
    public class UserImplementation : BaseRepository<UserEntity>, IUserRepository
    {
        private DbSet<UserEntity> _dataset;

        public UserImplementation(MyContext context) : base(context)
        {
            _dataset = context.Set<UserEntity>();
        }

        public async Task<UserEntity> FindByLogin(string email)
        {
            return await _dataset.FirstAsync(u => u.Email.Equals(email));
        }
    }
}