using DEV_Car_Console.Enum;

namespace DEV_Car_Console.Models
{
    public class Vehicle
    {
        // TODO:
        // Pesquisar sobre init pra strings
        // https://docs.microsoft.com/pt-br/dotnet/csharp/language-reference/proposals/csharp-9.0/init
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
        public virtual void ChangeInfo(DateTime fabricationDate, string name, string plate, decimal value)
        {
            FabricationDate = fabricationDate;
            Name = name;
            Plate = plate;
            Value = value;
        }
    }
}
