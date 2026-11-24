# Pytania i odpowiedzi: `node:sqlite` w TypeScript i ES Modules

## 1. Jak utworzyć bazę, tabelę `Books`, dodać przykładowe dane i je odczytać?

W projekcie TypeScript z ES Modules można użyć wbudowanego modułu Node.js:

```ts
import { DatabaseSync } from "node:sqlite";
```

W osobnych funkcjach można:

1. otworzyć lub utworzyć bazę `MyDb.db` przez `new DatabaseSync("MyDb.db")`;
2. utworzyć tabelę `Books` przez `CREATE TABLE IF NOT EXISTS`;
3. wstawić przykładowe rekordy przez przygotowane zapytanie (`prepare` i `run`);
4. odczytać rekordy przez `prepare` i `all`;
5. zamknąć bazę przez `close`.

Operacje SQL powinny używać parametrów zapytania zamiast składać SQL z wartości danych. Tabela i baza są tworzone przy pierwszym uruchomieniu, a `IF NOT EXISTS` zapobiega ponownemu tworzeniu tabeli.

## 2. Dlaczego trzeba było użyć `@ts-ignore`?

W trakcie tej rozmowy TypeScript zgłaszał, że nie widzi eksportu `Database` z `node:sqlite`. Zastosowanie `@ts-ignore` jedynie ukryło ten błąd kompilatora — nie naprawiło typów. Późniejsze próby pokazały, że właściwym konstruktorem w używanym Node.js jest `DatabaseSync`, importowany jako nazwany eksport:

```ts
import { DatabaseSync } from "node:sqlite";
```

Jeśli TypeScript nadal nie rozpoznaje tego eksportu, należy sprawdzić wersję i konfigurację typów Node.js oraz ewentualne lokalne deklaracje modułu, np. `sqlite.d.ts`. Nie należy dodawać `@ts-ignore` ani ręcznych deklaracji o niezgodnych sygnaturach jako obejścia problemu.

## 3. Czy `node:sqlite` obsługuje podejście asynchroniczne?

Nie. W wersji Node.js używanej w rozmowie (`v25.6.1`) API `node:sqlite` jest synchroniczne. `Database` nie jest asynchroniczną klasą — dokumentacja opisuje jej metody jako synchroniczne, a `DatabaseSync` jest nazwą historyczną/aliasem.

Dodanie `async`/`await` albo opakowanie synchronicznej funkcji w `Promise` **nie** przenosi pracy SQLite poza główny wątek i nie zapobiega blokowaniu event loop. Przykład `Promise.resolve().then(() => db.prepare(...).all())` nadal wykonuje zapytanie synchronicznie.

Jeśli operacje mają nie blokować głównego wątku, można:

- uruchomić pracę z `node:sqlite` w `worker_threads` (warto użyć długowiecznego workera/puli zamiast tworzyć nowy wątek dla każdego zapytania);
- wybrać bibliotekę oferującą asynchroniczne API, np. `sqlite3`.

`better-sqlite3` również udostępnia API synchroniczne.

## Ważne sprostowanie

Wcześniejsza odpowiedź w rozmowie błędnie zasugerowała asynchroniczną klasę `Database` w `node:sqlite` oraz podała nieprawidłowe przykłady metod Promise (`finalize`, asynchroniczne `exec`/`close`). Tych przykładów nie należy używać dla wbudowanego `node:sqlite`.
