using OnlineBankingMVC.Filters;
using OnlineBankingMVC.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add<GlobalExceptionFilter>();
});

builder.Services.AddScoped<ILoggingService, LoggingService>();

builder.Services.AddScoped<GlobalExceptionFilter>();

builder.Services.AddScoped<ActionLoggingFilter>();

builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddSession();

var app = builder.Build();

app.UseStaticFiles();

app.UseRouting();

app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}"
);

app.Run();