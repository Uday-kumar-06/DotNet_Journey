using Microsoft.AspNetCore.Identity;

namespace MockTestWebApp.Seed
{
    public static class IdentitySeeder
    {
        public static async Task SeedAdminUserAsync(
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            if (!await roleManager.RoleExistsAsync("Admin"))
            {
                await roleManager.CreateAsync(new IdentityRole("Admin"));
            }
            if (!await roleManager.RoleExistsAsync("User"))
            {
                await roleManager.CreateAsync(new IdentityRole("User"));
            }

            var admin = await userManager.FindByNameAsync("admin");
            if (admin== null)
            {
                admin = new IdentityUser
                {
                    UserName = "admin",
                    Email = "admin@gmail.com"
                };

                await userManager.CreateAsync(admin, "Admin@123");

                await userManager.AddToRoleAsync(admin, "Admin");
            }
            var normalUser = await userManager.FindByNameAsync("user1");

            if (normalUser == null)
            {
                normalUser = new IdentityUser
                {
                    UserName = "user1",
                    Email = "user1@gmail.com"
                };
                await userManager.CreateAsync(normalUser, "User@123");
                await userManager.AddToRoleAsync(normalUser, "User");
            }
        }
    }
}
