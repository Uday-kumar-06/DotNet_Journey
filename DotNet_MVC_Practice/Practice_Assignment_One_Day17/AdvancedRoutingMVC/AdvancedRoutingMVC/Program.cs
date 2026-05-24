using AdvancedRoutingMVC.Constraints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

// Register custom constraint
builder.Services.Configure<RouteOptions>(options =>
{
    options.ConstraintMap.Add("validguid", typeof(GuidConstraint));
});

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();


// ================= COMPLEX ROUTES =================

// Route: /Products/Electronics/101
app.MapControllerRoute(
    name: "products",
    pattern: "Products/{category}/{id:int}",
    defaults: new { controller = "Products", action = "Details" });


// Route: /Users/john/Orders
app.MapControllerRoute(
    name: "userorders",
    pattern: "Users/{username}/Orders",
    defaults: new { controller = "Users", action = "Orders" });


// ================= CUSTOM CONSTRAINT ROUTE =================

// Route with GUID validation
app.MapControllerRoute(
    name: "guidroute",
    pattern: "Dashboard/{id:validguid}",
    defaults: new { controller = "Dashboard", action = "Index" });

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();