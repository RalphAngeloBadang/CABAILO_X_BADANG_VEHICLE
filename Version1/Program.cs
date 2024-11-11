using System;

public class Vehicle
{
    public int VehicleId { get; set; }
    public string Make { get; set; }
    public string Model { get; set; }
    public float FuelEfficiency { get; set; }

    public Vehicle(int vehicleId, string make, string model, float fuelEfficiency)
    {
        VehicleId = vehicleId;
        Make = make;
        Model = model;
        FuelEfficiency = fuelEfficiency;
    }
}

public class Car : Vehicle
{
    public int NumDoors { get; set; }
    public bool IsAutomatic { get; set; }

    public Car(int vehicleId, string make, string model, float fuelEfficiency, int numDoors, bool isAutomatic)
        : base(vehicleId, make, model, fuelEfficiency)
    {
        NumDoors = numDoors;
        IsAutomatic = isAutomatic;
    }

    public float CalculateFuelConsumption(float distance)
    {
        return distance / FuelEfficiency;
    }
}

public class Motorcycle : Vehicle
{
    public int EngineCC { get; set; }
    public bool IsSportBike { get; set; }

    public Motorcycle(int vehicleId, string make, string model, float fuelEfficiency, int engineCC, bool isSportBike)
        : base(vehicleId, make, model, fuelEfficiency)
    {
        EngineCC = engineCC;
        IsSportBike = isSportBike;
    }

    public float CalculateFuelConsumption(float distance)
    {
        float consumption = distance / FuelEfficiency;
        return IsSportBike ? consumption * 1.1f : consumption;
    }
}



class Program
{
    static void Main()
    {

    }
}