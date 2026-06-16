namespace Ovning5_Garage;

public class Car : Vehicle
{
    public string FuelType { get; set; }

    public Car(string registrationNumber, string color)
        : base(registrationNumber, color, 4)
    {
        FuelType = "Gasoline";
    }
}