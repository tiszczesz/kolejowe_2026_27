using cw5.Models;

var repo = new FileRepo();
foreach(var m in repo.Movies)
{
    Console.WriteLine(m);
}
