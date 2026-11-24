import { DatabaseSync } from "node:sqlite";
import { parentPort } from "node:worker_threads";

let database: any = null;

parentPort?.on("message", (message) => {
  const { action, args } = message;

  try {
    let result;

    switch (action) {
      case "create":
        database = new DatabaseSync("MyDb.db");
        result = { success: true };
        break;

      case "createTable":
        database.exec(`
          CREATE TABLE IF NOT EXISTS Books (
            id INTEGER PRIMARY KEY AUTOINCREMENT,
            title TEXT NOT NULL,
            author TEXT NOT NULL,
            year INTEGER NOT NULL,
            isbn TEXT UNIQUE
          )
        `);
        result = { success: true };
        break;

      case "populate":
        const insert = database.prepare(
          "INSERT INTO Books (title, author, year, isbn) VALUES (?, ?, ?, ?)"
        );
        for (const book of args[0]) {
          insert.run(book.title, book.author, book.year, book.isbn);
        }
        result = { success: true };
        break;

      case "read":
        const select = database.prepare("SELECT * FROM Books");
        result = select.all();
        break;

      case "close":
        database.close();
        result = { success: true };
        break;

      default:
        result = { error: "Unknown action" };
    }

    parentPort?.postMessage(result);
  } catch (error: any) {
    parentPort?.postMessage({ error: error.message });
  }
});
