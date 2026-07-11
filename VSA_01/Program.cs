using VSA_01.Features.Users;
using VSA_01.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSingleton<UserDatabase>();
builder.Services.AddSingleton<CreateUserHandler>();
builder.Services.AddSingleton<GetUsersHandler>();


var app = builder.Build();

// Permitir http
// app.UseHttpsRedirection();

app.MapControllers();

app.Run();
