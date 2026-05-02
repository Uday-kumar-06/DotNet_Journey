using GameStore.Api.Dtos;


var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

const string GetGameEndpointName = "GetGame";

List<GameDto> games = [
    new GameDto(1,"spider"," Advanture",19.99M, new DateOnly(1992, 7, 15)),
    new GameDto(2,"ninja"," climb",10.99M, new DateOnly(1928, 3, 25)),
    new GameDto(3,"Temple"," running",19.89M, new DateOnly(1992, 10, 1)),
    new GameDto(4,"subway"," running",15.99M, new DateOnly(1954, 7, 5))
];
// GET /games
app.MapGet("/games", () => games);

//GET /games/1
app.MapGet("/games/{id}", (int id) =>games.Find(game => game.Id == id))
    .WithName(GetGameEndpointName);

// POST /games
app.MapPost("/games", (CreateGameDto newGame) =>
{
    GameDto gameDto = new(
        games.Count + 1,
        newGame.Name,
        newGame.Genre,
        newGame.Price,
        newGame.ReleaseDate
    );

    games.Add(gameDto);

    return Results.CreatedAtRoute(GetGameEndpointName, new {id = gameDto.Id}, gameDto);
});


app.MapPut("/games/{id}", (int id, UpdateGameDto updatedGame) =>
{
  var index = games.FindIndex(game => game.Id == id); 
  games[index] = new GameDto(
    id,
    updatedGame.Name,
    updatedGame.Genre,
    updatedGame.Price,
    updatedGame.ReleaseDate
  );

  return Results.NoContent();
});

app.Run();
