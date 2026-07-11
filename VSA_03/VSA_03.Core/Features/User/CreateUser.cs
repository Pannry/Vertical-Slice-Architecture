using VSA_03.Core.Models;

namespace VSA_03.Core.Features.Users
{
    public class CreateUserCommand
    {
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }
    }

    public class CreateUserHandler
    {
        private readonly IUserRepository _repo;

        public CreateUserHandler(IUserRepository repo)
        {
            _repo = repo;
        }

        public async Task<int> HandleAsync(CreateUserCommand command)
        {
            if (string.IsNullOrEmpty(command.Name))
                throw new ArgumentException("Nome é obrigatório");

            var user = new User
            {
                Name = command.Name,
                Age = command.Age
            };

            return await _repo.CreateAsync(user);
        }
    }
}
