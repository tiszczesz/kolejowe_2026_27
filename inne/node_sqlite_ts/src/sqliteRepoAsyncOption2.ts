import { Worker } from "node:worker_threads";
import { join } from "node:path";
import { fileURLToPath } from "node:url";

const __dirname = fileURLToPath(new URL(".", import.meta.url));

// Wrapper dla komunikacji z Worker
function runInWorker(action: string, ...args: any[]): Promise<any> {
  return new Promise((resolve, reject) => {
    const worker = new Worker(join(__dirname, "dbWorker.js"));
    
    worker.on("message", (result) => {
      worker.terminate();
      resolve(result);
    });

    worker.on("error", reject);
    worker.on("exit", (code) => {
      if (code !== 0) {
        reject(new Error(`Worker stopped with exit code ${code}`));
      }
    });

    worker.postMessage({ action, args });
  });
}

// 1. Utworzenie bazy
async function createDatabase() {
  await runInWorker("create");
  console.log("✓ Baza danych MyDb.db została otwarta");
}

// 2. Dodanie tabeli Books
async function createBooksTable() {
  await runInWorker("createTable");
  console.log("✓ Tabela Books została utworzona");
}

// 3. Wypełnienie przykładowych danych
async function populateSampleData() {
  const books = [
    { title: "Harry Potter i Kamień Filozoficzny", author: "J.K. Rowling", year: 1997, isbn: "978-0747532699" },
    { title: "Władca Pierścieni: Drużyna Pierścienia", author: "J.R.R. Tolkien", year: 1954, isbn: "978-0544003415" },
    { title: "Zbrodnia i kara", author: "Fiodor Dostojewski", year: 1866, isbn: "978-8308035547" },
    { title: "Mistrz i Małgorzata", author: "Michaił Bułhakow", year: 1967, isbn: "978-1491951737" },
    { title: "Nowoczesna baza danych", author: "Chris Date", year: 2015, isbn: "978-1491951751" },
  ];

  await runInWorker("populate", books);
  console.log(`✓ Dodano ${books.length} przykładowych książek do bazy`);
}

// 4. Odczyt danych z bazy
async function readBooksData() {
  const books = await runInWorker("read");

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
async function closeDatabase() {
  await runInWorker("close");
  console.log("\n✓ Baza danych została zamknięta");
}

// Główna funkcja - wszystko prawdziwie asynchronicznie
async function main() {
  await createDatabase();
  await createBooksTable();
  await populateSampleData();
  await readBooksData();
  await closeDatabase();
}

main().catch(console.error);
