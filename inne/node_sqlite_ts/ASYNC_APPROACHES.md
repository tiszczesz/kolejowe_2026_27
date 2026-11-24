/**
 * PORÓWNANIE: node:sqlite vs inne podejścia do asynchroniczności
 * 
 * ============================================================================
 * 1. node:sqlite (synchroniczny - DatabaseSync)
 * ============================================================================
 * - Pro: Built-in, szybki, brak dependency
 * - Con: Blokuje event loop
 * 
 * Użyj kiedy: Backend worker, offline app, CLI tools
 * 
 * ```typescript
 * const db = new DatabaseSync("MyDb.db");
 * const result = db.prepare("SELECT * FROM Books").all();
 * db.close();
 * ```
 * 
 * 
 * ============================================================================
 * 2. Wrappowanie node:sqlite w Promise (Opcja 1)
 * ============================================================================
 * - Pro: Pseudo-asynchroniczny, brak dependency, prosty
 * - Con: Nadal blokuje event loop, nie "prawdziwie" async
 * 
 * Użyj kiedy: Chcesz async/await API ale operacje są szybkie
 * 
 * ```typescript
 * async function readData() {
 *   return await runAsync(() => {
 *     return db.prepare("SELECT * FROM Books").all();
 *   });
 * }
 * ```
 * 
 * 
 * ============================================================================
 * 3. Worker Threads (Opcja 2)
 * ============================================================================
 * - Pro: Prawdziwie asynchroniczny, nie blokuje main thread
 * - Con: Skomplikowany setup, overhead per operacji
 * 
 * Użyj kiedy: Heavy DB operations, nie chcesz blokować UI/HTTP handler
 * 
 * ```typescript
 * await runInWorker("read", args);
 * ```
 * 
 * 
 * ============================================================================
 * 4. External library: sqlite3 package (npm install sqlite3)
 * ============================================================================
 * - Pro: Prawdziwie asynchroniczny callback API
 * - Con: Callback hell, starsza biblioteka
 * 
 * ```typescript
 * const sqlite3 = require('sqlite3').verbose();
 * const db = new sqlite3.Database(':memory:');
 * db.run("SELECT * FROM Books", (err, row) => {});
 * ```
 * 
 * 
 * ============================================================================
 * 5. External library: better-sqlite3 (npm install better-sqlite3)
 * ============================================================================
 * - Pro: Bardzo szybki, synchroniczny, natywny
 * - Con: Wymaga kompilacji C++, blokuje event loop
 * 
 * ```typescript
 * import Database from 'better-sqlite3';
 * const db = new Database('MyDb.db');
 * const stmt = db.prepare('SELECT * FROM Books');
 * const all = stmt.all();
 * ```
 * 
 * 
 * ============================================================================
 * 6. External library: sql.js (npm install sql.js)
 * ============================================================================
 * - Pro: Pure JavaScript, in-memory SQLite
 * - Con: Mniej features, only in-memory
 * 
 * ```typescript
 * const SQL = await initSqlJs();
 * const db = new SQL.Database();
 * ```
 * 
 * 
 * ============================================================================
 * REKOMENDACJE:
 * ============================================================================
 * 
 * CLI Tools / Skrypty:               → node:sqlite (DatabaseSync)
 * HTTP Server (szybkie operacje):    → node:sqlite (DatabaseSync) + Opcja 1
 * HTTP Server (heavy operacje):      → Worker Threads (Opcja 2)
 * Legacy project:                    → sqlite3 package
 * Performance critical:              → better-sqlite3
 * Browser / WASM:                    → sql.js
 * 
 */

console.log("Patrz plik dokumentacji powyżej!");
