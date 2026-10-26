import {readFileSync,writeFileSync} from "fs";
//odczytanie pliku tekstowego synchronicznie
const result = readFileSync("dane.txt", "utf-8");
console.log(result);

const text1 = [
    "Hello, World!",
    "This is a test file.",
    "It contains multiple lines of text.",
    "Each line is separated by a newline character.",
    "This is the last line."
];
//zapisanie pliku tekstowego synchronicznie
writeFileSync("dane2.txt", text1.join("\n"), "utf-8");