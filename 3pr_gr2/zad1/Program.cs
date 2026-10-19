using System.Globalization;
using zad1.Models;

Menu menu = new Menu();
decimal rr = 34.90M;
Console.WriteLine(rr.ToString(CultureInfo.InvariantCulture));
menu.DoMenu();
