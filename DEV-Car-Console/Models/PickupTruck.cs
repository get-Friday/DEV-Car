using DEV_Car_Console.Enum;

namespace DEV_Car_Console.Models
{
    internal class PickupTruck : Vehicle
    {
        public int TotalDoors { get; set; }
        public int CargoSizeLiters { get; set; }
        public int HorsePower { get; set; }
        public ETypeFuel TypeFuel { get; set; }
        public PickupTruck(int totalDoors,
                           int cargoSizeLiters,
                           int horsePower,
                           ETypeFuel typeFuel,
                           DateTime fabricationDate,
                           string name,
                           string plate,
                           decimal value,
                           EColors color,
                           ETypeVehicle type) : base(fabricationDate, name, plate, value, color, type)
        {
            TotalDoors = totalDoors;
            CargoSizeLiters = cargoSizeLiters;
            HorsePower = horsePower;
            TypeFuel = typeFuel;
        }
        public override string ShowInfo()
        {
            return $"{base.ShowInfo()} \n| PORTAS: {TotalDoors} | CARGA: {CargoSizeLiters}L | POTENCIA: {HorsePower}hp | COMBUSTIVEL: {TypeFuel}";
        }
    }
}
