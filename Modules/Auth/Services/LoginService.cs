using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using mustafarbackend.Modules.Auth.Interfaces.Services;
using mustafarbackend.Modules.Auth.Dtos;
using Mustafarbackend.Repository;
using mustafarbackend.Modules.Users.Entities;
using Security;
using mustafarbackend.Modules.Auth.Interfaces;

namespace mustafarbackend.Modules.Auth.Services
{


    public class LoginService //: IAuthenticateService
    {
        private readonly ILoginRepository _loginRepository;
        private readonly SigningConfigurations _signingConfigurations;
        private IConfiguration _configuration { get; }

        public LoginService(ILoginRepository loginRepository, SigningConfigurations signingConfigurations, IConfiguration configuration)
        {
            _loginRepository = loginRepository;
            _signingConfigurations = signingConfigurations;
            _configuration = configuration;
        }

        // public async Task<object> Authenticate(AuthenticateDto authenticate)
        // {
        //     if (string.IsNullOrWhiteSpace(authenticate.Email) || string.IsNullOrEmpty(authenticate.Password))
        //     {
        //         return new
        //         {
        //             authenticated = false,
        //             message = "Falha ao atenticar"
        //         };
        //     };

        //     UserEntity baseUser = new UserEntity();

        //     baseUser = await _loginRepository.Login(authenticate.Email);
        // }
    }
}


