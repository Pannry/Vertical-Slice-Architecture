using Microsoft.AspNetCore.Mvc;
using VSA_02.Core.Features.Users;

namespace VSA_02.WebApi.Features.Users
{
    [ApiController]
    [Route("api/v1/user")]
    public class CreateUserEndpoint : ControllerBase
    {
        private readonly CreateUserHandler _handler;

        public CreateUserEndpoint(CreateUserHandler handler)
        {
            _handler = handler;
        }

        [HttpPost]
        public async Task<IActionResult> HandleAsync([FromBody] CreateUserCommand command)
        {
            var userId = _handler.Handle(command);
            return Ok(new { Id = userId });
        }
    }
}
