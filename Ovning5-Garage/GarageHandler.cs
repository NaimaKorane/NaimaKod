namespace Ovning5_Garage;

public class GarageHandler : IHandler
{
    private Garage<Vehicle> garage;

    public GarageHandler(int capacity)
    {
        garage = new Garage<Vehicle>(capacity);
    }

    public bool AddVehicle(Vehicle vehicle)
    {
        if (vehicle == null)
        {
            return false;
        }

        return garage.AddVehicle(vehicle);
    }

    public bool RemoveVehicle()
    {
        return garage.RemoveVehicle();
    }

    public Vehicle? FindByRegistrationNumber(string registrationNumber)
    {
        return garage.FindByRegistrationNumber(registrationNumber);
    }

    public IEnumerable<Vehicle> GetAllVehicles()
    {
        return garage;
    }

    public Dictionary<string, int> GetVehicleTypeCounts()
    {
        Dictionary<string, int> counts = new();

        foreach (Vehicle vehicle in garage)
        {
            string type = vehicle.GetType().Name;

            if (counts.ContainsKey(type))
            {
                counts[type]++;
            }
            else
            {
                counts[type] = 1;
            }
        }

        return counts;
    }

    public IEnumerable<Vehicle> FindByColor(string color)
    {
        return garage.Where(v => v.Color.Equals(
            color,
            StringComparison.OrdinalIgnoreCase));
    }
public IEnumerable<Vehicle> FindByColorAndWheels(string color, int numberOfWheels)
{
    return garage.Where(v =>
        v.Color.Equals(color, StringComparison.OrdinalIgnoreCase)
        && v.NumberOfWheels == numberOfWheels);
}
}