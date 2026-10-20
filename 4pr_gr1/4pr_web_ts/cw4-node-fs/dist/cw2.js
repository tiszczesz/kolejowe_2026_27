import { readFile, writeFile } from "fs/promises";
// const result = await readFile("data2.txt", "utf-8");
// console.log("File read successfully");
// console.log(result);
readFile("data2.txt", "utf-8")
    .then((result) => {
    console.log("File read successfully");
    console.log(result);
})
    .catch((error) => {
    console.error("Error reading file:", error);
});
const txt = [
    "ala ma kota",
    "kot ma ale",
    "ale ma alę",
    "lorem ipsum ala",
    "ala to jest asynchroniczny zapis do pliku"
];
await writeFile("out2.txt", txt.join("\n"), "utf-8");
console.log("File written successfully");
//# sourceMappingURL=cw2.js.map