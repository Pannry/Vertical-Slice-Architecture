using Microsoft.EntityFrameworkCore;
using VSA_03.Core.Features.Users;
using VSA_03.Core.Models;
using VSA_03.Infrastructure;

var dbPath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\..\\", "vsa03.db"));

var options = new DbContextOptionsBuilder<AppDbContext>()
    .UseSqlite($"Data Source={dbPath}")
    .Options;

using var db = new AppDbContext(options);
db.Database.EnsureCreated();

IUserRepository repo = new SqliteUserRepository(db);
var createHandler = new CreateUserHandler(repo);
var getHandler = new GetUserHandler(repo);

while (true)
{
    Console.WriteLine("\n--- CLI User Manager (SQLite) ---");
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
                var id = await createHandler.HandleAsync(new CreateUserCommand { Name = name, Age = age });
                Console.WriteLine($"Usuário criado com Id: {id}");
                break;

            case "2":
                Console.Write("Id: ");
                var userId = int.Parse(Console.ReadLine() ?? "0");
                var user = await getHandler.HandleAsync(userId);
                if (user is null)
                    Console.WriteLine("Usuário não encontrado");
                else
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
