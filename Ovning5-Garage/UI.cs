namespace Ovning5_Garage;

public class UI : IUI
{
    private GarageHandler? garageHandler;

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
            Console.WriteLine("3. Sök via registreringsnummer");
            Console.WriteLine("4. Lista alla fordon");
            Console.WriteLine("5. Lista fordonstyper");
            Console.WriteLine("6. Sök på fordonstyp");
            Console.WriteLine("7. Sök på färg");
            Console.WriteLine("8. Sök på antal hjul");
            Console.WriteLine("9. Sök på färg och hjul");
            Console.WriteLine("0. Avsluta");
            Console.WriteLine("Välj ett alternativ:");

            string choice = (Console.ReadLine() ?? "").Trim();

            switch (choice)
            {
                case "1":
                    AddVehicleMenu();
                    break;

                case "2":
                    RemoveVehicleMenu();
                    break;

                case "3":
                    SearchByRegistrationNumberMenu();
                    break;

                case "4":
                    Console.WriteLine("Alla fordon:");
                    PrintVehicles(garageHandler!.GetAllVehicles());
                    break;

                case "5":
                    PrintVehicleTypeCounts();
                    break;

                case "6":
                    SearchByTypeMenu();
                    break;

                case "7":
                    SearchByColorMenu();
                    break;

                case "8":
                    SearchByWheelsMenu();
                    break;

                case "9":
                    SearchByColorAndWheelsMenu();
                    break;

                case "0":
                    running = false;
                    break;

                default:
                    Console.WriteLine("Felaktigt val.");
                    break;
            }
        }
    }

    private void AddVehicleMenu()
    {
        Console.WriteLine("Vilken fordonstyp vill du lägga till?");
        Console.WriteLine("1. Car");
        Console.WriteLine("2. Airplane");
        Console.WriteLine("3. Motorcycle");
        Console.WriteLine("4. Bus");
        Console.WriteLine("5. Boat");

        string typeChoice = (Console.ReadLine() ?? "").Trim();

        Console.WriteLine("Registreringsnummer:");
        string regNr = Console.ReadLine() ?? "";

        Console.WriteLine("Färg:");
        string color = Console.ReadLine() ?? "";

        int numberOfWheels = ReadInt("Antal hjul:");

        Vehicle? vehicle = null;

        switch (typeChoice)
        {
            case "1":
                Console.WriteLine("Bränsletyp:");
                string fuelType = Console.ReadLine() ?? "";
                vehicle = new Car(regNr, color, numberOfWheels, fuelType);
                break;

            case "2":
                int numberOfEngines = ReadInt("Antal motorer:");
                vehicle = new Airplane(regNr, color, numberOfWheels, numberOfEngines);
                break;

            case "3":
                int cylinderVolume = ReadInt("Cylindervolym:");
                vehicle = new Motorcycle(regNr, color, numberOfWheels, cylinderVolume);
                break;

            case "4":
                int numberOfSeats = ReadInt("Antal säten:");
                vehicle = new Bus(regNr, color, numberOfWheels, numberOfSeats);
                break;

            case "5":
                double length = ReadDouble("Längd:");
                vehicle = new Boat(regNr, color, numberOfWheels, length);
                break;

            default:
                Console.WriteLine("Felaktig fordonstyp.");
                return;
        }

        if (garageHandler!.AddVehicle(vehicle))
        {
            Console.WriteLine("Fordon tillagt.");
        }
        else
        {
            Console.WriteLine("Kunde inte lägga till fordon. Garaget kan vara fullt eller registreringsnumret kan redan finnas.");
        }
    }

    private void RemoveVehicleMenu()
    {
        Console.WriteLine("Ange registreringsnummer på fordonet du vill ta bort:");
        string registrationNumber = Console.ReadLine() ?? "";

        if (garageHandler!.RemoveVehicle(registrationNumber))
        {
            Console.WriteLine("Fordon borttaget.");
        }
        else
        {
            Console.WriteLine("Fordonet finns inte.");
        }
    }

    private void SearchByRegistrationNumberMenu()
    {
        Console.WriteLine("Registreringsnummer:");
        string searchRegNr = Console.ReadLine() ?? "";

        Vehicle? foundVehicle = garageHandler!.FindByRegistrationNumber(searchRegNr);

        if (foundVehicle != null)
        {
            Console.WriteLine("Fordon hittat:");
            PrintVehicle(foundVehicle);
        }
        else
        {
            Console.WriteLine("Fordonet finns inte.");
        }
    }

    private void SearchByTypeMenu()
    {
        Console.WriteLine("Ange fordonstyp: Car, Airplane, Motorcycle, Bus eller Boat");
        string type = Console.ReadLine() ?? "";

        PrintVehicles(garageHandler!.FindByType(type));
    }

    private void SearchByColorMenu()
    {
        Console.WriteLine("Ange färg:");
        string color = Console.ReadLine() ?? "";

        PrintVehicles(garageHandler!.FindByColor(color));
    }

    private void SearchByWheelsMenu()
    {
        int wheels = ReadInt("Ange antal hjul:");

        PrintVehicles(garageHandler!.FindByWheels(wheels));
    }

    private void SearchByColorAndWheelsMenu()
    {
        Console.WriteLine("Ange färg:");
        string color = Console.ReadLine() ?? "";

        int wheels = ReadInt("Ange antal hjul:");

        PrintVehicles(garageHandler!.FindByColorAndWheels(color, wheels));
    }

    private void PrintVehicleTypeCounts()
    {
        Console.WriteLine("Fordonstyper i garaget:");

        Dictionary<string, int> counts = garageHandler!.GetVehicleTypeCounts();

        Console.WriteLine($"Car: {(counts.ContainsKey("Car") ? counts["Car"] : 0)}");
        Console.WriteLine($"Airplane: {(counts.ContainsKey("Airplane") ? counts["Airplane"] : 0)}");
        Console.WriteLine($"Motorcycle: {(counts.ContainsKey("Motorcycle") ? counts["Motorcycle"] : 0)}");
        Console.WriteLine($"Bus: {(counts.ContainsKey("Bus") ? counts["Bus"] : 0)}");
        Console.WriteLine($"Boat: {(counts.ContainsKey("Boat") ? counts["Boat"] : 0)}");
    }

    private void PrintVehicles(IEnumerable<Vehicle> vehicles)
    {
        bool found = false;

        foreach (Vehicle vehicle in vehicles)
        {
            PrintVehicle(vehicle);
            found = true;
        }

        if (!found)
        {
            Console.WriteLine("Inga fordon hittades.");
        }
    }

    private void PrintVehicle(Vehicle vehicle)
    {
        Console.WriteLine($"{vehicle.GetType().Name} - {vehicle.RegistrationNumber} - {vehicle.Color} - {vehicle.NumberOfWheels} hjul");

        if (vehicle is Car car)
        {
            Console.WriteLine($"Bränsletyp: {car.FuelType}");
        }
        else if (vehicle is Airplane airplane)
        {
            Console.WriteLine($"Antal motorer: {airplane.NumberOfEngines}");
        }
        else if (vehicle is Motorcycle motorcycle)
        {
            Console.WriteLine($"Cylindervolym: {motorcycle.CylinderVolume}");
        }
        else if (vehicle is Bus bus)
        {
            Console.WriteLine($"Antal säten: {bus.NumberOfSeats}");
        }
        else if (vehicle is Boat boat)
        {
            Console.WriteLine($"Längd: {boat.Length}");
        }
    }

    private int ReadInt(string message)
    {
        Console.WriteLine(message);

        if (int.TryParse(Console.ReadLine(), out int value))
        {
            return value;
        }

        Console.WriteLine("Felaktigt tal. Värdet sätts till 0.");
        return 0;
    }

    private double ReadDouble(string message)
    {
        Console.WriteLine(message);

        if (double.TryParse(Console.ReadLine(), out double value))
        {
            return value;
        }

        Console.WriteLine("Felaktigt tal. Värdet sätts till 0.");
        return 0;
    }
}