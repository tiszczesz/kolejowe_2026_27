export function createSelect(options: string[], containerId: string): void {
    const selectElement = document.createElement("select");
    selectElement.id = "colorSelect";
    for (const option of options) {
        const optionElement = document.createElement("option");
        optionElement.value = option;
        optionElement.textContent = option;
        selectElement.appendChild(optionElement);
    }
    const container = document.querySelector<HTMLDivElement>(`#${containerId}`);
    if (container) {
        container.appendChild(selectElement);
    }
}
export function createColorBox(containerId: string): void {
    const divElement = document.createElement("div");
    divElement.id = "colorBox";
    divElement.style.width = "100px";
    divElement.style.height = "100px";
    divElement.style.border = "1px solid black";
    const container = document.querySelector<HTMLDivElement>(`#${containerId}`);
    if (container) {
        container.appendChild(divElement);
    }
}