using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mustafarbackend.Modules.Auth.Dtos;

namespace mustafarbackend.Modules.Auth.Interfaces.Services
{
    public interface IAuthenticateService
    {
        Task<object> Authenticate(AuthenticateDto authenticate);
    }
}