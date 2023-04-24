using Microsoft.AspNetCore.Mvc;
using mustafarbackend.Middlewares.ErrorHandling;
using Mustafarbackend.Modules.Users.Dtos;
using Mustafarbackend.Modules.Users.Interfaces.Services;

namespace Api.Application.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            return Ok(await _service.GetAll());
        }

        [HttpGet]
        [Route("{id}", Name = "GetWithId")]
        public async Task<ActionResult> Get(Guid id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var response = await _service.Get(id);

            if (response is null)
            {
                throw new NotFoundException($"A user from the database with id: {id} could not be found.");
            }

            return Ok(await _service.Get(id));
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] UserDtoCreate user)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            UserDtoCreateResult result = await _service.Post(user);

            // var url = new Uri(Url.Link("GetWithId", new {id = result.Id}));
            return CreatedAtAction(nameof(_service.Post), result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(await _service.Delete(id));
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] UserDtoUpdate user)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var result = await _service.Put(user);
            if (result is null)
            {
                throw new NotFoundException($"A user from the database with id: {user.Id} could not be found.");
            }

            return Ok(result);
        }
    }
}