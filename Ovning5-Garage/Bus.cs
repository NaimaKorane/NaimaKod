namespace Ovning5_Garage;

public class Bus : Vehicle
{
    public int NumberOfSeats { get; set; }

    public Bus(string registrationNumber, string color)
        : base(registrationNumber, color, 6)
    {
        NumberOfSeats = 50;
    }
}