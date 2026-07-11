using Microsoft.EntityFrameworkCore;
using VSA_03.Core.Features.Users;
using VSA_03.Core.Models;
using VSA_03.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

var dbPath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\..\\", "vsa03.db"));

builder.Services.AddControllers();
builder.Services.AddSingleton<AppDbContext>(_ =>
{
    var options = new DbContextOptionsBuilder<AppDbContext>()
        .UseSqlite($"Data Source={dbPath}")
        .Options;
    var ctx = new AppDbContext(options);
    ctx.Database.EnsureCreated();
    return ctx;
});
builder.Services.AddSingleton<IUserRepository, SqliteUserRepository>();
builder.Services.AddSingleton<CreateUserHandler>();
builder.Services.AddSingleton<GetUserHandler>();

var app = builder.Build();

app.MapControllers();

app.Run();
