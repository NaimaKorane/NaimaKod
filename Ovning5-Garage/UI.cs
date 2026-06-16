namespace Ovning5_Garage;

public class UI : IUI
{
private GarageHandler? garageHandler ;    
    public void Start()
    {

        Console.WriteLine("Ange garagekapacitet:");

if (!int.TryParse(Console.ReadLine(), out int capacity))
{
    capacity = 10;
}

garageHandler = new GarageHandler(capacity);
        bool running = true;

        while (running)
        {
            Console.WriteLine("\n--- Garage Meny ---");
            Console.WriteLine("1. Lägg till fordon");
            Console.WriteLine("2. Ta bort fordon");
            Console.WriteLine("3. Sök fordon");
            Console.WriteLine("4. Lista alla fordon");
            Console.WriteLine("5. Lista fordonstyper");
            Console.WriteLine("6. Sök på färg");
            Console.WriteLine("7. Sök färg och hjul");
            Console.WriteLine("0. Avsluta");

            string choice = Console.ReadLine() ?? "";

            switch (choice)
            {
                case "1":
    Console.WriteLine("Registreringsnummer:");
    string regNr = Console.ReadLine() ?? "";

    Vehicle car = new Car(regNr, "Svart");

    if (garageHandler.AddVehicle(car))
    {
        Console.WriteLine("Fordon tillagt.");
    }
    else
    {
        Console.WriteLine("Kunde inte lägga till fordon.");
    }

    break;

                case "2":
    if (garageHandler.RemoveVehicle())
    {
        Console.WriteLine("Fordon borttaget.");
    }
    else
    {
        Console.WriteLine("Garaget är tomt.");
    }

    break;

                case "3":
    Console.WriteLine("Registreringsnummer:");
    string searchRegNr = Console.ReadLine() ?? "";

    Vehicle? foundVehicle =
        garageHandler.FindByRegistrationNumber(searchRegNr);

    if (foundVehicle != null)
    {
        Console.WriteLine("Fordon hittat!");
    }
    else
    {
        Console.WriteLine("Fordonet finns inte.");
    }

    break;
    case "4":
    Console.WriteLine("Parkerade fordon:");

    foreach (Vehicle vehicle in garageHandler.GetAllVehicles())
    {
        Console.WriteLine($"{vehicle.GetType().Name} - {vehicle.RegistrationNumber} - {vehicle.Color} - {vehicle.NumberOfWheels} hjul");
    }

    break;
    case "5":
    Console.WriteLine("Fordonstyper i garaget:");

    Dictionary<string, int> counts = garageHandler.GetVehicleTypeCounts();

    foreach (var item in counts)
    {
        Console.WriteLine($"{item.Key}: {item.Value}");
    }

    break;
    case "6":
    Console.WriteLine("Ange färg:");
    string color = Console.ReadLine() ?? "";

    foreach (Vehicle vehicle in garageHandler.FindByColor(color))
    {
        Console.WriteLine($"{vehicle.GetType().Name} - {vehicle.RegistrationNumber} - {vehicle.Color}");
    }

    break;
    case "7":
    Console.WriteLine("Ange färg:");
    string colorSearch = Console.ReadLine() ?? "";

    Console.WriteLine("Ange antal hjul:");

    if (!int.TryParse(Console.ReadLine(), out int wheels))
    {
        Console.WriteLine("Felaktigt antal hjul.");
        break;
    }

    foreach (Vehicle vehicle in garageHandler.FindByColorAndWheels(colorSearch, wheels))
    {
        Console.WriteLine($"{vehicle.GetType().Name} - {vehicle.RegistrationNumber} - {vehicle.Color} - {vehicle.NumberOfWheels} hjul");
    }

    break;

                case "0":
                    running = false;
                    break;

                default:
                    Console.WriteLine("Felaktigt val");
                    break;
            }
        }
    }
}