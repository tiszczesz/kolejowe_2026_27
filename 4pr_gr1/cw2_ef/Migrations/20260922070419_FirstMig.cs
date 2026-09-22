using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace cw2_ef.Migrations
{
    /// <inheritdoc />
    public partial class FirstMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Author = table.Column<string>(type: "TEXT", nullable: false),
                    Year = table.Column<int>(type: "INTEGER", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "Price", "Title", "Year" },
                values: new object[,]
                {
                    { 1, "J.R.R. Tolkien", 0m, "Władca Pierścieni", 0 },
                    { 2, "J.R.R. Tolkien", 0m, "Hobbit", 0 },
                    { 3, "George Orwell", 0m, "1984", 0 },
                    { 4, "Fiodor Dostojewski", 0m, "Zbrodnia i kara", 0 },
                    { 5, "Bolesław Prus", 0m, "Lalka", 0 },
                    { 6, "Adam Mickiewicz", 0m, "Pan Tadeusz", 0 },
                    { 7, "Michaił Bułhakow", 0m, "Mistrz i Małgorzata", 0 },
                    { 8, "Antoine de Saint-Exupéry", 0m, "Mały Książę", 0 },
                    { 9, "J.K. Rowling", 0m, "Harry Potter i Kamień Filozoficzny", 0 },
                    { 10, "Andrzej Sapkowski", 0m, "Wiedźmin: Ostatnie życzenie", 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
