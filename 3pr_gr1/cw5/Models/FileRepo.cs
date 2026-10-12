using System;

namespace cw5.Models;

public class FileRepo
{
    private string filename = "data.txt";
    public List<Movie> Movies { get; set; } = [];
    public FileRepo(string fliename = "data.txt")
    {
        string[] lines = File.ReadAllLines(filename);
        foreach (var line in lines)
        {
            var movie = Movie.GetFromLine(line);
            if (movie != null)
            {
                Movies.Add(movie);
            }
        }

    }
    public void SaveToFile()
    {
        List<string> lines = [];
        foreach (var m in Movies)
        {
            lines.Add(m.ToString());
        }
        File.WriteAllLines(filename, lines);
    }
    public int GetLastId()
    {
        if (Movies.Count == 0) return 0;
        int maxId = 0;
        foreach (var m in Movies)
        {
            if (m.Id > maxId) maxId = m.Id;
        }
        return maxId;
        //return Movies.Max(m=>m.Id);
    }

    public void DeleteMovie(int id)
    {
        var movieToDelete = Movies.Find(m => m.Id == id);
        if (movieToDelete != null)
        {
            Movies.Remove(movieToDelete);
            SaveToFile();
        }
    }
}
