namespace DEV_Car_Console.Models
{
    internal class PickupTruck : Vehicle
    {
        public int TotalDoors { get; set; }
        public int CargoSizeLiters { get; set; }
        public int HorsePower { get; set; }
        public string TypeFuel { get; set; }
        public PickupTruck(int totalDoors,
                           int cargoSizeLiters,
                           int horsePower,
                           string typeFuel,
                           DateTime fabricationDate,
                           string name,
                           string plate,
                           decimal value,
                           string color) : base(fabricationDate, name, plate, value, color)
        {
            TotalDoors = totalDoors;
            CargoSizeLiters = cargoSizeLiters;
            HorsePower = horsePower;
            TypeFuel = typeFuel;
        }
    }
}
