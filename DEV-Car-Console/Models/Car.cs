using DEV_Car_Console.Enum;

namespace DEV_Car_Console.Models
{
    public class Car : Vehicle
    {
        public int TotalDoors { get; private set; }
        public ETypeFuel FuelType { get; private set; }
        public int HorsePower { get; private set; }
        public Car(int totalDoors,
                   ETypeFuel fuelType,
                   int horsePower,
                   DateTime fabricationDate,
                   string name,
                   string plate,
                   Decimal value,
                   EColors color,
                   ETypeVehicle type) : base(fabricationDate, name, plate, value, color, type)
        {
            TotalDoors = totalDoors;
            FuelType = fuelType;
            HorsePower = horsePower;
        }
        public override string ShowInfo()
        {
            return $"{base.ShowInfo()} \n| PORTAS: {TotalDoors} | COMBUSTIVEL: {FuelType} | POTENCIA: {HorsePower}hp";
        }
        public override bool IsValid()
        {
            if (
                (TotalDoors < 2 || TotalDoors > 4) ||
                ((int)FuelType < 0 || (int)FuelType > 1) ||
                HorsePower <= 0
                )
            {
                return false;
            }
            return base.IsValid();
        }
    }
}
