var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// GET 
app.MapGet("/games", () => "Hello World!");
app.MapGet("/student", () => "Hi");


app.Run();
