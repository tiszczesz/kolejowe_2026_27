import readline from 'readline/promises'
export const menu = async () => {
    const rl = readline.createInterface({
        input: process.stdin,
        output: process.stdout
    });
    let option = 'k'
    do {
        console.log(` ------------------ M E N U --------------------------
                  1. Wczytaj dane
                  2. Wyswietl dane
                  k. Zakończ program\n`);
        const answer = await rl.question("\tWybierz opcje: ");
        option = answer[0] ?? 'k';
        switch (option) {
            case '1': {
                console.log("wczytanie danych");
                break;
            }
            case '2': {
                console.log("wyświetlenie danych");
                break;
            }
            case 'k': break;
            default : console.log("BŁĘDNA OPCJA!!!!!");
        }
    } while (option !== 'k');
    console.log( " -------- zakończenie programu ---------")
    rl.close();
}

