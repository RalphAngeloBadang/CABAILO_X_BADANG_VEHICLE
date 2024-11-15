using System;

namespace DemoAbstraction
{
    abstract class Vehicle
    {
        public int VehicleId { get; private set; }
        public string Make { get; private set; }
        public string Model { get; private set; }
        public float FuelEfficiency { get; private set; }

        protected Vehicle(int vehicleId, string make, string model, float fuelEfficiency)
        {
            if (vehicleId <= 0) throw new ArgumentException("Vehicle ID must be positive.");
            if (fuelEfficiency <= 0) throw new ArgumentException("Fuel efficiency must be positive.");

            VehicleId = vehicleId;
            Make = make ?? throw new ArgumentException("Make cannot be null.");
            Model = model ?? throw new ArgumentException("Model cannot be null.");
            FuelEfficiency = fuelEfficiency;
        }

        public abstract float CalculateFuelConsumption(float distance);
    }

    class Car : Vehicle
    {
        public int NumDoors { get; private set; }
        public bool IsAutomatic { get; private set; }

        public Car(int vehicleId, string make, string model, float fuelEfficiency, int numDoors, bool isAutomatic)
            : base(vehicleId, make, model, fuelEfficiency)
        {
            if (numDoors <= 0) throw new ArgumentException("Number of doors must be positive.");
            NumDoors = numDoors;
            IsAutomatic = isAutomatic;
        }

        public override float CalculateFuelConsumption(float distance)
        {
            return distance / FuelEfficiency;
        }
    }

    class Motorcycle : Vehicle
    {
        public int EngineCC { get; private set; }
        public bool IsSportBike { get; private set; }

        public Motorcycle(int vehicleId, string make, string model, float fuelEfficiency, int engineCC, bool isSportBike)
            : base(vehicleId, make, model, fuelEfficiency)
        {
            if (engineCC <= 0) throw new ArgumentException("Engine CC must be positive.");
            EngineCC = engineCC;
            IsSportBike = isSportBike;
        }

        public override float CalculateFuelConsumption(float distance)
        {
            float consumption = distance / FuelEfficiency;
            return IsSportBike ? consumption * 1.1f : consumption;
        }
    }

    class Truck : Vehicle
    {
        public float CargoCapacity { get; private set; }
        public bool IsHeavyDuty { get; private set; }

        public Truck(int vehicleId, string make, string model, float fuelEfficiency, float cargoCapacity, bool isHeavyDuty)
            : base(vehicleId, make, model, fuelEfficiency)
        {
            if (cargoCapacity <= 0) throw new ArgumentException("Cargo capacity must be positive.");
            CargoCapacity = cargoCapacity;
            IsHeavyDuty = isHeavyDuty;
        }

        public override float CalculateFuelConsumption(float distance)
        {
            return distance / FuelEfficiency;
        }

        public float CalculateFuelConsumption(float distance, float cargoWeight)
        {
            if (cargoWeight > CargoCapacity) throw new ArgumentException("Cargo weight exceeds capacity.");
            float basicConsumption = distance / FuelEfficiency;
            float cargoFactor = cargoWeight / CargoCapacity;
            float heavyDutyFactor = IsHeavyDuty ? 1.2f : 1.0f;
            return basicConsumption * cargoFactor * heavyDutyFactor;
        }
    }

    class Program
    {
        static void Main()
        {
            float distance = 150.0f;

            Car car = new Car(1, "Toyota", "Camry", 15.0f, 4, true);
            Motorcycle motorcycle = new Motorcycle(2, "Yamaha", "R1", 20.0f, 1000, true);
            Truck truck = new Truck(3, "Ford", "F-150", 8.0f, 5.0f, true);

            Console.WriteLine("Fuel Consumption Calculations:");
            Console.WriteLine($"Car (ID: {car.VehicleId}, Model: {car.Make} {car.Model}) for {distance} km: {car.CalculateFuelConsumption(distance):0.00} liters");
            Console.WriteLine($"Motorcycle (ID: {motorcycle.VehicleId}, Model: {motorcycle.Make} {motorcycle.Model}) for {distance} km: {motorcycle.CalculateFuelConsumption(distance):0.00} liters");

            float cargoWeight = 3.0f;
            Console.WriteLine($"Truck (ID: {truck.VehicleId}, Model: {truck.Make} {truck.Model}) for {distance} km with {cargoWeight} tons cargo: {truck.CalculateFuelConsumption(distance, cargoWeight):0.00} liters");

            Console.ReadKey();
        }
    }
}
