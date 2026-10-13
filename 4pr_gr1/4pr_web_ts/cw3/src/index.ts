import {colors} from './data.js';
import { createSelect,createDiv } from './elemnts.js';

createSelect(colors, "root");
createDiv("root");
document.querySelector<HTMLSelectElement>("#colorSelect")?.addEventListener("change", (event) => {
    
});