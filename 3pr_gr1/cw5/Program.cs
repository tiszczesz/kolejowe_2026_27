using cw5.Models;

var repo = new FileRepo();
foreach (var m in repo.Movies)
{
    Console.WriteLine(m);
}
// var movie = new Movie
// {
//     Id = repo.GetLastId() + 1,
//     Title = "Dziwne",
//     Director = "Dziwne",
//     Year = 2000
// };
// repo.Movies.Add(movie);
// repo.SaveToFile();
Console.Write("Podaj id filmu do usuniecia: ");
int id = Convert.ToInt32(Console.ReadLine());
repo.DeleteMovie(id);
