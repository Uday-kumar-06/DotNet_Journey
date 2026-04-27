var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


List<GameDto> games = [
    new GameDto(1,"spider"," Advanture",19.99M, new DateOnly(1992, 7, 15)),
    new GameDto(1,"ninja"," climb",10.99M, new DateOnly(1928, 3, 25)),
    new GameDto(1,"Temple"," running",19.89M, new DateOnly(1992, 10, 1)),
    new GameDto(1,"subway"," running",15.99M, new DateOnly(1954, 7, 5))
];
// GET 
app.MapGet("/games", () => games);
app.MapGet("/student", () => "Hi");


app.Run();
