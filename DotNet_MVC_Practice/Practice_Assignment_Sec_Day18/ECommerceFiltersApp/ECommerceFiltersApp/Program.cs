using ECommerceFiltersApp.Filters;
using ECommerceFiltersApp.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add<ExceptionFilter>();
    options.Filters.Add<LoggingFilter>();
});

builder.Services.AddScoped<ILoggingService, LoggingService>();
builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddScoped<LoggingFilter>();
builder.Services.AddScoped<AuthFilter>();
builder.Services.AddScoped<ExceptionFilter>();

var app = builder.Build();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Product}/{action=Index}/{id?}");

app.Run();