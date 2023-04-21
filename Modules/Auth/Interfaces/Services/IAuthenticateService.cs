using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mustafarbackend.Modules.Auth.Dtos;
using mustafarbackend.Modules.Users.Entities;

namespace mustafarbackend.Modules.Auth.Interfaces.Services
{
    public interface IAuthenticateService
    {
        Task<object> Authenticate(AuthenticateDto authenticate);
    }
}