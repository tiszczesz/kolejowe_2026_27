import * as readline from 'node:readline/promises';
import { stdin as input, stdout as output } from 'node:process';

//import readline from 'node:readline/promises';

//utworzenie interfejsu do  dialogu z użytkownikiem
// const rl = readline.createInterface({ input, output });
const rl: readline.Interface = readline.createInterface({
    input: process.stdin,
    output: process.stdout
})

const firstname = await rl.question("Podaj imię: ");
const lastname = await rl.question("Podaj nazwisko: ");
let age: number = parseInt(await rl.question("Podaj wiek: "));
age = isNaN(age) ? 20 : age;
rl.close();
console.log(firstname, lastname, age);