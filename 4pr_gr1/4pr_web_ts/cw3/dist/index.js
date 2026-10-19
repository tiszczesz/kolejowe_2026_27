import { colors } from './data.js';
import { createSelect, createDiv } from './elemnts.js';
createSelect(colors, "root");
createDiv("root");
document.querySelector("#colorSelect")?.addEventListener("change", (event) => {
    //todo: change the color of the div based on the selected option
    const colorDiv = document.querySelector("#colorDiv");
    if (colorDiv !== null) {
        colorDiv.style.backgroundColor = event.target.value;
    }
});
//# sourceMappingURL=index.js.map