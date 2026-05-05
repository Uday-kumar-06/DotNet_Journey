using GameStore.Api.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddValidation();
//Dependency Injection
var connString = "Data Source=GameStore.db";
builder.Services.AddSqlite<GameStoreContext>(connString);
var app = builder.Build();

app.MapGamesEndpoints();

app.Run();
