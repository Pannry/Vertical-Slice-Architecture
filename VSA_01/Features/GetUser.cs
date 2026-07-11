using Microsoft.AspNetCore.Mvc;
using VSA_01.Models;

namespace VSA_01.Features
{
    // O Manipulador (Regra de Negócio e Banco de Dados tudo na mesma fatia)
    public class GetUsersHandler
    {
        private readonly UserDatabase _db;

        public GetUsersHandler(UserDatabase db)
        {
            _db = db;
        }

        public User Handle(int id)
        {
            if (id == 0)
                throw new ArgumentException("id é obrigatório");
            
            // await _db.User.Add(user);
            return _db.Users.First(x => x.Id == id);
        }
    }

    // A porta de entrada
    [ApiController]
    [Route("api/v1/user/{id}")]
    public class GetUsertEndpoint : ControllerBase
    {
        private readonly GetUsersHandler _handler;

        public GetUsertEndpoint(GetUsersHandler handler)
        {
            _handler = handler;
        }

        [HttpGet]
        public async Task<IActionResult> HandleAsync(int id)
        {
            User user = _handler.Handle(id);
            return Ok(new { user.Name, user.Age });
        }
    }
}