namespace DEV_Car_Console.Models
{
    public class Car : Vehicle
    {
        public int TotalDoors { get; set; }
        public string FuelType { get; set; }
        public int HorsePower { get; set; }
        public Car(int totalDoors,
                   string fuelType,
                   int horsePower,
                   DateTime fabricationDate,
                   string name,
                   string plate,
                   decimal value,
                   string color) : base(fabricationDate, name, plate, value, color)
        {
            TotalDoors = totalDoors;
            FuelType = fuelType;
            HorsePower = horsePower;
        }
    }
}
