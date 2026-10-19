import { readFileSync, writeFileSync } from "node:fs";
//czytanie pliku data.txt w formacie utf8 synchronicznie
const result = readFileSync("data.txt", "utf8");
console.log(result);
const txt = [
    "ala ma kota",
    "kot ma ale",
    "ale ma alę",
    "lorem ipsum ala"
];
// zapisanie tablicy txt do pliku data.txt w formacie utf8 synchronicznie
writeFileSync("out.txt", txt.join("\n"), "utf8");
//# sourceMappingURL=cw1.js.map