namespace Ovning5_Garage;

public class Bus : Vehicle
{
    public int NumberOfSeats { get; set; }

    public Bus(string registrationNumber, string color, int numberOfWheels, int numberOfSeats)
        : base(registrationNumber, color, numberOfWheels)
    {
        NumberOfSeats = numberOfSeats;
    }
}