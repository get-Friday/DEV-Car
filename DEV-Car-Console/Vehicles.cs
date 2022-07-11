namespace DEV_Car_Console
{
    public class Vehicle
    {
        public Guid ChassiNumber { get; set; }
        public DateTime FabricationDate { get; set; }
        public string Name { get; set; }
        public string Plate { get; set; }
        public Decimal Value { get; set; }
        public string BuyerCPF { get; set; }
        public string Color { get; set; }
        public Vehicle(DateTime fabricationDate,
                       string name,
                       string plate,
                       decimal value,
                       string color)
        {
            ChassiNumber = Guid.NewGuid();
            FabricationDate = fabricationDate;
            Name = name;
            Plate = plate;
            Value = value;
            BuyerCPF = "0";
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
