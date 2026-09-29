using cw2_ef.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
string connString = builder.Configuration.GetConnectionString("sqlite")
                  ?? "Data Source=myappDB.db";
                  //dla mysql: "server=localhost;user=root;password=;database=myappDB";
//dołożenie kontekstu bazy danych do kontenera DI (Service Collection)
builder.Services.AddDbContext<BooksDbContext>(options =>
    options.UseSqlite(connString)
);
// builder.Services.AddDbContext<BooksDbContext>(options =>
//     options.UseMySql(connString, ServerVersion.AutoDetect(connString))
// );
var app = builder.Build();
//app.MapGet("/api/books", (BooksDbContext db) => db.Books.ToList());
app.UseStaticFiles();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Library}/{action=List}/{id?}"
);


app.Run();
