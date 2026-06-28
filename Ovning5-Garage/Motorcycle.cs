namespace Ovning5_Garage;

public class Motorcycle : Vehicle
{
    public int CylinderVolume { get; set; }

    public Motorcycle(string registrationNumber, string color, int numberOfWheels, int cylinderVolume)
        : base(registrationNumber, color, numberOfWheels)
    {
        CylinderVolume = cylinderVolume;
    }
}