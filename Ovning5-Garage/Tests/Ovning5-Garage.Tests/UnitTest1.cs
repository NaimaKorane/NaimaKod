namespace Ovning5_Garage.Tests;

public class GarageTests
{
    [Fact]
    public void Constructor_WhenCapacityIsSet_SetsCapacityAndCount()
    {
        // Arrange
        int capacity = 5;

        // Act
        Garage<Car> garage = new Garage<Car>(capacity);

        // Assert
        Assert.Equal(5, garage.Capacity);
        Assert.Equal(0, garage.Count);
    }

    [Fact]
    public void AddVehicle_WhenGarageHasSpace_IncreasesCount()
    {
        // Arrange
        Garage<Car> garage = new Garage<Car>(5);
        Car car = new Car("ABC123", "Svart");

        // Act
        bool result = garage.AddVehicle(car);

        // Assert
        Assert.True(result);
        Assert.Equal(1, garage.Count);
    }

    [Fact]
    public void AddVehicle_WhenGarageIsFull_ReturnsFalseAndCountStaysSame()
    {
        // Arrange
        Garage<Car> garage = new Garage<Car>(1);
        Car car1 = new Car("ABC123", "Svart");
        Car car2 = new Car("DEF456", "Vit");

        garage.AddVehicle(car1);

        // Act
        bool result = garage.AddVehicle(car2);

        // Assert
        Assert.False(result);
        Assert.Equal(1, garage.Count);
    }

    [Fact]
    public void RemoveVehicle_WhenGarageHasVehicle_DecreasesCount()
    {
        // Arrange
        Garage<Car> garage = new Garage<Car>(5);
        Car car = new Car("ABC123", "Svart");

        garage.AddVehicle(car);

        // Act
        bool result = garage.RemoveVehicle();

        // Assert
        Assert.True(result);
        Assert.Equal(0, garage.Count);
    }

    [Fact]
    public void FindByRegistrationNumber_WhenVehicleExists_ReturnsVehicle()
    {
        // Arrange
        Garage<Car> garage = new Garage<Car>(5);
        Car car = new Car("ABC123", "Svart");

        garage.AddVehicle(car);

        // Act
        var result = garage.FindByRegistrationNumber("ABC123");

        // Assert
        Assert.NotNull(result);
        Assert.Equal("ABC123", result.RegistrationNumber);
    }

    [Fact]
    public void RemoveVehicle_WhenGarageIsEmpty_ReturnsFalse()
    {
        // Arrange
        Garage<Car> garage = new Garage<Car>(5);

        // Act
        bool result = garage.RemoveVehicle();

        // Assert
        Assert.False(result);
    }
    [Fact]
public void GetEnumerator_WhenGarageHasVehicles_ReturnsAllVehicles()
{
    // Arrange
    Garage<Car> garage = new Garage<Car>(5);
    Car car1 = new Car("ABC123", "Svart");
    Car car2 = new Car("DEF456", "Vit");

    garage.AddVehicle(car1);
    garage.AddVehicle(car2);

    // Act
    List<Car> vehicles = garage.ToList();

    // Assert
    Assert.Equal(2, vehicles.Count);
    Assert.Contains(car1, vehicles);
    Assert.Contains(car2, vehicles);
}
}