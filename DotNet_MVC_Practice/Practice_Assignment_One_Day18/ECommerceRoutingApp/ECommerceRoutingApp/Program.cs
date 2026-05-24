using ECommerceRoutingApp.Constraints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.Configure<RouteOptions>(options =>
{
    options.ConstraintMap.Add("validCategory", typeof(CategoryConstraint));
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();


app.MapControllerRoute(
    name: "productdetails",
    pattern: "Products/{category:validCategory}/{id:int}",
    defaults: new { controller = "Products", action = "Details" });

app.MapControllerRoute(
    name: "productfilter",
    pattern: "Products/Filter/{category:validCategory}/{priceRange}",
    defaults: new { controller = "Products", action = "Filter" });

app.MapControllerRoute(
    name: "checkout",
    pattern: "Checkout",
    defaults: new { controller = "Cart", action = "Checkout" });

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();