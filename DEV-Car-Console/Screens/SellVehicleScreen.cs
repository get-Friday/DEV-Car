using DEV_Car_Console.Models;
using DEV_Car_Console.Repository;

namespace DEV_Car_Console.Screens
{
    internal static class SellVehicleScreen
    {
        public static void Start()
        {
            string subHeaderText = "Vender veículo";

            MenuScreen.PrintMenu(20, 40, subHeaderText);

            Console.SetCursorPosition(2, 7);
            Console.WriteLine("Informe o CPF do comprador: ");
            Console.SetCursorPosition(2, 8);
            bool BuyerCPFParse = int.TryParse(Console.ReadLine(), out int BuyerCPF);
            if (!BuyerCPFParse)
            {
                MenuScreen.PrintError(20, "CPF Inválido");
                return;
            }

            Console.SetCursorPosition(2, 9);
            Console.WriteLine("Informe a placa do veículo: ");
            Console.SetCursorPosition(2, 10);
            string plate = Console.ReadLine();
            if (plate == null || !VerifyPlate(plate))
            {
                MenuScreen.PrintError(20, "Placa Inválida");
                return;
            }

            SellVehicle(plate, BuyerCPF);
        }
        private static bool VerifyPlate(string plate)
        {
            return VehiclesRepository.Vehicles
                .Select(vehicle => vehicle.Plate)
                .Contains(plate);
        }
        private static void SellVehicle(string plate, int buyerCPF)
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
