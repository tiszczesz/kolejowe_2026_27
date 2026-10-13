export function createSelect(options: string[],elementId: string = "root"): void {
    const select = document.createElement("select");
    select.id = "colorSelect";
    for (const option of options) {
        const optionElement = document.createElement("option");
        optionElement.value = option;
        optionElement.textContent = option;
        select.appendChild(optionElement);
    }
    const rootElement = document.querySelector<HTMLDivElement>(`#${elementId}`);
    if (rootElement) {
        rootElement.appendChild(select);
    }

}
export function createDiv(elementId: string = "root"): void {
    const div = document.createElement("div");
    div.id = "colorDiv";
    div.style.width = "200px";
    div.style.height = "200px";
    div.style.border = "1px solid black";
    const rootElement = document.querySelector<HTMLDivElement>(`#${elementId}`);
    if (rootElement) {
        rootElement.appendChild(div);
    }
}