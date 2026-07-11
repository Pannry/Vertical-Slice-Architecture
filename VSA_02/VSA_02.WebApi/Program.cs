using VSA_02.Core.Features.Users;
using VSA_02.Core.Models;
using VSA_02.WebApi.Features.Users;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSingleton<UserDatabase>();
builder.Services.AddSingleton<CreateUserHandler>();
builder.Services.AddSingleton<GetUserHandler>();
builder.Services.AddSingleton<CreateUserEndpoint>();
builder.Services.AddSingleton<GetUserEndpoint>();

var app = builder.Build();

app.MapControllers();

app.Run();
