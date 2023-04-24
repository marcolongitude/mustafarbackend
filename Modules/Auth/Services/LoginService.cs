using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using Microsoft.IdentityModel.Tokens;
using mustafarbackend.Modules.Auth.Dtos;
using mustafarbackend.Modules.Auth.Interfaces.Services;
using mustafarbackend.Modules.Users.Entities;
using mustafarbackend.Repository;
using Security;
// using BC = BCrypt.Net.BCrypt;
using Mustafarbackend.Utils.Functions;


namespace Services
{
    public class LoginService : IAuthenticateService
    {

        private readonly IUserRepository _repository;
        private readonly SigningConfigurations _signingConfigurations;
        private IConfiguration _configuration { get; }

        public LoginService(
            IUserRepository repository,
            SigningConfigurations signingConfigurations,
            IConfiguration configuration
        )
        {
            _repository = repository;
            _signingConfigurations = signingConfigurations;
            _configuration = configuration;
        }

        public async Task<object> Authenticate(AuthenticateDto user)
        {
            if (string.IsNullOrWhiteSpace(user.Email) || string.IsNullOrEmpty(user.Password))
            {
                return new
                {
                    authenticated = false,
                    message = "Falha ao atenticar"
                };
            };

            UserEntity baseUser = new UserEntity();

            baseUser = await _repository.FindByLogin(user.Email);
            if (baseUser == null)
            {
                return new
                {
                    authenticated = false,
                    message = "Usuário não encontrado"
                };
            }
            bool passwordVerified = PasswordHashed.VerifyHashedPassword(baseUser.Password, user.Password);
            if (!passwordVerified)
            {
                return new
                {
                    authenticated = false,
                    message = "Senha incorreta"
                };
            }
            ClaimsIdentity identity = new ClaimsIdentity(
                new GenericIdentity(baseUser.Email),
                new[]
                {
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                        new Claim(JwtRegisteredClaimNames.Sid, baseUser.Id.ToString()),
                        new Claim(ClaimTypes.Role, baseUser.Permission.ToString()),
                }
            );

            DateTime createDate = DateTime.Now;
            // var envDays = Environment.GetEnvironmentVariable("DAYS");
            var envDays = 1;
            var expirationDateConvert = Convert.ToInt32(envDays);
            DateTime expirationDate = createDate + TimeSpan.FromDays(expirationDateConvert);
            var handler = new JwtSecurityTokenHandler();
            string token = CreateToken(identity, createDate, expirationDate, handler);
            return SuccessObject(createDate, expirationDate, token, baseUser);
        }

        private string CreateToken(ClaimsIdentity identity, DateTime createDate, DateTime expirationDate, JwtSecurityTokenHandler handler)
        {
            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = Environment.GetEnvironmentVariable("Issuer"),
                Audience = Environment.GetEnvironmentVariable("Audience"),
                SigningCredentials = _signingConfigurations.SigningCredentials,
                Subject = identity,
                NotBefore = createDate,
                Expires = expirationDate,
            });

            string token = handler.WriteToken(securityToken);
            return token;
        }

        private object SuccessObject(DateTime createDate, DateTime expirationDate, string token, UserEntity user)
        {
            return new
            {
                authenticated = true,
                created = createDate.ToString("yyyy-MM-dd HH:mm:ss"),
                expiration = expirationDate.ToString("yyyy-MM-dd HH:mm:ss"),
                accessToken = token,
                user = new
                {
                    userEmail = user.Email,
                    userName = user.Name,
                },
                message = "Usuário logado com sucesso",
            };
        }

    }
}

