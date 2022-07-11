namespace DEV_Car_Console.Models
{
    public class Financial
    {
        public Vehicle VehicleData { get; set; }
        public string BuyerCPF { get; set; }
        public Decimal Value { get; set; }
        public DateTime Date { get; set; }
        public Financial(Vehicle vehicleData, string buyerCPF, decimal value, DateTime date)
        {
            VehicleData = vehicleData;
            BuyerCPF = buyerCPF;
            Value = value;
            Date = date;
        }
    }
}
