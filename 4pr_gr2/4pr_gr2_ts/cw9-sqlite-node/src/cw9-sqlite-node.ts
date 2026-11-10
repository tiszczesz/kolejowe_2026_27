import {type Book, openDb, getAllBooks, getBookById} from './sqliteRepo.js';
import * as readline from 'node:readline/promises';
const db = openDb();
const books = getAllBooks(db);
console.log(books);

const rl = readline.createInterface({
  input: process.stdin,
  output: process.stdout
});

const idInput = await rl.question('Podaj id książki: ');
const id = parseInt(idInput, 10);
if (isNaN(id)) {
  console.log('Nieprawidłowe id');  
}else {
    const book = getBookById(db, id);
    if (book) {
    console.log(book);
    } else {
    console.log('Książka nie znaleziona');
    }
}

rl.close();
