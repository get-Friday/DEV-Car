using DEV_Car_Console.Enum;

namespace DEV_Car_Console.Models
{
    internal class PickupTruck : Vehicle
    {
        public int TotalDoors { get; private set; }
        public int CargoSizeLiters { get; private set; }
        public int HorsePower { get; private set; }
        public ETypeFuel TypeFuel { get; private set; }
        public PickupTruck(int totalDoors,
                           int cargoSizeLiters,
                           int horsePower,
                           ETypeFuel typeFuel,
                           DateTime fabricationDate,
                           string name,
                           string plate,
                           Decimal value,
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
        public override bool IsValid()
        {
            if (
                (TotalDoors < 2 || TotalDoors > 6) ||
                CargoSizeLiters < 0 ||
                HorsePower <= 0 ||
                ((int)TypeFuel < 1 || (int)TypeFuel > 2) ||
                Color != EColors.Roxo
                )
            {
                return false;
            }
            return base.IsValid();
        }
    }
}
