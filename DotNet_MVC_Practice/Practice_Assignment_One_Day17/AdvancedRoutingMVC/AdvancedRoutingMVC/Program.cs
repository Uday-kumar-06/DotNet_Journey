using AdvancedRoutingMVC.Constraints;
using Microsoft.AspNetCore.Routing;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.Configure<RouteOptions>(options =>
{
    options.ConstraintMap.Add("validguid", typeof(GuidConstraint));
});

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "products",
    pattern: "Products/{category}/{id:int}",
    defaults: new { controller = "Products", action = "Details" });

app.MapControllerRoute(
    name: "userorders",
    pattern: "Users/{username}/Orders",
    defaults: new { controller = "Users", action = "Orders" });

app.MapControllerRoute(
    name: "guidroute",
    pattern: "Dashboard/{id:validguid}",
    defaults: new { controller = "Dashboard", action = "Index" });

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

public partial class Program
{
}