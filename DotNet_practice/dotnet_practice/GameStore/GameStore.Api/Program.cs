using GameStore.Api.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddValidation();
//Dependency Injection
var connString = "Data Source=GameStore.db";
builder.Services.AddSqlite<GameStoreContext>(connString);

//Data migration commands:
// --> dotnet ef migrations add InitialCreate
// --> dotnet ef database update
var app = builder.Build();

app.MapGamesEndpoints();

app.MigrateDb();

app.Run();
