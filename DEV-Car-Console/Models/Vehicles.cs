using DEV_Car_Console.Enum;
using DEV_Car_Console.Repository;

namespace DEV_Car_Console.Models
{
    public class Vehicle
    {
        public Guid FrameNumber { get; private set; }
        public DateTime FabricationDate { get; private set; }
        public string Name { get; private set; }
        public string Plate { get; private set; }
        public Decimal Value { get; private set; }
        public int? BuyerCPF { get; private set; }
        public EColors Color { get; private set; }
        public ETypeVehicle Type { get; private set; }
        public Vehicle(DateTime fabricationDate,
                       string name,
                       string plate,
                       Decimal value,
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
        public void ChangeInfo(Decimal value, EColors color)
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
                ((int) Color < 0 || (int) Color > 5)
                )
            {
                return false;
            }

            return true;
        }
    }
}
