using GameStore.Api.Data;
using GameStore.Api.Dtos;
using GameStore.Api.Models;
using Microsoft.EntityFrameworkCore;

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
        app.MapGet("/games", async(GameStoreContext dbContext) => await dbContext.Games.ToListAsync());

        //GET /games/1
        app.MapGet("/games/{id}", async(int id, GameStoreContext dbContext) =>
        {
            var value = await dbContext.Games.FindAsync(id);

            return value is null ? Results.NotFound(): Results.Ok(new GameDetailsDTO(
                value.Id,
                value.Name,
                value.GenreId,
                value.Price,
                value.ReleaseDate
            ));
        })
            .WithName(GetGameEndpointName);

        // POST /games
        app.MapPost("/games", async(CreateGameDto newGame, GameStoreContext dbContext) =>
        {
            Game game = new()
            {
                Name = newGame.Name,
                GenreId = newGame.GenreId,
                Price = newGame.Price,
                ReleaseDate = newGame.ReleaseDate
            };

            dbContext.Games.Add(game);
            await dbContext.SaveChangesAsync();

            GameDetailsDTO gameDetailsDTO = new(
                game.Id,
                game.Name,
                game.GenreId,
                game.Price,
                game.ReleaseDate
            );

            return Results.CreatedAtRoute(GetGameEndpointName, new {id = gameDetailsDTO.Id}, gameDetailsDTO);
        });


        app.MapPut("/games/{id}", async (
            int id,
            UpdateGameDto updatedGame,
            GameStoreContext dbContext) =>
        {
            var existingGame = await dbContext.Games.FindAsync(id);

            if(existingGame is null)
            {
                return Results.NotFound();
            }

            existingGame.Name = updatedGame.Name;
            existingGame.Price = updatedGame.Price;
            existingGame.GenreId = updatedGame.GenreId;
            existingGame.ReleaseDate = updatedGame.ReleaseDate;

            await dbContext.SaveChangesAsync();

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