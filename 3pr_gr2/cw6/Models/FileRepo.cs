using System;

namespace cw6.Models;

public class FileRepo
{
    public List<Person>? Persons { get; set; }
    private string fileName = "dane.txt";
    public int GetLastId()
    {
        if (Persons == null || Persons.Count == 0)
        {
            return 0;
        }
        int maxId = 0;
        foreach (Person p in Persons)
        {
            if (p.Id > maxId) maxId = p.Id;
        }
        return maxId;
    }
    public FileRepo(string filename = "dane.txt")
    {

        string[] lines = File.ReadAllLines(fileName);
        if (Persons == null) Persons = new List<Person>();
        foreach (string line in lines)
        {
            var p = Person.GenerPerson(line);
            if (p != null) Persons.Add(p);
        }
    }
    public void SavePersons()
    {
        if (Persons != null)
        {
            List<string> lines = new List<string>();            
            foreach (var p in Persons)
            {
                 lines.Add(p.ToString());  
            }
            File.WriteAllLines(fileName,lines);
        }

    }
    public void DeletePerson(int id)
    {
        var personToDelete = Persons?.Find((p)=>p.Id==id);
        if (personToDelete != null)
        {
            Persons?.Remove(personToDelete);
        }
        SavePersons();
    }
}
