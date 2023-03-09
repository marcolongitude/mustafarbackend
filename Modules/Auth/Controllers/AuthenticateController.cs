using Microsoft.AspNetCore.Mvc;
using mustafarbackend.Middlewares.ErrorHandling;
using mustafarbackend.Modules.Auth.Dtos;
using mustafarbackend.Modules.Auth.Interfaces.Services;

namespace mustafarbackend.Modules.Auth.Controllers
{
    public class AuthenticateController : ControllerBase
    {

        [HttpPost]
        public async Task<ActionResult> Authenticate([FromBody] AuthenticateDto authenticateDto, [FromServices] IAuthenticateService service)
        {

            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (authenticateDto is null)
            {
                throw new NotFoundException($"Informe seu usuário e senha.");
            }

            var result = await service.Authenticate(authenticateDto);

            if (result is null)
            {
                throw new NotFoundException($"Usuário ou senha incorretos");
            }

            return Ok(result);
        }
    }
}