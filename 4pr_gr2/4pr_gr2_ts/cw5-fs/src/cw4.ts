import readline from "node:readline/promises";

//tworzenie interfejsu do wprowadzania danych z konsoli
const rl = readline.createInterface({
    input: process.stdin,
    output: process.stdout
});
async function main() {
    const firstname = await rl.question("Podaj imię: ");
    const lastname = await rl.question("Podaj nazwisko: ");
    const age = parseInt(await rl.question("Podaj wiek: "))
    console.log(firstname,lastname,age);
    
    rl.close();
}
main();