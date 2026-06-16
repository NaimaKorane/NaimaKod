namespace Ovning5_Garage;

public class Airplane : Vehicle
{
    public int NumberOfEngines { get; set; }

    public Airplane(string registrationNumber, string color)
        : base(registrationNumber, color, 3)
    {
        NumberOfEngines = 2;
    }
}