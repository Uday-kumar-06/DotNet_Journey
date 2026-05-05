using GameStore.Api.Data;
using GameStore.Api.Dtos;
using GameStore.Api.Models;

public static class GamesEndpoints
{

    const string GetGameEndpointName = "GetGame";
    private static readonly List<GameDto> games = [
        new GameDto(1,"spider"," Advanture",19.99M, new DateOnly(1992, 7, 15)),
        new GameDto(2,"ninja"," climb",10.99M, new DateOnly(1928, 3, 25)),
        new GameDto(3,"Temple"," running",19.89M, new DateOnly(1992, 10, 1)),
        new GameDto(4,"subway"," running",15.99M, new DateOnly(1954, 7, 5))
    ];

    public static void MapGamesEndpoints(this WebApplication app)
    {
        // GET /games
        app.MapGet("/games", () => games);

        //GET /games/1
        app.MapGet("/games/{id}", (int id) =>
        {
            var value =games.Find(game => game.Id == id);

            return value is null ? Results.NotFound(): Results.Ok(value);
        })
            .WithName(GetGameEndpointName);

        // POST /games
        app.MapPost("/games", (CreateGameDto newGame, GameStoreContext dbContext) =>
        {
            Game game = new()
            {
                Name = newGame.Name,
                GenreId = newGame.GenreId,
                Price = newGame.Price,
                ReleaseDate = newGame.ReleaseDate
            };

            dbContext.Games.Add(game);
            dbContext.SaveChanges();

            GameDetailsDTO gameDetailsDTO = new(
                game.Id,
                game.Name,
                game.GenreId,
                game.Price,
                game.ReleaseDate
            );

            return Results.CreatedAtRoute(GetGameEndpointName, new {id = gameDetailsDTO.Id}, gameDetailsDTO);
        });


        app.MapPut("/games/{id}", (int id, UpdateGameDto updatedGame) =>
        {
        var index = games.FindIndex(game => game.Id == id); 

        if(index == -1)
            {
                return Results.NotFound();
            }
        games[index] = new GameDto(
            id,
            updatedGame.Name,
            updatedGame.Genre,
            updatedGame.Price,
            updatedGame.ReleaseDate
        );

        return Results.NoContent();
        });

        //DELETE /games/1
        app.MapDelete("/games/{id}", (int id) =>
        {
            games.RemoveAll(game => game.Id == id);
            return Results.NoContent();
        });
    }
}