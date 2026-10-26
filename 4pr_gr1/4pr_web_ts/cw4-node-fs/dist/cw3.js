import { readFile, writeFile } from "fs/promises";
import {} from "./models.js";
const moviesJson = await readFile("movies.json", "utf-8");
const movies = JSON.parse(moviesJson);
console.log("Movies read successfully");
console.log(movies);
console.log(" -------- dodanie nowego filmu --------- ");
const newMovie = {
    id: 4,
    title: "The Dark Knight",
    director: "Christopher Nolan",
    year: 2008,
    genre: "Action"
};
movies.push(newMovie);
// zapisanie zaktualizowanej listy filmów do pliku
await writeFile("moviesResult.json", JSON.stringify(movies, null, 2), "utf-8");
console.log("New movie added and movies.json updated successfully");
//# sourceMappingURL=cw3.js.map