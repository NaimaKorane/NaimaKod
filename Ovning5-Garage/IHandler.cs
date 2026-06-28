namespace Ovning5_Garage;

public interface IHandler
{
    bool AddVehicle(Vehicle vehicle);
    bool RemoveVehicle(string registrationNumber);
    Vehicle? FindByRegistrationNumber(string registrationNumber);

    IEnumerable<Vehicle> GetAllVehicles();
    Dictionary<string, int> GetVehicleTypeCounts();

    IEnumerable<Vehicle> FindByType(string vehicleType);
    IEnumerable<Vehicle> FindByColor(string color);
    IEnumerable<Vehicle> FindByWheels(int numberOfWheels);
    IEnumerable<Vehicle> FindByColorAndWheels(string color, int numberOfWheels);
}