namespace Ovning5_Garage;

public class Boat : Vehicle
{
    public double Length { get; set; }

    public Boat(string registrationNumber, string color)
        : base(registrationNumber, color, 0)
    {
        Length = 10.5;
    }
}