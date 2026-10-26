using System;

namespace cw8.Models;

public class Person
{
    public int Id    { get; set; }
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public int Age { get; set; }
    public Person()
    {
        Id = -1;
        Firstname = "noname";
        Lastname = "noname";
        Age = 20;
    }
    //aby wygodnie zapisywać linię w pliku
    public override string ToString()
    {
        return $"{Id}|{Firstname}|{Lastname}|{Age}";
    }
    public static Person? GenerPerson(string line)
    {
        var data = line.Split('|');
        if(data.Length == 4)
        {
            return new Person
            {
                Id = Convert.ToInt32(data[0]),
                Firstname = data[1].Trim(),
                Lastname = data[2].Trim(),
                Age = Convert.ToInt32(data[3])
            };
        }
        return null;
    }
}
