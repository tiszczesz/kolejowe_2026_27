using System;
using Microsoft.EntityFrameworkCore;

namespace cw2_ef.Models;

public class BooksDbContext : DbContext
{
    public BooksDbContext(DbContextOptions<BooksDbContext> options) 
    : base(options) //konstruktor przekazujący opcje do DbContext klasa bazowa
    {
        
    }
    //Odpowiednik tabeli w bazie danych
    public DbSet<Book> Books { get; set; }
    //Zainicjowanie bazy danych i wypełnienie jej przykładowymi danymi
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>().HasData(
            new Book { Id = 1, Title = "Władca Pierścieni", Author = "J.R.R. Tolkien" },
            new Book { Id = 2, Title = "Hobbit", Author = "J.R.R. Tolkien" },
            new Book { Id = 3, Title = "1984", Author = "George Orwell" },
            new Book { Id = 4, Title = "Zbrodnia i kara", Author = "Fiodor Dostojewski" },
            new Book { Id = 5, Title = "Lalka", Author = "Bolesław Prus" },
            new Book { Id = 6, Title = "Pan Tadeusz", Author = "Adam Mickiewicz" },
            new Book { Id = 7, Title = "Mistrz i Małgorzata", Author = "Michaił Bułhakow" },
            new Book { Id = 8, Title = "Mały Książę", Author = "Antoine de Saint-Exupéry" },
            new Book { Id = 9, Title = "Harry Potter i Kamień Filozoficzny", Author = "J.K. Rowling" },
            new Book { Id = 10, Title = "Wiedźmin: Ostatnie życzenie", Author = "Andrzej Sapkowski" }
        );
    }
}
