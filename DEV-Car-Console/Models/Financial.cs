namespace DEV_Car_Console.Models
{
    public class Financial
    {
        private string VehicleData { get; set; }
        private int? BuyerCPF { get; set; }
        private Decimal Value { get; set; }
        private DateTime Date { get; set; }
        public Financial(Vehicle vehicleData, DateTime date)
        {
            VehicleData = vehicleData.ShowInfo();
            BuyerCPF = vehicleData.BuyerCPF;
            Value = vehicleData.Value;
            Date = date;
        }
        public string ShowInfo()
        {
            return $"{VehicleData} --> DATA DE VENDA: {Date:dd/MM/yyyy} | CPF COMPRADOR: {BuyerCPF}";
        }
    }
}
