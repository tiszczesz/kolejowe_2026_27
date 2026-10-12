using System;

namespace cw5.Models;

public class FileRepo
{
    private string filename = "data.txt";
    public List<Movie> Movies { get; set; } = [];
    public FileRepo(string fliename = "data.txt")
    {
        string[] lines = File.ReadAllLines(filename);
        foreach(var line in lines)
        {
            var movie = Movie.GetFromLine(line);
            if (movie != null)
            {
                Movies.Add(movie);
            }
        }
    }
    
}
