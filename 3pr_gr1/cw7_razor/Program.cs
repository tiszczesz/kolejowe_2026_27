var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
var app = builder.Build();

//app.MapGet("/", () => "Hello World!");
//endpoint  do  razor pages

//uzycie plików statycznych
app.UseStaticFiles();
//domyślny adres  /Index
app.MapRazorPages();

app.Run();
