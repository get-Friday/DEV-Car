using DEV_Car_Console.Models;
using DEV_Car_Console.Repository;

namespace DEV_Car_Console.Screens
{
    public class SellVehicleScreen
    {
        public void Start()
        {
            string subHeaderText = "Vender veículo";

            new MenuScreen().PrintMenu(20, 40, subHeaderText);

            Console.SetCursorPosition(2, 7);
            Console.WriteLine("Informe o CPF do comprador: ");
            Console.SetCursorPosition(2, 8);
            int BuyerCPF = int.Parse(Console.ReadLine());

            Console.SetCursorPosition(2, 9);
            Console.WriteLine("Informe a placa do veículo: ");
            Console.SetCursorPosition(2, 10);
            string plate = Console.ReadLine();

            SellVehicle(plate, BuyerCPF);
        }
        private void SellVehicle(string plate, int buyerCPF)
        {
            Vehicle query = VehiclesRepository.Vehicles
                .ToList()
                .Find(vehicle => vehicle.Plate == plate);

            query.SellVehicle(buyerCPF);

            Financial history = new(query, DateTime.Now);
            TransferHistoryRepository.TransferHistory.Add(history);
        }
    }
}
