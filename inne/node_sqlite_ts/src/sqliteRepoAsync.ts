import { Database } from "node:sqlite";

// 1. Utworzenie bazy w pliku MyDb.db (asynchronicznie)
async function createDatabase() {
  const database = new Database("MyDb.db");
  console.log("✓ Baza danych MyDb.db została otwarta");
  return database;
}

// 2. Dodanie tabeli Books
async function createBooksTable(database: any) {
  const sql = `
    CREATE TABLE IF NOT EXISTS Books (
      id INTEGER PRIMARY KEY AUTOINCREMENT,
      title TEXT NOT NULL,
      author TEXT NOT NULL,
      year INTEGER NOT NULL,
      isbn TEXT UNIQUE
    )
  `;
  await database.exec(sql);
  console.log("✓ Tabela Books została utworzona");
}

// 3. Wypełnienie przykładowych danych
async function populateSampleData(database: any) {
  const books = [
    { title: "Harry Potter i Kamień Filozoficzny", author: "J.K. Rowling", year: 1997, isbn: "978-0747532699" },
    { title: "Władca Pierścieni: Drużyna Pierścienia", author: "J.R.R. Tolkien", year: 1954, isbn: "978-0544003415" },
    { title: "Zbrodnia i kara", author: "Fiodor Dostojewski", year: 1866, isbn: "978-8308035547" },
    { title: "Mistrz i Małgorzata", author: "Michaił Bułhakow", year: 1967, isbn: "978-1491951737" },
    { title: "Nowoczesna baza danych", author: "Chris Date", year: 2015, isbn: "978-1491951751" },
  ];

  const insert = await database.prepare(
    "INSERT INTO Books (title, author, year, isbn) VALUES (?, ?, ?, ?)"
  );

  for (const book of books) {
    await insert.run(book.title, book.author, book.year, book.isbn);
  }

  await insert.finalize();
  console.log(`✓ Dodano ${books.length} przykładowych książek do bazy`);
}

// 4. Odczyt danych z bazy
async function readBooksData(database: any) {
  const select = await database.prepare("SELECT * FROM Books");
  const books = await select.all();

  console.log("\n📚 Lista wszystkich książek w bazie:\n");
  books.forEach((book: any) => {
    console.log(`ID: ${book.id}`);
    console.log(`Tytuł: ${book.title}`);
    console.log(`Autor: ${book.author}`);
    console.log(`Rok: ${book.year}`);
    console.log(`ISBN: ${book.isbn}`);
    console.log("---");
  });

  await select.finalize();
}

// 5. Funkcja zamykająca bazę
async function closeDatabase(database: any) {
  await database.close();
  console.log("\n✓ Baza danych została zamknięta");
}

// Główna funkcja - wszystko asynchronicznie
async function main() {
  const db = await createDatabase();
  await createBooksTable(db);
  await populateSampleData(db);
  await readBooksData(db);
  await closeDatabase(db);
}

main().catch(console.error);
