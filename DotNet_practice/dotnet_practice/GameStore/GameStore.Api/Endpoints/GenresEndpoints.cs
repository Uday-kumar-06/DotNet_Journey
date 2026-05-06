using System;
using GameStore.Api.Data;
using GameStore.Api.Dtos;
using GameStore.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Api.Endpoints;

public static class GenresEndpoints
{
    const string GetGenreEndpointName = "GetGenre";

    public static void MapGenresEndpoints(this WebApplication app)
    {

        app.MapGet("/genre", async (GameStoreContext dbContext) =>
        {
            var genres = await dbContext.Genres.ToListAsync();

            return Results.Ok(genres);
        });

        
        app.MapGet("/genre/{id}", async (
            int id,
            GameStoreContext dbContext) =>
        {
            var genre = await dbContext.Genres.FindAsync(id);

            return genre is null
                ? Results.NotFound()
                : Results.Ok(genre);

        }).WithName(GetGenreEndpointName);


        app.MapPost("/genre", async (
            GameStoreContext dbContext,
            GenreDto genreDto) =>
        {
            Genre genre = new()
            {
                Name = genreDto.Name
            };

            await dbContext.Genres.AddAsync(genre);

            await dbContext.SaveChangesAsync();

            return Results.CreatedAtRoute(
                GetGenreEndpointName,
                new { id = genre.Id },
                genre
            );
        });
    }
}
