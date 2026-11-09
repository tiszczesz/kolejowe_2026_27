# Ćwiczenie 2: Razor Pages – strona z linkami graficznymi

## Cel
Utworzenie projektu Razor Pages startując od szablonu `web`, dodanie strony Index z dwoma obrazkami-linkami oraz użycie stylów i JavaScript z `wwwroot`.

## Krok 1. Utworzenie projektu

```powershell
dotnet new web -o zad2
cd zad2
```

`Program.cs`:

```csharp
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();

var app = builder.Build();

app.UseStaticFiles();
app.MapRazorPages();

app.Run();
```

## Krok 2. Struktura

```
zad2/
├── Pages/
│   ├── Shared/_Layout.cshtml
│   ├── _ViewStart.cshtml
│   ├── _ViewImports.cshtml
│   ├── Index.cshtml
│   ├── Home.cshtml
│   └── Car.cshtml
├── wwwroot/
│   ├── css/site.css
│   ├── js/site.js
│   └── img/home.png, car.png
└── Program.cs
```

Do `wwwroot/img` wstaw obrazki `home.png` (domek) i `car.png` (samochód).

## Krok 3. Pliki wspólne

`Pages/_ViewImports.cshtml`:
```cshtml
@namespace zad2.Pages
@addTagHelper *, Microsoft.AspNetCore.Mvc.TagHelpers
```

`Pages/_ViewStart.cshtml`:
```cshtml
@{
    Layout = "_Layout";
}
```

`Pages/Shared/_Layout.cshtml`:
```cshtml
<!DOCTYPE html>
<html lang="pl">
<head>
    <meta charset="utf-8" />
    <title>@ViewData["Title"] - zad2</title>
    <link rel="stylesheet" href="~/css/site.css" />
</head>
<body>
    <header><a asp-page="/Index">Start</a></header>
    <main>
        @RenderBody()
    </main>
    <script src="~/js/site.js"></script>
</body>
</html>
```

## Krok 4. Index

`Pages/Index.cshtml`:
```cshtml
@page
@{
    ViewData["Title"] = "Strona główna";
}
<h1>Wybierz miejsce</h1>
<div class="menu">
    <a asp-page="/Home"><img src="~/img/home.png" alt="Domek" /></a>
    <a asp-page="/Car"><img src="~/img/car.png" alt="Samochód" /></a>
</div>
```

## Krok 5. Home i Car

`Pages/Home.cshtml`:
```cshtml
@page
@{
    ViewData["Title"] = "Domek";
}
<h1>Domek</h1>
<p>Domek to mały budynek mieszkalny, zwykle jednorodzinny, z ogrodem.</p>
<button id="colorBtn">Zmień kolor tła</button>
<p><a asp-page="/Index">Powrót</a></p>
```

`Pages/Car.cshtml`:
```cshtml
@page
@{
    ViewData["Title"] = "Samochód";
}
<h1>Samochód</h1>
<p>Samochód to pojazd silnikowy służący do transportu osób i towarów.</p>
<button id="colorBtn">Zmień kolor tła</button>
<p><a asp-page="/Index">Powrót</a></p>
```

## Krok 6. Style i JavaScript

`wwwroot/css/site.css`:
```css
body {
    font-family: Arial, sans-serif;
    margin: 0;
    text-align: center;
    background: #f4f4f4;
}
header {
    background: #333;
    padding: 10px;
}
header a {
    color: #fff;
    text-decoration: none;
}
.menu {
    display: flex;
    justify-content: center;
    gap: 40px;
}
.menu img {
    width: 200px;
    height: 200px;
    border: 3px solid #333;
    border-radius: 10px;
    transition: transform .3s;
}
.menu img:hover {
    transform: scale(1.1);
}
```

`wwwroot/js/site.js`:
```javascript
const btn = document.getElementById("colorBtn");
if (btn) {
    btn.addEventListener("click", () => {
        document.body.style.background =
            "#" + Math.floor(Math.random() * 16777215).toString(16).padStart(6, "0");
    });
}
```

## Krok 7. Uruchomienie

```powershell
dotnet run
```

Sprawdź:
- strona główna pokazuje dwa obrazki,
- domek prowadzi do `/Home`, samochód do `/Car`,
- style z `site.css` działają,
- przycisk na podstronach zmienia kolor tła (JavaScript).

## Zadania dodatkowe
- Dodaj do podstron więcej informacji i zdjęcie.
- Dodaj `alert` po kliknięciu obrazka na stronie Index.
