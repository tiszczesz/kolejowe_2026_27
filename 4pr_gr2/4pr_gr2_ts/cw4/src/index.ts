import { movies, type Movie } from "./data.js";
import { generTab } from "./components.js";
const root = document.querySelector<HTMLDivElement>("#root");
if (root !== null) {
    generTab(movies, root)
}