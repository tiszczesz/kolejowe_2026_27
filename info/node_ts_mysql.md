# Konsolowa aplikacja CRUD w Node.js, TypeScript i MySQL

Przykład pokazuje prostą aplikację terminalową do zarządzania produktami w tabeli `items`. Używa `mysql2/promise`, TypeScriptu i `readline/promises`. Operacje SQL korzystają z parametrów, a nie z konkatenacji danych użytkownika.

## Wymagania

- Node.js 20 lub nowszy
- działający serwer MySQL
- baza i użytkownik MySQL z prawem odczytu oraz zapisu

## Utworzenie projektu i instalacja

```bash
mkdir node-ts-mysql
cd node-ts-mysql
npm init -y
npm install mysql2 dotenv
npm install --save-dev typescript tsx @types/node
npm pkg set type=module "scripts.dev=tsx src/index.ts" "scripts.build=tsc" "scripts.start=node dist/index.js"
mkdir src
```

Utwórz `tsconfig.json`:

```json
{
  "compilerOptions": {
    "target": "ES2022",
    "module": "NodeNext",
    "moduleResolution": "NodeNext",
    "rootDir": "src",
    "outDir": "dist",
    "strict": true,
    "esModuleInterop": true,
    "skipLibCheck": true
  },
  "include": ["src/**/*.ts"]
}
```

## Baza danych

Zaloguj się do MySQL, a następnie wykonaj skrypt. Nazwa bazy musi odpowiadać `DB_NAME` w pliku `.env`.

```sql
CREATE DATABASE node_ts_mysql
  CHARACTER SET utf8mb4
  COLLATE utf8mb4_unicode_ci;

USE node_ts_mysql;

CREATE TABLE items (
  id INT UNSIGNED NOT NULL AUTO_INCREMENT,
  name VARCHAR(120) NOT NULL,
  quantity INT UNSIGNED NOT NULL DEFAULT 0,
  created_at TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (id)
);
```

## Konfiguracja połączenia

Utwórz `.env` w katalogu projektu i uzupełnij dane dla swojego serwera:

```dotenv
DB_HOST=localhost
DB_PORT=3306
DB_USER=app_user
DB_PASSWORD=zmien_to
DB_NAME=node_ts_mysql
```

Nie zapisuj prawdziwych haseł w repozytorium. Dodaj do `.gitignore`:

```gitignore
node_modules/
dist/
.env
```

## Aplikacja CRUD

Zapisz poniższy kod jako `src/index.ts`:

```ts
import "dotenv/config";
import { createInterface } from "node:readline/promises";
import { stdin as input, stdout as output } from "node:process";
import mysql, {
  type ResultSetHeader,
  type RowDataPacket,
} from "mysql2/promise";

interface Item extends RowDataPacket {
  id: number;
  name: string;
  quantity: number;
  created_at: Date;
}

function requiredEnv(name: string): string {
  const value = process.env[name];
  if (!value) {
    throw new Error(`Brak wymaganej zmiennej środowiskowej ${name}`);
  }
  return value;
}

const pool = mysql.createPool({
  host: requiredEnv("DB_HOST"),
  port: Number(process.env.DB_PORT ?? 3306),
  user: requiredEnv("DB_USER"),
  password: requiredEnv("DB_PASSWORD"),
  database: requiredEnv("DB_NAME"),
  waitForConnections: true,
  connectionLimit: 10,
});

const rl = createInterface({ input, output });

async function askName(): Promise<string> {
  while (true) {
    const name = (await rl.question("Nazwa: ")).trim();
    if (name.length > 0 && name.length <= 120) return name;
    console.log("Nazwa musi mieć od 1 do 120 znaków.");
  }
}

async function askNonNegativeInt(prompt: string): Promise<number> {
  while (true) {
    const value = Number((await rl.question(prompt)).trim());
    if (Number.isSafeInteger(value) && value >= 0) return value;
    console.log("Podaj nieujemną liczbę całkowitą.");
  }
}

async function askId(): Promise<number> {
  while (true) {
    const value = Number((await rl.question("ID: ")).trim());
    if (Number.isSafeInteger(value) && value > 0) return value;
    console.log("Podaj dodatni identyfikator liczbowy.");
  }
}

async function createItem(): Promise<void> {
  const name = await askName();
  const quantity = await askNonNegativeInt("Ilość: ");
  const [result] = await pool.execute<ResultSetHeader>(
    "INSERT INTO items (name, quantity) VALUES (?, ?)",
    [name, quantity],
  );
  console.log(`Dodano produkt o ID ${result.insertId}.`);
}

async function listItems(): Promise<void> {
  const [items] = await pool.execute<Item[]>(
    "SELECT id, name, quantity, created_at FROM items ORDER BY id",
  );
  if (items.length === 0) {
    console.log("Brak produktów.");
    return;
  }

  for (const item of items) {
    console.log(`${item.id}: ${item.name} | ilość: ${item.quantity}`);
  }
}

async function findItem(): Promise<void> {
  const id = await askId();
  const [items] = await pool.execute<Item[]>(
    "SELECT id, name, quantity, created_at FROM items WHERE id = ?",
    [id],
  );
  const item = items[0];
  if (!item) {
    console.log("Nie znaleziono produktu.");
    return;
  }
  console.log(`${item.id}: ${item.name} | ilość: ${item.quantity}`);
}

async function updateItem(): Promise<void> {
  const id = await askId();
  const name = await askName();
  const quantity = await askNonNegativeInt("Nowa ilość: ");
  const [result] = await pool.execute<ResultSetHeader>(
    "UPDATE items SET name = ?, quantity = ? WHERE id = ?",
    [name, quantity, id],
  );
  console.log(result.affectedRows > 0 ? "Zaktualizowano produkt." : "Nie znaleziono produktu.");
}

async function deleteItem(): Promise<void> {
  const id = await askId();
  const confirmation = (await rl.question(`Usunąć produkt ${id}? (t/N): "))
    .trim()
    .toLowerCase();
  if (confirmation !== "t") {
    console.log("Anulowano.");
    return;
  }

  const [result] = await pool.execute<ResultSetHeader>(
    "DELETE FROM items WHERE id = ?",
    [id],
  );
  console.log(result.affectedRows > 0 ? "Usunięto produkt." : "Nie znaleziono produktu.");
}

async function main(): Promise<void> {
  while (true) {
    console.log("\n--- Produkty ---");
    console.log("1. Dodaj produkt");
    console.log("2. Wyświetl wszystkie");
    console.log("3. Znajdź po ID");
    console.log("4. Zaktualizuj produkt");
    console.log("5. Usuń produkt");
    console.log("0. Zakończ");

    const choice = (await rl.question("Wybór: ")).trim();
    try {
      switch (choice) {
        case "1":
          await createItem();
          break;
        case "2":
          await listItems();
          break;
        case "3":
          await findItem();
          break;
        case "4":
          await updateItem();
          break;
        case "5":
          await deleteItem();
          break;
        case "0":
          return;
        default:
          console.log("Nieznana opcja.");
      }
    } catch (error) {
      console.error("Operacja nie powiodła się:", error);
    }
  }
}

main()
  .catch((error: unknown) => {
    console.error("Nie udało się uruchomić aplikacji:", error);
    process.exitCode = 1;
  })
  .finally(async () => {
    rl.close();
    await pool.end();
  });
```

## Uruchomienie

Tryb deweloperski (bez wcześniejszej kompilacji):

```bash
npm run dev
```

Kompilacja i uruchomienie JavaScriptu z katalogu `dist`:

```bash
npm run build
npm start
```

## Jak działa CRUD?

- **Create** — `INSERT` dodaje produkt; identyfikator zwraca `insertId`.
- **Read** — `SELECT` odczytuje wszystkie produkty albo wyszukuje je po ID.
- **Update** — `UPDATE` zmienia nazwę i ilość; `affectedRows` informuje, czy znaleziono rekord.
- **Delete** — `DELETE` usuwa rekord po ID po potwierdzeniu.

Wartości takie jak nazwa i ID są przekazywane w tablicy parametrów (`?`). Nie wstawiaj danych użytkownika bezpośrednio do tekstu SQL — parametryzowane zapytania chronią przed SQL injection. Nazwy tabel i kolumn w tym przykładzie są stałe, bo parametrów SQL nie można używać jako zamienników identyfikatorów.