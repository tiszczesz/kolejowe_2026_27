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
export function getCourses(db: Database.Database): Course[] {
    const stmt = db.prepare("SELECT * FROM courses");
    const courses = stmt.all() as Course[];
    return courses;
}
export function getCourseById(db: Database.Database, id: number): Course | undefined {
    const stmt = db.prepare("SELECT * FROM courses WHERE id = ?");
    const course = stmt.get(id) as Course | undefined;
    return course;
}