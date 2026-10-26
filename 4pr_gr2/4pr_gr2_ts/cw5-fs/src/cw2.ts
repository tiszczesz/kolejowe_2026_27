import {readFile, writeFile} from "fs/promises";
//odczytanie pliku tekstowego asynchronicznie
const result = await readFile("dane.txt", "utf-8");

console.log(result);
const text2 = [
    "Hello, World!",
    "This is a test file.",
    "It contains multiple lines of text.",
    "Each line is separated by a newline character.",
    "This is the last line."
];
//zapisanie pliku tekstowego asynchronicznie
await writeFile("dane3.txt", text2.join("\n"), "utf-8");
console.log("Zapisano plik dane3.txt");