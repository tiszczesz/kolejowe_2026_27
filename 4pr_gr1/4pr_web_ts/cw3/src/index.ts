import {colors} from './data.js';
import { createSelect,createDiv } from './elemnts.js';

createSelect(colors, "root");
createDiv("root");
document.querySelector<HTMLSelectElement>("#colorSelect")?.addEventListener("change", (event) => {
    //todo: change the color of the div based on the selected option
});