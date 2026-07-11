using Microsoft.AspNetCore.Mvc;
using VSA_03.Core.Features.Users;

namespace VSA_03.WebApi.Features.Users
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
            var user = await _handler.HandleAsync(id);

            if (user is null)
                return NotFound(new { Message = "Usuário não encontrado" });

            return Ok(new { user.Name, user.Age });
        }
    }
}
