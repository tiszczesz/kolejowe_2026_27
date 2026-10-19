
using cw6.Models;

FileRepo repo = new FileRepo();
var persons = repo.Persons;
if (persons != null)
{
    foreach (var p in persons)
    {
        // Console.WriteLine($"Id: {p.Id} Imię: {p.Firstname} "
        //           + $" Nazswisko: {p.Lastname} wiek: {p.Age}");
        Console.WriteLine(p);
    }
    var newPerson = new Person()
    {
        Id = repo.GetLastId()+1,
        Firstname = "Franek123",
        Lastname = "Dzbanek",
        Age = 134
    };
    repo.Persons?.Add(newPerson);
    repo.SavePersons();
    Console.Write("Podaj id osoby do usuniecia: ");
    int id = Convert.ToInt32(Console.ReadLine());
    repo.DeletePerson(id);
}

