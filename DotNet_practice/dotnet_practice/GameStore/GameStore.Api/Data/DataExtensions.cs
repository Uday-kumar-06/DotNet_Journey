using System;
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
}
