import { students, type Student } from "./data.js";

export const GenerTab = (data: Student[], elem: HTMLDivElement) => {
    //generowanie tabeli
    const tab = document.createElement("table");
    tab.classList.add("table", "table-striped");
    const thead = document.createElement("thead");
    tab.appendChild(thead);
    thead.innerHTML = `
        <tr>
            <th>Imię</th>
            <th>Nazwisko</th>
            <th>Wiek</th>
        </tr>
    `;
    const tbody = document.createElement("tbody");
    for (const s of data) {
        const tr = document.createElement("tr");
        tr.innerHTML = `
            <td>${s.firstname}</td>
            <td>${s.lastname}</td>
            <td>${s.age}</td>
        `;
        tbody.appendChild(tr);
    }
    tab.appendChild(tbody);
    elem.appendChild(tab);
}