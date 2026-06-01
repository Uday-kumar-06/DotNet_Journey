using Microsoft.EntityFrameworkCore;
using MovieCatalogAPI.Data;
using MovieCatalogAPI.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseInMemoryDatabase("MovieDb");
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    context.Directors.AddRange(
        new Director { Id = 1, Name = "Christopher Nolan" },
        new Director { Id = 2, Name = "James Cameron" }
    );

    context.Movies.AddRange(
        new Movie
        {
            Id = 1,
            Title = "Inception",
            ReleaseYear = 2010,
            DirectorId = 1
        },
        new Movie
        {
            Id = 2,
            Title = "Titanic",
            ReleaseYear = 1997,
            DirectorId = 2
        }
    );

    context.SaveChanges();
}

app.Run();