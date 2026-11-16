# Operacje CRUD w better-sqlite3 i TypeScript

CRUD to cztery podstawowe operacje na danych: **Create** (dodawanie), **Read**
(odczyt), **Update** (aktualizacja) i **Delete** (usuwanie). Poniższe przykłady
korzystają z tabeli `books` z tego projektu oraz biblioteki `better-sqlite3`.
Operacje biblioteki są synchroniczne: nie wymagają `async` ani `await`.

## Przygotowanie

Projekt zawiera już zależności `better-sqlite3` i `@types/better-sqlite3`.
Po pobraniu projektu zainstaluj je w katalogu `cw9-sqlite-node` poleceniem
`npm install`. Plik `src/BooksDb_Sqlite.sql` opisuje tabelę i przykładowe dane.
Przed wykonaniem zapytań tabela musi istnieć w bazie; ponowne wykonanie całego
skryptu doda przykładowe książki ponownie.

Funkcja `openDb()` z `src/sqliteRepo.ts` otwiera plik `app.db` w bieżącym
katalogu procesu (a gdy go nie ma, tworzy pustą bazę). Samo otwarcie bazy
nie tworzy tabeli `books`.

Poniższe fragmenty można połączyć w jeden plik w katalogu `src`. Definiują
osobne funkcje przykładowe, więc nie zmieniają istniejącego `sqliteRepo.ts`.

```ts
import Database from "better-sqlite3";
import { openDb, type Book } from "./sqliteRepo.js";

type NewBook = Omit<Book, "id">;
```

W tabeli `id` jest kluczem głównym nadawanym przez SQLite, dlatego nie podajemy
go przy dodawaniu. Typ `Book` w projekcie zakłada, że wszystkie pola mają
wartości, natomiast schemat dopuszcza `NULL` w `published_year`, `genre` i
`price`. Jeśli baza ma zawierać takie wartości, typ `Book` należy odpowiednio
rozszerzyć o `null`.

## Create: dodawanie

`prepare()` przygotowuje zapytanie, a `run()` wykonuje je z podanymi
wartościami. `lastInsertRowid` zawiera identyfikator dodanego wiersza; jego
typ to `number | bigint`.

```ts
function createBook(db: Database.Database, book: NewBook): number | bigint {
  const stmt = db.prepare(`
    INSERT INTO books (title, author, published_year, genre, price)
    VALUES (?, ?, ?, ?, ?)
  `);
  const result = stmt.run(
    book.title,
    book.author,
    book.published_year,
    book.genre,
    book.price
  );
  return result.lastInsertRowid;
}
```

Istniejąca funkcja `insertBook()` wykonuje podobne zapytanie, ale obecnie
przyjmuje cały `Book` i nie zwraca identyfikatora.

## Read: odczyt

`all()` zwraca tablicę wszystkich pasujących wierszy. `get()` zwraca pierwszy
pasujący wiersz albo `undefined`, jeśli go nie znaleziono.

```ts
function readBooks(db: Database.Database): Book[] {
  return db.prepare("SELECT * FROM books").all() as Book[];
}

function readBook(db: Database.Database, id: number | bigint): Book | undefined {
  return db.prepare("SELECT * FROM books WHERE id = ?").get(id) as Book | undefined;
}
```

W projekcie odpowiednikami tych funkcji są `getAllBooks()` i `getBookById()`.
Rzutowanie `as Book` informuje TypeScript o oczekiwanym kształcie wyniku;
nie sprawdza danych podczas działania programu.

## Update: aktualizacja

`UPDATE` zmienia wskazane kolumny. Warunek `WHERE id = ?` ogranicza operację
do jednej książki. `changes` informuje, ile wierszy objęła operacja.

```ts
function updateBook(db: Database.Database, book: Book): boolean {
  const result = db.prepare(`
    UPDATE books
    SET title = ?, author = ?, published_year = ?, genre = ?, price = ?
    WHERE id = ?
  `).run(book.title, book.author, book.published_year, book.genre, book.price, book.id);

  return result.changes > 0;
}
```

Wynik `false` oznacza, że nie znaleziono wiersza o podanym identyfikatorze.

## Delete: usuwanie

```ts
function deleteBook(db: Database.Database, id: number | bigint): boolean {
  const result = db.prepare("DELETE FROM books WHERE id = ?").run(id);
  return result.changes > 0;
}
```

Wynik `false` oznacza, że nie usunięto żadnej książki. Bez warunku `WHERE`
polecenia `UPDATE` i `DELETE` mogą objąć wszystkie wiersze tabeli.

## Przykład użycia

Po dołączeniu powyższych funkcji do tego samego pliku:

```ts
const db = openDb();

try {
  const id = createBook(db, {
    title: "Przykładowa książka",
    author: "Anna Kowalska",
    published_year: 2024,
    genre: "Powieść",
    price: 39.90
  });
  console.log("Dodano książkę, id:", id);
  console.log("Wszystkie książki:", readBooks(db));

  const book = readBook(db, id);
  if (book) {
    console.log("Zaktualizowano:", updateBook(db, { ...book, price: 29.90 }));
    console.log("Usunięto:", deleteBook(db, id));
  } else {
    console.log("Nie znaleziono dodanej książki");
  }
} finally {
  db.close();
}
```

Przykład zmienia i usuwa dodaną książkę; uruchamiaj go na testowej kopii bazy.
`finally` zamyka połączenie również w razie błędu.

Znaki `?` są parametrami zapytania. Wartości przekazuje się osobno do `run()`
lub `get()`, w kolejności odpowiadającej znakom `?`. Nie należy wstawiać danych
użytkownika bezpośrednio do tekstu SQL, ponieważ grozi to SQL injection.
