using System;
using GameStore.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Api.Data;


/// When my app starts, make sure the database is created and up-to-date.
/// Instead of manually running:
// dotnet ef database update
// 👉 This does it automatically in code
public static class DataExtensions
{
    public static void MigrateDb(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();

        var dbContext = scope.ServiceProvider.GetRequiredService<GameStoreContext>();
        // 🔥 Equivalent to CLI
        // This line:
        // dbContext.Database.Migrate();
        // 👉 is same as:
        // dotnet ef database update
        dbContext.Database.Migrate();
    }

    public static void AddGameStoreDb(this WebApplicationBuilder builder)
    {
        var connString = builder.Configuration.GetConnectionString("GameStore");
        
        // DbContext has a Scoped service lifetime because:
        // 1. It ensures that a new instance of DbContext is created per request
        // 2. DB connections are a limited and expensive resource
        // 3. DbContext is not thread-safe. Scoped avoids to concurrency issues
        // 4. Makes it easier to manage transactions and ensure data consistency
        // 5. Reusing a DbContext instance can lead to increase memory usage
        
        
        builder.Services.AddSqlite<GameStoreContext>(
            connString,
            optionsAction: options => options.UseSeeding((context, _) =>
            {
                if (!context.Set<Genre>().Any())
                {
                    context.Set<Genre>().AddRange(
                        new Genre{Name = "Fighting"},
                        new Genre{Name = "Adventure"},
                        new Genre{Name = "Sports"},
                        new Genre{Name = "Slice"}

                    );
                    context.SaveChanges();
                }
            })
        );
    }
}
