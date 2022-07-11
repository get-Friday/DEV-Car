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
        private int? BuyerCPF { get; set; }
        public string Color { get; set; }
        public Vehicle(DateTime fabricationDate,
                       string name,
                       string plate,
                       decimal value,
                       string color)
        {
            FrameNumber = Guid.NewGuid();
            FabricationDate = fabricationDate;
            Name = name;
            Plate = plate;
            Value = value;
            Color = color;
        }
        public void SellVehicle()
        {

        }
        public string ShowInfo()
        {
            return "";
        }
        public void ChangeInfo()
        {

        }
    }
}
