// alert("Good morning, World!");
import { colors } from "./data.js";
import { createSelect, createColorBox } from "./elements.js";

createSelect(colors, "root");
createColorBox("root");
document.querySelector<HTMLSelectElement>("#colorSelect")
    ?.addEventListener("change", (event) => {
        const box = document.querySelector<HTMLDivElement>("#colorBox");
        if (box) {
            const select = event.target as HTMLSelectElement;
            box.style.backgroundColor = select.value;
        }
    });
//dodać input type number i przycisk do generowania listy
//ul z elementami li text: Element nr {1, 2, 3, ...} 