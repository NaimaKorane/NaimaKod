namespace Ovning5_Garage;

public class Airplane : Vehicle
{
    public int NumberOfEngines { get; set; }

    public Airplane(string registrationNumber, string color, int numberOfWheels, int numberOfEngines)
        : base(registrationNumber, color, numberOfWheels)
    {
        NumberOfEngines = numberOfEngines;
    }
}