import {type Book, openDb, getAllBooks, getBookById, insertBook, deleteBook, updateBook} from './sqliteRepo.js';
import * as readline from 'node:readline/promises';
const db = openDb();

//wyświetlanie wszystkich książek
const books = getAllBooks(db);
console.log(books);

const rl = readline.createInterface({
  input: process.stdin,
  output: process.stdout
});

//wyświetlanie książki po id
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
// rl.close();

//dodawanie książki
const answer = await rl.question("Czy dodać ksiżąkę(t/n): ");
if(answer.toLowerCase() === 't') {
  const book:Book = {
     id: 0,
     title: "test16-11-2026",
     author: "test",
      published_year: 2004, 
      genre: "test",
      price: 23.89
  }
  insertBook(db,book);
}

//usuwanie książki
const deleteQuery = await rl.question("Czy usunąć książkę(t/n): ");
if(deleteQuery.toLowerCase() === 't') {
      const bookIdToDelete = 
      parseInt(await rl.question("Podaj id ksiżki do usunięcia: "));
      deleteBook(db,bookIdToDelete)
}

//update książki
const updateQuery = await rl.question("Czy zaktualizować książkę(t/n): ");
if(updateQuery.toLowerCase() === 't') {
  const queryToId = parseInt(await rl.question("Podaj id książki do aktualizacji: "));
  const bookToUpdate = getBookById(db, queryToId);
  if (bookToUpdate) {
    const newTitle = (await rl.question("Podaj nowy tytuł: "))|| bookToUpdate.title;
    const newAuthor = (await rl.question("Podaj nowego autora: ")) || bookToUpdate.author;
    const newPublishedYearInput = (await rl.question("Podaj nowy rok wydania: ")) || bookToUpdate.published_year.toString();
    const newPublishedYear = parseInt(newPublishedYearInput, 10) || bookToUpdate.published_year;
    const newGenre = (await rl.question("Podaj nowy gatunek: ") )|| bookToUpdate.genre;
    const newPriceInput = (await rl.question("Podaj nową cenę: ")) || bookToUpdate.price.toString();
    const newPrice = parseFloat(newPriceInput) ;
    // Aktualizuj książkę w bazie danych
    bookToUpdate.title = newTitle;
    bookToUpdate.author = newAuthor;
    bookToUpdate.published_year = newPublishedYear;
    bookToUpdate.genre = newGenre;
    bookToUpdate.price = newPrice;
    updateBook(db, bookToUpdate);
  }
}
  
rl.close();
