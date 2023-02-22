using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mustafarbackend.Modules.Users.Interfaces.Services;
using Mustafarbackend.Modules.Users.Services;

namespace Api.Application.Controllers
{
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;

        public UserController(){}

        public UserController(IUserService service)
        {
            _service = service;
        }

        public async Task<ActionResult> GetAll()
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                var teste = await _service.GetAll();
                return Ok(teste);
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

    }
}