using System;

namespace Version3
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
}
