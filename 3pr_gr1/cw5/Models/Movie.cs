using System;

namespace cw5.Models;

public class Movie
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Director { get; set; }    
    public int Year { get; set; }
    public override string ToString()
    {
        return $"{Id}|{Title}|{Director}|{Year}"; 
    }
    public static Movie? GetFromLine(string line)
    {
        var data = line.Split('|'); 
        if(data.Length == 4)
        {
            return new Movie{
                Id = Convert.ToInt32(data[0]),
                Title = data[1].Trim(),
                Director = data[2].Trim(),
                Year = Convert.ToInt32(data[3])
            };
        }
        return null;
    }
}
