using cw8.Models;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapGet("/my", () => "Antoni Hytroś");
app.MapGet("/games", () =>
{
    return "Tu będzie lista gier w postaci JSON";
});
app.MapGet("/numbers", () =>
{
    Random rnd = new Random();
    return rnd.Next(100);
});
app.MapGet("/time", () => DateTime.Now.ToLongTimeString());
app.MapGet("persons", () =>
{
    FileRepo repo = new FileRepo();
    return repo.Persons;
});

app.Run();
