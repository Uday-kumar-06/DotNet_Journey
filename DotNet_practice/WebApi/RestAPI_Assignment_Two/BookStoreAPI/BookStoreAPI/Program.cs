using BookStoreAPI.Data;
using BookStoreAPI.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseInMemoryDatabase("BookStoreDb");
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

    context.Authors.AddRange(
        new Author { Id = 1, Name = "J.K. Rowling" },
        new Author { Id = 2, Name = "George Orwell" }
    );

    context.Books.AddRange(
        new Book
        {
            Id = 1,
            Title = "Harry Potter",
            PublicationYear = 1997,
            AuthorId = 1
        },
        new Book
        {
            Id = 2,
            Title = "1984",
            PublicationYear = 1949,
            AuthorId = 2
        }
    );

    context.SaveChanges();
}

app.Run();