using cw2_ef.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
string connString = builder.Configuration.GetConnectionString("sqlite")
                  ?? "Data Source=myappDB.db";
//dołożenie kontekstu bazy danych do kontenera DI (Service Collection)
builder.Services.AddDbContext<BooksDbContext>(options =>
    options.UseSqlite(connString)
);
var app = builder.Build();
app.UseStaticFiles();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Library}/{action=List}/{id?}"
);


app.Run();
