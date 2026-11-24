import { DatabaseSync } from "node:sqlite";

// Owinięcie operacji DB w Promise
function runAsync<T>(fn: () => T): Promise<T> {
  return Promise.resolve().then(() => fn());
}

// 1. Utworzenie bazy
async function createDatabase() {
  const database = await runAsync(() => new DatabaseSync("MyDb.db"));
  console.log("✓ Baza danych MyDb.db została otwarta");
  return database;
}

// 2. Dodanie tabeli Books
async function createBooksTable(database: any) {
  await runAsync(() => {
    const sql = `
      CREATE TABLE IF NOT EXISTS Books (
        id INTEGER PRIMARY KEY AUTOINCREMENT,
        title TEXT NOT NULL,
        author TEXT NOT NULL,
        year INTEGER NOT NULL,
        isbn TEXT UNIQUE
      )
    `;
    database.exec(sql);
  });
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

  await runAsync(() => {
    const insert = database.prepare(
      "INSERT INTO Books (title, author, year, isbn) VALUES (?, ?, ?, ?)"
    );

    for (const book of books) {
      insert.run(book.title, book.author, book.year, book.isbn);
    }
  });

  console.log(`✓ Dodano ${books.length} przykładowych książek do bazy`);
}

// 4. Odczyt danych z bazy
async function readBooksData(database: any) {
  const books = await runAsync(() => {
    const select = database.prepare("SELECT * FROM Books");
    return select.all();
  });

  console.log("\n📚 Lista wszystkich książek w bazie:\n");
  books.forEach((book: any) => {
    console.log(`ID: ${book.id}`);
    console.log(`Tytuł: ${book.title}`);
    console.log(`Autor: ${book.author}`);
    console.log(`Rok: ${book.year}`);
    console.log(`ISBN: ${book.isbn}`);
    console.log("---");
  });
}

// 5. Funkcja zamykająca bazę
async function closeDatabase(database: any) {
  await runAsync(() => database.close());
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
