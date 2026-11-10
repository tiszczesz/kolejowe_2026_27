import {type Book, openDb, getAllBooks} from './sqliteRepo.js';

const db = openDb();
const books = getAllBooks(db);
console.log(books);