using GameStore.Api.Data;
using GameStore.Api.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddValidation();
//Dependency Injection
builder.AddGameStoreDb();

//Data migration commands:
// --> dotnet ef migrations add InitialCreate
// --> dotnet ef database update
var app = builder.Build();

app.MapGamesEndpoints();

app.MigrateDb();

app.Run();
