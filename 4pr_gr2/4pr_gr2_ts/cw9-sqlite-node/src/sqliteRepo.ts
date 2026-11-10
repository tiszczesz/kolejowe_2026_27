import Database from "better-sqlite3";

export interface Book {
  id: number;
  title: string;
  author: string;
  published_year: number;
  genre: string;
  price: number;
}
export function openDb(): Database.Database {
  const db = new Database("app.db", { verbose: console.log });
  return db;
}
export function getAllBooks(db: Database.Database): Book[] {
  const stmt = db.prepare("SELECT * FROM books");
  return stmt.all() as Book[];
}
export function getBookById(db: Database.Database, id: number): Book | undefined {
  const stmt = db.prepare("SELECT * FROM books WHERE id = ?");
  return stmt.get(id) as Book | undefined;
}