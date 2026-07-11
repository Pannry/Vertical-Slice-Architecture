using Microsoft.AspNetCore.Mvc;
using VSA_01.Models;

namespace VSA_01.Features
{
    // Contrato do que entra e sai (O Comando/Request e a Resposta)
    public class CreateUserCommand
    {
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; } = 0;
    }

    // O Manipulador (Regra de Negócio e Banco de Dados tudo na mesma fatia)
    public class CreateUserHandler
    {
        private readonly UserDatabase _db;

        public CreateUserHandler(UserDatabase db)
        {
            _db = db;
        }

        public int Handle(CreateUserCommand command)
        {
            if (string.IsNullOrEmpty(command.Name))
                throw new ArgumentException("Nome é obrigatório");
            
            User user = new User
            {
                Name = command.Name,
                Age = command.Age
            };

            // Atribuindo id de exemplo
            user.Id = _db.Users.Count + 1;
            _db.Users.Add(user);
            return user.Id;
        }
    }

    // A porta de entrada
    [ApiController]
    [Route("api/v1/user")]
    public class CreateUsertEndpoint : ControllerBase
    {
        private readonly CreateUserHandler _handler;

        public CreateUsertEndpoint(CreateUserHandler handler)
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