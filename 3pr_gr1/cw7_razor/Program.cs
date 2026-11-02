var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
var app = builder.Build();

//app.MapGet("/", () => "Hello World!");
//endpoint  do  razor pages
//domyślny adres  /Index
app.MapRazorPages();

app.Run();
