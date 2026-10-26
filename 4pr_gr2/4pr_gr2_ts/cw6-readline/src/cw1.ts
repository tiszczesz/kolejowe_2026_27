import * as readline from 'node:readline/promises';
//import { stdin as input, stdout as output } from 'node:process';
//utworzenie interfejsu readline
// const rl = readline.createInterface({ input, output });
const rl = readline.createInterface({
    input: process.stdin,
    output: process.stdout
});
const firstname = await rl.question("Podaj imię: ");
const lastname = await rl.question("Podaj nazwisko: ");
const age =  parseInt(await rl.question("Podaj wiek: "));
if (age < 18) {

    console.log(firstname, lastname, " niepełnoletni");
} else {
    console.log(firstname, lastname, " pełnoletni");
}

rl.close();