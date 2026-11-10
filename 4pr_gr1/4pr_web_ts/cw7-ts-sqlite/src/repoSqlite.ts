import Database from "better-sqlite3";

export interface Course {
    id: number;
    title: string;
    price: number;
    date_start: string;
}

export function openDb(): Database.Database {
    const db = new Database("app.db", { verbose: console.log });
    return db;
}