-- create db

CREATE TABLE IF NOT EXISTS Courses (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    title TEXT NOT NULL,
    price decimal(10, 2) NOT NULL,
    date_start DATE NOT NULL
);

INSERT INTO Courses (title, price, date_start) VALUES
    ('Podstawy SQL', 299.00, '2025-03-10'),
    ('Programowanie w Pythonie', 499.00, '2025-03-17'),
    ('Tworzenie stron internetowych', 399.00, '2025-04-01'),
    ('Analiza danych', 599.00, '2025-04-14'),
    ('Wprowadzenie do uczenia maszynowego', 699.00, '2025-05-05');

