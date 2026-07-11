using Microsoft.AspNetCore.Mvc;
using VSA_02.Core.Features.Users;

namespace VSA_02.WebApi.Features.Users
{
    [ApiController]
    [Route("api/v1/user/{id}")]
    public class GetUserEndpoint : ControllerBase
    {
        private readonly GetUserHandler _handler;

        public GetUserEndpoint(GetUserHandler handler)
        {
            _handler = handler;
        }

        [HttpGet]
        public async Task<IActionResult> HandleAsync(int id)
        {
            var user = _handler.Handle(id);
            return Ok(new { user.Name, user.Age });
        }
    }
}
