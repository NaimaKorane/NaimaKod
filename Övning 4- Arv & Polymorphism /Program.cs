using System;
using System.Collections.Generic;
public interface ISchedulable
{
    DateTime NextRun { get; set; }

    void Schedule(DateTime time);
}
class Program
{
static void Main()
{
SmartHomeController controller = new SmartHomeController();

controller.AddDevice(new Washer("Samsung", "Laundry room", 8));
controller.AddDevice(new Refrigerator("Bosch", "Kitchen", 4));
controller.AddDevice(new Oven("Electrolux", "Kitchen", 250));
controller.AddDevice(new RobotVacuum("iRobot", "Living room", 80));
controller.AddDevice(new CoffeeMachine("Philips", "Kitchen", 6));
controller.AddDevice(new AirConditioner("LG", "Bedroom", 22));

controller.PrintStatusReport();

Console.WriteLine();

controller.TurnOnAll();

Console.WriteLine();

double totalEnergy = controller.GetTotalDailyEnergyUsage();
Console.WriteLine($"Total daily energy usage: {totalEnergy} kWh");

Console.WriteLine();

controller.TurnOffAll();
controller.ScheduleAllSchedulableDevices(DateTime.Now.AddHours(2));
SmartLamp lamp1 = new SmartLamp("IKEA", "Hallway", 80);
Appliance lamp2 = lamp1;

lamp1.TurnOn();
lamp2.TurnOn();
}
static void RunMorningRoutine(List<Appliance> devices)
{
foreach (Appliance device in devices)
{
    Console.WriteLine(device.GetInfo());
    device.TurnOn();
    device.TurnOff();
}
}
static void ReportAllEnergy(List<Appliance> devices)
{
foreach (Appliance device in devices)
{
    Console.WriteLine($"{device.GetInfo()} uses {device.GetDailyEnergyUsage()} kWh per day.");
}
}
}
class Washer : Appliance, ISchedulable
{
  
    public int CapacityKg { get; set; }
    public DateTime NextRun { get; set; }

public void Schedule(DateTime time)
{
    NextRun = time;
    Console.WriteLine($"{Brand} washer scheduled for {time}");
}
public Washer(string brand, string room, int capacityKg) : base(brand, room)
{

    CapacityKg = capacityKg;
}
public override string GetInfo()
{
    return $"{Brand} washer in {Room}";
}
// När virtual tas bort från TurnOn() kan child-klasserna
// inte längre använda override.
// Override kräver att metoden i basklassen är virtual,
// abstract eller override.
    public override void TurnOn()
    {
        Console.WriteLine($"{Brand} washing machine starts washing.");
    }

    public override void TurnOff()
{
    IsOn = false;
    Console.WriteLine($"{Brand} washing machine stops washing.");
}

   public override double GetDailyEnergyUsage()
{
    return 1.2;
}
}
class Refrigerator : Appliance
{
   
    public int Temperature { get; set; }
public Refrigerator(string brand, string room, int temperature) : base(brand, room)
{
    Temperature = temperature;
}
    public override double GetDailyEnergyUsage()
{
    return 3.6;
}

    public override void TurnOn()

{
        Console.WriteLine($"{Brand} refrigerator starts cooling.");
    }

    public override void TurnOff()
    {
        Console.WriteLine($"{Brand} refrigerator stops cooling.");
    }

    public void PrintCoolingEnergy()
    {
        Console.WriteLine($"{Brand} refrigerator uses energy at temperature {Temperature}.");
    }
}class Oven : Appliance
{
   
    public int MaxTemperature { get; set; }
    public Oven(string brand, string room, int maxTemperature)
    : base(brand, room)
{
    MaxTemperature = maxTemperature;
}
public override double GetDailyEnergyUsage()
{
    return 2.5;
}
public sealed override void TurnOn()
{
    Console.WriteLine($"{Brand} oven starts heating.");
}
    public void StartHeating()
    {
        Console.WriteLine($"{Brand} oven starts heating.");
    }

    public void StopHeating()
    {
        Console.WriteLine($"{Brand} oven stops heating.");
    }

    public void PrintHeatingEnergy()
    {
        Console.WriteLine($"{Brand} oven uses energy up to {MaxTemperature} degrees.");
    }
}class RobotVacuum : Appliance, ISchedulable
{
   
    public int BatteryLevel { get; set; }
    public DateTime NextRun { get; set; }

public void Schedule(DateTime time)
{
    NextRun = time;
    Console.WriteLine($"{Brand} robot vacuum scheduled for {time}");
}
public RobotVacuum(string brand, string room, int batteryLevel)
    : base(brand, room)
{
    BatteryLevel = batteryLevel;
}

   
    public void StartCleaning()
    {
        Console.WriteLine($"{Brand} robot vacuum starts cleaning.");
    }

    public void StopCleaning()
    {
        Console.WriteLine($"{Brand} robot vacuum stops cleaning.");
    }

    public void PrintCleaningEnergy()
    {
        Console.WriteLine($"{Brand} robot vacuum battery level: {BatteryLevel}%.");
    }
}


class CoffeeMachine : Appliance, ISchedulable
{
   
    public int CupsPerBrew { get; set; }
    public DateTime NextRun { get; set; }

public void Schedule(DateTime time)
{
    NextRun = time;
    Console.WriteLine($"{Brand} coffee machine scheduled for {time}");
}
public CoffeeMachine(string brand, string room, int cupsPerBrew) : base(brand, room)
{
    CupsPerBrew = cupsPerBrew;
}
    public override string GetInfo()
{
    return $"{Brand} coffee machine in {Room}";
}

public override void TurnOn()
{
    Console.WriteLine($"{Brand} coffee machine starts brewing.");
}

public override void TurnOff()
{
    Console.WriteLine($"{Brand} coffee machine stops brewing.");
}

public override double GetDailyEnergyUsage()
{
    return 0.3;
}
}

class Appliance
{
    public string Brand { get; }
    public string Room { get; }
    public bool IsOn { get; protected set; }

    public Appliance(string brand, string room)
    {
        Brand = brand;
        Room = room;
        IsOn = false;
    }

    public virtual string GetInfo()
    {
        return $"{Brand} in {Room}";
    }
// När virtual tas bort från TurnOn() kan child-klasserna
// inte längre använda override.
// Override kräver att metoden i basklassen är virtual,
// abstract eller override.
    public virtual void TurnOn()
    {
        IsOn = true;
        Console.WriteLine($"{Brand} appliance turns on.");
    }

    public virtual void TurnOff()
    {
        IsOn = false;
        Console.WriteLine($"{Brand} appliance turns off.");
    }

    public virtual double GetDailyEnergyUsage()
    {
        return 0;
    }
}
class Dishwasher : Appliance
{
    public int Programs { get; set; }

    public Dishwasher(string brand, string room, int programs) : base(brand, room)
    {
        Programs = programs;
    }

    public override string GetInfo()
    {
        return $"{Brand} dishwasher in {Room}";
    }

    public override void TurnOn()
    {
        Console.WriteLine($"{Brand} dishwasher starts washing dishes.");
    }

    public override void TurnOff()
    {
        Console.WriteLine($"{Brand} dishwasher stops washing dishes.");
    }

    public override double GetDailyEnergyUsage()
    {
        return 1.1;
    }
}

class SmartHomeController
{
    private List<Appliance> _devices = new List<Appliance>();

    public void AddDevice(Appliance device)
    {
        _devices.Add(device);
    }

public void TurnOnAll()
{
    foreach (Appliance device in _devices)
    {
        device.TurnOn();
    }
}
public void TurnOffAll()
{
    foreach (Appliance device in _devices)
    {
        device.TurnOff();
    }
}
public void PrintStatusReport()
{
    foreach (Appliance device in _devices)
    {
        Console.WriteLine(device.GetInfo());
    }
}
public void ScheduleAllSchedulableDevices(DateTime time)
{
    foreach (Appliance device in _devices)
    {
        if (device is ISchedulable schedulable)
        {
            schedulable.Schedule(time);
        }
    }
}
public double GetTotalDailyEnergyUsage()
{
    double totalEnergy = 0;

    foreach (Appliance device in _devices)
    {
        totalEnergy += device.GetDailyEnergyUsage();
    }

    return totalEnergy;
}

// Reflektionsfrågor efter Del 1

// 1. Jag behövde kontrollera typen eftersom listan är List<object>.
// Då vet inte C# automatiskt om objektet är en Washer, Refrigerator, Oven eller RobotVacuum.

// 2. Om jag lägger till CoffeeMachine måste jag skapa klassen och sedan uppdatera koden så att den hanteras.

// 3. Jag måste ändra Main(), RunMorningRoutine() och ReportAllEnergy().

// 4. Problemet med List<object> är att listan kan innehålla vad som helst.
// Därför måste jag själv kontrollera typ och casta innan jag kan använda rätt metoder.

// 5. Om jag glömmer en apparattyp i ReportAllEnergy() kommer den apparaten inte att rapportera energiförbrukning.



//  Del 5

// 1. Varför fungerar device.TurnOn() trots att device har typen Appliance?
// TurnOn() finns i basklassen Appliance. Alla klasser som ärver från Appliance
// kan använda metoden genom polymorfism.

// 2. Vilken metod körs om objektet egentligen är en RobotVacuum?
// RobotVacuums egen override av metoden körs. Programmet använder objektets
// verkliga typ vid körning.

// 3. Vad blev bättre jämfört med List<object>?
// Koden blev enklare och säkrare. Vi slipper kontrollera typer med många
// if-satser och kan behandla alla apparater som Appliance.


// Del 9 

// 1. Varför kan vi inte anropa Schedule() direkt på en variabel av typen Appliance?
// Appliance innehåller inte metoden Schedule().
// Alla apparater kan inte schemaläggas, därför känner
// Appliance inte till den metoden.

// 2. Varför fungerar det efter att vi castar till ISchedulable?
// När vi castar till ISchedulable vet programmet att
// objektet har metoden Schedule() och då kan den anropas.

// 3. Vad betyder det att RobotVacuum både är en Appliance och en ISchedulable?
// RobotVacuum ärver från Appliance och får dess egenskaper.
// Samtidigt implementerar den ISchedulable, vilket betyder
// att den kan schemaläggas.

// 4. Varför ska inte Schedule() ligga direkt i Appliance?
// Alla apparater kan inte schemaläggas.
// Om Schedule() låg i Appliance skulle även Refrigerator
// och Oven behöva ha metoden trots att de inte använder den.

// 5. Vad är skillnaden mellan arv och interface i det här exemplet?
// Arv används för gemensamma egenskaper och metoder som
// alla apparater har.
//
// Interface används för att beskriva en funktion som bara
// vissa apparater har, till exempel schemaläggning.
}
class SmartLamp : Appliance
{
    public int Brightness { get; set; }

    public SmartLamp(string brand, string room, int brightness)
        : base(brand, room)
    {
        Brightness = brightness;
    }

    public new void TurnOn()
    {
        Console.WriteLine($"{Brand} smart lamp turns on with brightness {Brightness}%.");
    }
}
class AirConditioner : Appliance, ISchedulable
{
    public int TargetTemperature { get; set; }
public DateTime NextRun { get; set; }
    public AirConditioner(string brand, string room, int targetTemperature)
        : base(brand, room)
    {
        TargetTemperature = targetTemperature;
    }

    public override void TurnOn()
    {
        IsOn = true;
        Console.WriteLine($"{Brand} air conditioner in {Room} is now cooling to {TargetTemperature}°C.");
    }

    public override void TurnOff()
    {
        IsOn = false;
        Console.WriteLine($"{Brand} air conditioner in {Room} is now turned off.");
    }

    public override double GetDailyEnergyUsage()
    {
        return 3.5;
    }

   public void Schedule(DateTime time)
{
    NextRun = time;
    Console.WriteLine($"{Brand} air conditioner in {Room} scheduled for {time}");
}
}
class PizzaOven : Oven
{
    public PizzaOven(string brand, string room, int maxTemperature)
        : base(brand, room, maxTemperature)
    {
    }

    
}


// Del 11 

// 1. Blir utskriften samma?
// Nej. SmartLamp-objektet använder SmartLamp.TurnOn()
// medan Appliance-objektet använder Appliance.TurnOn().

// 2. Vilken metod körs när variabeln har typen SmartLamp?
// SmartLamp.TurnOn() körs.

// 3. Vilken metod körs när variabeln har typen Appliance?
// Appliance.TurnOn() körs.

// 4. Varför är detta farligt eller förvirrande?
// Samma objekt kan bete sig olika beroende på vilken typ
// variabeln har, vilket kan göra koden svår att förstå.

// 5. Vad händer om du byter new till override?
// Då används polymorfism och SmartLamp.TurnOn() körs
// även när variabeln har typen Appliance.

// Del 12

// 1. Vad säger kompilatorn?
// Kompilatorn säger att PizzaOven inte kan override:a TurnOn()
// eftersom metoden i Oven är markerad som sealed.

// 2. Varför får PizzaOven inte override:a TurnOn()?
// Sealed betyder att inga klasser som ärver från Oven
// får ändra den metoden igen.

// 3. När kan det vara rimligt att använda sealed override?
// När man vill låsa ett beteende så att det inte kan ändras
// av klasser längre ner i arvshierarkin.

// 4. Vad kan PizzaOven fortfarande göra istället?
// PizzaOven kan lägga till egna metoder och override:a andra
// metoder som inte är markerade som sealed.