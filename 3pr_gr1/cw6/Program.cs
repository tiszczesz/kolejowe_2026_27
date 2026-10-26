using cw6.Models;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


//definicja endpointów
app.MapGet("/", () => "Hello World!");
app.MapGet("/html", () => "<h1>Hello World!</h1>");
app.MapGet("/info", () =>
{
    string info = "ala ma kota";
    return info;
});
app.MapGet("/date", () => DateTime.Now.ToShortDateString());
//GET /time => aktualny czas serwerowy
app.MapGet("/time", () => DateTime.Now.ToLongTimeString());
app.MapGet("/number", () =>
{
    Random rnd = new Random();
    return rnd.Next(0, 101);
});
app.MapGet("/movies", () =>
{
    FileRepoMovies repo = new FileRepoMovies();
    return repo.Movies;
});
app.Run();
