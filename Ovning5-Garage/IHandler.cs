namespace Ovning5_Garage;

public interface IHandler
{
    bool AddVehicle(Vehicle vehicle);
    bool RemoveVehicle();
    Vehicle? FindByRegistrationNumber(string registrationNumber);

    IEnumerable<Vehicle> GetAllVehicles();
     Dictionary<string, int> GetVehicleTypeCounts();
     IEnumerable<Vehicle> FindByColor(string color);
     IEnumerable<Vehicle> FindByColorAndWheels(string color, int numberOfWheels);
}