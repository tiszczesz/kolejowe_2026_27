## Zadanie w NODE.js

Używając menu (modyfikuj) :

1. Napisz aplikacje Todos
    a. Użycie obiektu 
    ```ts
        type Todo = {
            id: number;
            title: string;
            content: string;
            status: "done" | "undone" | "fail";
            endDate: Date
        }
    ```
 Stan danego todo wyświetlaj jako `zrobione` `dozrobienia` `nie zrobione` 

2. W menu mamy opcje Pobierz z pliku `todos.json`

   a. dodać nowe todo

   b. wyświetlić informacje o wszystkich todo

   c. usunąć todo po `id`

   d. zmienic stan todo o danym `id`
  
   e. zapisać zmiany do pliku `todos.json`

   