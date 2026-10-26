import {type Book} from './models.js';
import {readFile,writeFile} from 'fs/promises';

//wczytanie danych z pliku do tablicy obiektów typu Book
const books: Book[] = JSON.parse(await readFile("books.json", "utf-8"));
console.log(books);
//dodanie nowej książki do tablicy obiektów typu Book
const newBook: Book = {
    id: 4,
    title: "New Book Title",
    author: "New Book Author",
    price: 29.99,
    year: 2023
};
books.push(newBook);
//zapisanie danych do pliku
await writeFile("books2.json", JSON.stringify(books, null, 2), "utf-8");
console.log(books);