var builder = WebApplication.CreateBuilder(args);
//dodanie obsługi Razor Pages
builder.Services.AddRazorPages();
var app = builder.Build();

//app.MapGet("/", () => "Hello World!");

//dodanie endpointów dla Razor Pages
//domyślnie w Pages tworzymy strony
//domyślna strona Index
app.MapRazorPages();

app.Run();
