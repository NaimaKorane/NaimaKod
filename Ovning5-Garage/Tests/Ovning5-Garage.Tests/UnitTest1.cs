namespace Ovning5_Garage.Tests;

public class GarageTests
{
    [Fact]
    public void Constructor_WhenCapacityIsSet_SetsCapacityAndCount()
    {
        Garage<Car> garage = new Garage<Car>(5);

        Assert.Equal(5, garage.Capacity);
        Assert.Equal(0, garage.Count);
    }

    [Fact]
    public void AddVehicle_WhenGarageHasSpace_ReturnsTrueAndIncreasesCount()
    {
        Garage<Car> garage = new Garage<Car>(5);
        Car car = new Car("ABC123", "Svart", 4, "Gasoline");

        bool result = garage.AddVehicle(car);

        Assert.True(result);
        Assert.Equal(1, garage.Count);
    }

    [Fact]
    public void AddVehicle_WhenGarageIsFull_ReturnsFalseAndCountStaysSame()
    {
        Garage<Car> garage = new Garage<Car>(1);
        Car car1 = new Car("ABC123", "Svart", 4, "Gasoline");
        Car car2 = new Car("DEF456", "Vit", 4, "Gasoline");

        garage.AddVehicle(car1);

        bool result = garage.AddVehicle(car2);

        Assert.False(result);
        Assert.Equal(1, garage.Count);
    }

    [Fact]
    public void AddVehicle_DuplicateRegistrationNumber_ReturnsFalse()
    {
        Garage<Car> garage = new Garage<Car>(5);
        Car car1 = new Car("ABC123", "Svart", 4, "Gasoline");
        Car car2 = new Car("ABC123", "Vit", 4, "Diesel");

        garage.AddVehicle(car1);

        bool result = garage.AddVehicle(car2);

        Assert.False(result);
        Assert.Equal(1, garage.Count);
    }

    [Fact]
    public void FindByRegistrationNumber_WhenVehicleExists_ReturnsVehicle()
    {
        Garage<Car> garage = new Garage<Car>(5);
        Car car = new Car("ABC123", "Svart", 4, "Gasoline");

        garage.AddVehicle(car);

        Car? result = garage.FindByRegistrationNumber("ABC123");

        Assert.NotNull(result);
        Assert.Equal("ABC123", result.RegistrationNumber);
    }

    [Fact]
    public void FindByRegistrationNumber_WithDifferentCasing_ReturnsVehicle()
    {
        Garage<Car> garage = new Garage<Car>(5);
        Car car = new Car("ABC123", "Svart", 4, "Gasoline");

        garage.AddVehicle(car);

        Car? result = garage.FindByRegistrationNumber("abc123");

        Assert.NotNull(result);
        Assert.Equal("ABC123", result.RegistrationNumber);
    }

    [Fact]
    public void RemoveVehicle_WhenVehicleExists_ReturnsTrueAndDecreasesCount()
    {
        Garage<Car> garage = new Garage<Car>(5);
        Car car = new Car("ABC123", "Svart", 4, "Gasoline");

        garage.AddVehicle(car);

        bool result = garage.RemoveVehicle("ABC123");

        Assert.True(result);
        Assert.Equal(0, garage.Count);
    }

    [Fact]
    public void RemoveVehicle_WhenVehicleDoesNotExist_ReturnsFalse()
    {
        Garage<Car> garage = new Garage<Car>(5);
        Car car = new Car("ABC123", "Svart", 4, "Gasoline");

        garage.AddVehicle(car);

        bool result = garage.RemoveVehicle("ZZZ999");

        Assert.False(result);
        Assert.Equal(1, garage.Count);
    }

    [Fact]
    public void GetEnumerator_WhenGarageHasVehicles_ReturnsAllVehicles()
    {
        Garage<Car> garage = new Garage<Car>(5);
        Car car1 = new Car("ABC123", "Svart", 4, "Gasoline");
        Car car2 = new Car("DEF456", "Vit", 4, "Gasoline");

        garage.AddVehicle(car1);
        garage.AddVehicle(car2);

        List<Car> vehicles = garage.ToList();

        Assert.Equal(2, vehicles.Count);
        Assert.Contains(car1, vehicles);
        Assert.Contains(car2, vehicles);
    }

    [Fact]
    public void AddVehicle_CanAddAirplane()
    {
        Garage<Vehicle> garage = new Garage<Vehicle>(5);
        Airplane airplane = new Airplane("AIR123", "Vit", 3, 2);

        bool result = garage.AddVehicle(airplane);

        Assert.True(result);
        Assert.Equal(1, garage.Count);
    }

    [Fact]
    public void AddVehicle_CanAddMotorcycle()
    {
        Garage<Vehicle> garage = new Garage<Vehicle>(5);
        Motorcycle motorcycle = new Motorcycle("MC123", "Röd", 2, 600);

        bool result = garage.AddVehicle(motorcycle);

        Assert.True(result);
        Assert.Equal(1, garage.Count);
    }

    [Fact]
    public void AddVehicle_CanAddBus()
    {
        Garage<Vehicle> garage = new Garage<Vehicle>(5);
        Bus bus = new Bus("BUS123", "Blå", 6, 50);

        bool result = garage.AddVehicle(bus);

        Assert.True(result);
        Assert.Equal(1, garage.Count);
    }

    [Fact]
    public void AddVehicle_CanAddBoat()
    {
        Garage<Vehicle> garage = new Garage<Vehicle>(5);
        Boat boat = new Boat("BOAT123", "Vit", 0, 10.5);

        bool result = garage.AddVehicle(boat);

        Assert.True(result);
        Assert.Equal(1, garage.Count);
    }
}