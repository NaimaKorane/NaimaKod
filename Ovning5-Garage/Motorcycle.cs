namespace Ovning5_Garage;

public class Motorcycle : Vehicle
{
    public int CylinderVolume { get; set; }

    public Motorcycle(string registrationNumber, string color)
        : base(registrationNumber, color, 2)
    {
        CylinderVolume = 600;
    }
}