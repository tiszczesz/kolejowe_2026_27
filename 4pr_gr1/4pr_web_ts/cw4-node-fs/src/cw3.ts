import {readFile,writeFile} from "fs/promises";
import {type Movie} from "./models.js";

const moviesJson: string = await readFile("movies.json", "utf-8")
const movies: Movie[] = JSON.parse(moviesJson)
console.log("Movies read successfully");
console.log(movies);

console.log(" -------- dodanie nowego filmu --------- ");
const newMovie: Movie = {
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