using VSA_02.Core.Features.Users;
using VSA_02.Core.Models;

var db = new UserDatabase();
var createHandler = new CreateUserHandler(db);
var getHandler = new GetUserHandler(db);

while (true)
{
    Console.WriteLine("\n--- CLI User Manager ---");
    Console.WriteLine("1 - Criar usuário");
    Console.WriteLine("2 - Buscar usuário por ID");
    Console.WriteLine("0 - Sair");
    Console.Write("Escolha: ");

    var choice = Console.ReadLine();

    if (choice == "0") break;

    try
    {
        switch (choice)
        {
            case "1":
                Console.Write("Nome: ");
                var name = Console.ReadLine() ?? "";
                Console.Write("Idade: ");
                var age = int.Parse(Console.ReadLine() ?? "0");
                var id = createHandler.Handle(new CreateUserCommand { Name = name, Age = age });
                Console.WriteLine($"Usuário criado com Id: {id}");
                break;

            case "2":
                Console.Write("Id: ");
                var userId = int.Parse(Console.ReadLine() ?? "0");
                var user = getHandler.Handle(userId);
                Console.WriteLine($"Nome: {user.Name}, Idade: {user.Age}");
                break;

            default:
                Console.WriteLine("Opção inválida");
                break;
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Erro: {ex.Message}");
    }
}
