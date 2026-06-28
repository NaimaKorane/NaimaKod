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

    public bool RemoveVehicle(string registrationNumber)
    {
        return garage.RemoveVehicle(registrationNumber);
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
            string vehicleType = vehicle.GetType().Name;

            if (!counts.ContainsKey(vehicleType))
            {
                counts[vehicleType] = 0;
            }

            counts[vehicleType]++;
        }

        return counts;
    }

    public IEnumerable<Vehicle> FindByType(string vehicleType)
    {
        return garage.Where(vehicle =>
            vehicle.GetType().Name.Equals(vehicleType, StringComparison.OrdinalIgnoreCase));
    }

    public IEnumerable<Vehicle> FindByColor(string color)
    {
        return garage.Where(vehicle =>
            vehicle.Color.Equals(color, StringComparison.OrdinalIgnoreCase));
    }

    public IEnumerable<Vehicle> FindByWheels(int numberOfWheels)
    {
        return garage.Where(vehicle =>
            vehicle.NumberOfWheels == numberOfWheels);
    }

    public IEnumerable<Vehicle> FindByColorAndWheels(string color, int numberOfWheels)
    {
        return garage.Where(vehicle =>
            vehicle.Color.Equals(color, StringComparison.OrdinalIgnoreCase)
            && vehicle.NumberOfWheels == numberOfWheels);
    }
}