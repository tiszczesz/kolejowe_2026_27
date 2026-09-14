# Instrukcja: Instalacja Entity Framework Core, tworzenie migracji i aktualizacja bazy danych

Poniżej znajdziesz instrukcję krok po kroku, jak zainstalować narzędzie Entity Framework Core lokalnie w projekcie, utworzyć migracje oraz zaktualizować bazę danych.

---

## 1. Utworzenie manifestu narzędziowego (.NET Tool Manifest)

W katalogu głównym projektu (np. `4pr_gr2`) uruchom w terminalu:

```bash
dotnet new tool-manifest
```

To polecenie utworzy plik `.config/dotnet-tools.json` do zarządzania narzędziami .NET w projekcie.

---

## 2. Instalacja Entity Framework Core CLI lokalnie

Następnie zainstaluj narzędzie EF Core CLI:

```bash
dotnet tool install dotnet-ef
```

Po instalacji możesz korzystać z poleceń EF Core bez potrzeby globalnej instalacji narzędzia.

---

## 3. Tworzenie migracji

Jeżeli w projekcie masz już skonfigurowany kontekst bazy danych (DbContext), możesz utworzyć pierwszą migrację:

```bash
dotnet ef migrations add InitialCreate
```

Zalecane jest nadanie migracji opisowej nazwy, np. `InitialCreate` dla pierwszej migracji.

---

## 4. Aktualizacja bazy danych

Aby zastosować migracje do bazy danych, użyj polecenia:

```bash
dotnet ef database update
```

Polecenie to utworzy lub zaktualizuje schemat bazy danych zgodnie z migracjami w projekcie.

---

## Podsumowanie poleceń (do skopiowania)

```bash
dotnet new tool-manifest
dotnet tool install dotnet-ef
dotnet ef migrations add InitialCreate
dotnet ef database update
```

---

## Uwagi dodatkowe

- Upewnij się, że jesteś w katalogu projektu (tam, gdzie znajduje się plik `.csproj`).
- W przypadku problemów z poleceniami, sprawdź czy narzędzia są zainstalowane lokalnie (w folderze `.config`).
- Migracje możesz nazywać dowolnie, np. `AddStudentTable`, `UpdateGrades`.

---
## 5. Tutorial: nowa aplikacja web + Entity Framework Core + SQLite (od `dotnet new web`)

Poniższy przykład pokazuje pełny, minimalny proces stworzenia aplikacji ASP.NET Core Web z bazą SQLite i migracjami EF Core.

### Krok 1: Utwórz projekt web

```bash
dotnet new web -n WebEfSqliteApp
cd WebEfSqliteApp
```

### Krok 2: Utwórz manifest narzędzi i zainstaluj `dotnet-ef`

```bash
dotnet new tool-manifest
dotnet tool install dotnet-ef
```

### Krok 3: Dodaj paczki NuGet dla EF Core i SQLite

```bash
dotnet add package Microsoft.EntityFrameworkCore.Sqlite
dotnet add package Microsoft.EntityFrameworkCore.Design
```

### Krok 4: Dodaj model encji

Utwórz folder `Models` i plik `Models/Student.cs`:

```csharp
namespace WebEfSqliteApp.Models;

public class Student
{
    public int Id { get; set; }
    public string Imie { get; set; } = "";
    public string Nazwisko { get; set; } = "";
}
```

### Krok 5: Dodaj `DbContext`

Utwórz folder `Data` i plik `Data/AppDbContext.cs`:

```csharp
using Microsoft.EntityFrameworkCore;
using WebEfSqliteApp.Models;

namespace WebEfSqliteApp.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Student> Students => Set<Student>();
}
```

### Krok 6: Skonfiguruj połączenie SQLite w `appsettings.json`

W pliku `appsettings.json` dodaj:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=app.db"
  }
}
```

> Jeśli masz już inne sekcje w `appsettings.json`, dodaj tylko sekcję `ConnectionStrings`.

### Krok 7: Zarejestruj `DbContext` w `Program.cs`

W `Program.cs` dodaj:

```csharp
using Microsoft.EntityFrameworkCore;
using WebEfSqliteApp.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
```

### Krok 8: Utwórz pierwszą migrację

```bash
dotnet ef migrations add InitialCreate
```

Po tym kroku pojawi się folder `Migrations/` z plikami migracji.

### Krok 9: Zaktualizuj bazę danych

```bash
dotnet ef database update
```

To polecenie utworzy plik bazy SQLite (`app.db`) i zastosuje schemat tabel.

### Krok 10: Uruchom aplikację

```bash
dotnet run
```

Aplikacja powinna wystartować lokalnie, a baza `app.db` będzie gotowa do użycia.

---

## 6. Szybka checklista (skrót)

```bash
dotnet new web -n WebEfSqliteApp
cd WebEfSqliteApp
dotnet new tool-manifest
dotnet tool install dotnet-ef
dotnet add package Microsoft.EntityFrameworkCore.Sqlite
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet ef migrations add InitialCreate
dotnet ef database update
dotnet run
```

---

## 7. Najczęstsze problemy

- **`No project was found`**  
  Uruchamiasz komendę poza katalogiem z `.csproj`.

- **`dotnet ef` nie działa**  
  Upewnij się, że wykonałeś `dotnet tool install dotnet-ef` (lokalnie w projekcie) i jesteś w tym samym folderze.

- **Błąd połączenia z bazą**  
  Sprawdź poprawność `ConnectionStrings:DefaultConnection` w `appsettings.json`.

- **Brak zmian przy migracji**  
  Upewnij się, że dodałeś/zmieniłeś encje lub konfigurację modelu przed `dotnet ef migrations add ...`.

