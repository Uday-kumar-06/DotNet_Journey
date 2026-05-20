var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseHttpsRedirection();

app.UseExceptionHandler("/error");

app.Use(async (context, next) =>
{
    Console.WriteLine("Incoming Request:");
    Console.WriteLine($"Method:  {context.Request.Method}");
    Console.WriteLine($"URL:     {context.Request.Path}");

    await next();

    Console.WriteLine("Outgoing Response:");
    Console.WriteLine($"Status:  {context.Response.StatusCode}");
});

app.Use(async (context, next) =>
{
    context.Response.Headers.Append(
        "Content-Security-Policy",
        "default-src 'self'; script-src 'self'; style-src 'self';"
    );

    await next();
});

app.UseStaticFiles();

app.Map("/error", appBuilder =>
{
    appBuilder.Run(async context =>
    {
        context.Response.ContentType = "text/html";
        await context.Response.WriteAsync(@"
            <h1>Something went wrong!</h1>
            <p>Please try again later.</p>
        ");
    });
});

app.MapGet("/", async context =>
{
    context.Response.Redirect("/index.html");
});

app.Run();