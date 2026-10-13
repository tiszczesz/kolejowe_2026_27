export function createSelect(options: string[], containerId: string): void {
    const selectElement = document.createElement("select");
    selectElement.id = "colorSelect";
    for (const option of options) {
        const optionElement = document.createElement("option");
        optionElement.value = option;
        optionElement.textContent = option;
        selectElement.appendChild(optionElement);
    }
}