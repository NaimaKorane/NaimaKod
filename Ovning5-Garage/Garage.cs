using System.Collections;
using System.Collections.Generic;

namespace Ovning5_Garage;

public class Garage<T> : IEnumerable<T> where T : Vehicle
{
private T[] vehicles;


public int Capacity { get; }

public int Count { get; private set; }

public Garage(int capacity)
{
    Capacity = capacity;
    vehicles = new T[capacity];
}


public bool AddVehicle(T vehicle)
{
    if (Count >= Capacity)
    {
        return false;
    }

    if (FindByRegistrationNumber(vehicle.RegistrationNumber) != null)
    {
        return false;
    }

    vehicles[Count] = vehicle;
    Count++;

    return true;
}


public bool RemoveVehicle()
{
    if (Count == 0)
    {
        return false;
    }

    Count--;
    vehicles[Count] = default!;

    return true;
}

public T? FindByRegistrationNumber(string registrationNumber)
{
    for (int i = 0; i < Count; i++)
    {
        if (string.Equals(
            vehicles[i]?.RegistrationNumber,
            registrationNumber,
            StringComparison.OrdinalIgnoreCase))
        {
            return vehicles[i];
        }
    }

    return default;
}

public IEnumerator<T> GetEnumerator()
{
    for (int i = 0; i < Count; i++)
    {
        yield return vehicles[i];
    }
}

IEnumerator IEnumerable.GetEnumerator()
{
    return GetEnumerator();
}


}
