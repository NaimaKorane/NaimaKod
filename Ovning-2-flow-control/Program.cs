using System;

// Variabel som håller programmet igång
bool isRunning = true;

// Loop som körs tills användaren avslutar programmet
while (isRunning)
{
    // Huvudmeny
    Console.WriteLine("Huvudmeny");
    Console.WriteLine("Skriv en siffra:");
    Console.WriteLine("0. Avsluta");
    Console.WriteLine("1. Ungdom eller pensionär");
    Console.WriteLine("2. Räkna pris för sällskap");
    Console.WriteLine("3. Upprepa text 10 gånger");
    Console.WriteLine("4. Hitta tredje ordet");

    // Läser in användarens val
    string input = Console.ReadLine();

    // Hanterar menyval
    switch (input)
    {
        // Menyval 0 - Avsluta programmet
        case "0":
            isRunning = false;
            Console.WriteLine("Programmet avslutas.");
            break;

        // Menyval 1 - Kontrollera biljettpris beroende på ålder
        case "1":

            Console.WriteLine("Ange din ålder:");

            int age = int.Parse(Console.ReadLine());

            // Ungdomspris
            if (age < 20)
            {
                Console.WriteLine("Ungdomspris: 80kr");
            }

            // Pensionärspris
            else if (age > 64)
            {
                Console.WriteLine("Pensionärspris: 90kr");
            }

            // Standardpris
            else
            {
                Console.WriteLine("Standardpris: 120kr");
            }

            break;

        // Menyval 2 - Räkna ut pris för ett sällskap
        case "2":
        {
            Console.WriteLine("Hur många personer är ni?");
            int numberOfPeople = int.Parse(Console.ReadLine());

            // Variabel för att spara totalkostnaden
            int totalCost = 0;

            // Loop som går igenom alla personer
            for (int i = 1; i <= numberOfPeople; i++)
            {
                Console.WriteLine($"Ange ålder för person {i}:");
                int personAge = int.Parse(Console.ReadLine());

                // Ungdomspris
                if (personAge < 20)
                {
                    totalCost += 80;
                }

                // Pensionärspris
                else if (personAge > 64)
                {
                    totalCost += 90;
                }

                // Standardpris
                else
                {
                    totalCost += 120;
                }
            }

            // Skriver ut resultat
            Console.WriteLine($"Antal personer: {numberOfPeople}");
            Console.WriteLine($"Totalkostnad: {totalCost}kr");

            break;
        }

        // Menyval 3 - Upprepa text 10 gånger
        case "3":
        {
            Console.Write("Skriv en text: ");
            string text = Console.ReadLine();

            // Loop som skriver ut texten 10 gånger
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine($"{i}. {text}");
            }

            break;
        }

        // Menyval 4 - Hitta tredje ordet i en mening
        case "4":
        {
            Console.WriteLine("Skriv en mening med minst tre ord:");

            // Läser in en mening från användaren
            string sentence = Console.ReadLine();

            // Delar upp meningen i ord
            string[] words = sentence.Split(' ');

            // Kontrollerar att det finns minst tre ord
            if (words.Length >= 3)
            {
                Console.WriteLine($"Det tredje ordet är: {words[2]}");
            }
            else
            {
                Console.WriteLine("Du skrev inte minst tre ord.");
            }

            break;
        }

        // Om användaren skriver fel menyval
        default:
            Console.WriteLine("Felaktig input. Försök igen.");
            break;
    }
}