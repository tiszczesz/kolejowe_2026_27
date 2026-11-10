-- BooksDb_Sqlite.sql
CREATE TABLE IF NOT EXISTS Books (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    title TEXT NOT NULL,
    author TEXT NOT NULL,
    published_year INTEGER,
    genre TEXT,
    price REAL
);

INSERT INTO Books (title, author, published_year, genre, price) VALUES
    ('The Hobbit', 'J.R.R. Tolkien', 1937, 'Fantasy', 29.99),
    ('Pride and Prejudice', 'Jane Austen', 1813, 'Romance', 24.50),
    ('1984', 'George Orwell', 1949, 'Dystopian', 27.00),
    ('To Kill a Mockingbird', 'Harper Lee', 1960, 'Fiction', 32.99),
    ('The Great Gatsby', 'F. Scott Fitzgerald', 1925, 'Fiction', 22.00),
    ('Dune', 'Frank Herbert', 1965, 'Science Fiction', 35.50),
    ('The Little Prince', 'Antoine de Saint-Exupéry', 1943, 'Fable', 19.99),
    ('The Catcher in the Rye', 'J.D. Salinger', 1951, 'Coming-of-age', 26.75),
    ('Murder on the Orient Express', 'Agatha Christie', 1934, 'Mystery', 28.00),
    ('The Name of the Rose', 'Umberto Eco', 1980, 'Historical Fiction', 31.25);
