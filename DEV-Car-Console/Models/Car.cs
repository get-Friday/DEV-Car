using DEV_Car_Console.Enum;

namespace DEV_Car_Console.Models
{
    public class Car : Vehicle
    {
        public int TotalDoors { get; set; }
        public ETypeFuel FuelType { get; set; }
        public int HorsePower { get; set; }
        public Car(int totalDoors,
                   ETypeFuel fuelType,
                   int horsePower,
                   DateTime fabricationDate,
                   string name,
                   string plate,
                   decimal value,
                   EColors color,
                   ETypeVehicle type) : base(fabricationDate, name, plate, value, color, type)
        {
            TotalDoors = totalDoors;
            FuelType = fuelType;
            HorsePower = horsePower;
        }
    }
}
