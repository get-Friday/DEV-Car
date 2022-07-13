namespace DEV_Car_Console.Models
{
    public class Financial
    {
        private string VehicleData { get; set; }
        private int? BuyerCPF { get; set; }
        private Decimal Value { get; set; }
        private DateTime Date { get; set; }
        public Financial(Vehicle vehicle, DateTime date)
        {
            VehicleData = vehicle.ShowInfo();
            BuyerCPF = vehicle.BuyerCPF;
            Value = vehicle.Value;
            Date = date;
        }
        public string ShowInfo()
        {
            return $"{VehicleData} --> DATA DE VENDA: {Date:dd/MM/yyyy} | CPF COMPRADOR: {BuyerCPF}";
        }
    }
}
