using DEV_Car_Console.Enum;
using DEV_Car_Console.Repository;

namespace DEV_Car_Console.Models
{
    public class Vehicle
    {
        public Guid FrameNumber { get; set; }
        public DateTime FabricationDate { get; set; }
        public string Name { get; set; }
        public string Plate { get; set; }
        public decimal Value { get; set; }
        public int? BuyerCPF { get; set; }
        public EColors Color { get; set; }
        public ETypeVehicle Type { get; set; }
        public Vehicle(DateTime fabricationDate,
                       string name,
                       string plate,
                       decimal value,
                       EColors color,
                       ETypeVehicle type)
        {
            FrameNumber = Guid.NewGuid();
            FabricationDate = fabricationDate;
            Name = name;
            Plate = plate;
            Value = value;
            Color = color;
            Type = type;
        }
        public void SellVehicle(int buyerCPF)
        {
            BuyerCPF = buyerCPF;
        }
        public virtual string ShowInfo()
        {
            return $"> NOME: {Name} | PLACA: {Plate} | VALOR: R${Value} | COR: {Color}";
        }
        public void ChangeInfo(decimal value, EColors color)
        {
            Value = value;
            Color = color;
        }
        public virtual bool IsValid()
        {
            if (
                Name == null ||
                Plate == null ||
                Value <= 0 ||
                ((int) Color < 0 || (int) Color > 5) ||
                AlreadyExists(Plate)
                )
            {
                return false;
            }

            return true;
        }
        private bool AlreadyExists(string plate)
        {
            return VehiclesRepository.Vehicles
                .Select(vehicle => vehicle.Plate)
                .Contains(plate);
        }
    }
}
