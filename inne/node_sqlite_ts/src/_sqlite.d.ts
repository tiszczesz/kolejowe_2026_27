declare module "node:sqlite" {
  export interface Statement {
    run(...params: any[]): Promise<void>;
    all(): Promise<any[]>;
    get(...params: any[]): Promise<any>;
    finalize(): Promise<void>;
    close(): Promise<void>;
  }

  export interface Database {
    prepare(sql: string): Promise<Statement>;
    exec(sql: string): Promise<void>;
    close(): Promise<void>;
  }

  export interface DatabaseSync {
    prepare(sql: string): any;
    exec(sql: string): void;
    close(): void;
  }

  export class DatabaseSync implements DatabaseSync {
    constructor(filename: string);
    prepare(sql: string): any;
    exec(sql: string): void;
    close(): void;
  }

  export function Database(filename: string): Database;
  export class Database {
    constructor(filename: string);
    prepare(sql: string): Promise<Statement>;
    exec(sql: string): Promise<void>;
    close(): Promise<void>;
  }
}

