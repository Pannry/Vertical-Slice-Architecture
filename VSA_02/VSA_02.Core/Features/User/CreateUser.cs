using VSA_02.Core.Models;

namespace VSA_02.Core.Features.Users
{
    public class CreateUserCommand
    {
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }
    }

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

            var user = new User
            {
                Id = _db.Users.Count + 1,
                Name = command.Name,
                Age = command.Age
            };

            _db.Users.Add(user);
            return user.Id;
        }
    }
}
