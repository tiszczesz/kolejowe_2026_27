export function createSelect(options, containerId) {
    const selectElement = document.createElement("select");
    selectElement.id = "colorSelect";
    for (const option of options) {
        const optionElement = document.createElement("option");
        optionElement.value = option;
        optionElement.textContent = option;
        selectElement.appendChild(optionElement);
    }
}
//# sourceMappingURL=elements.js.map