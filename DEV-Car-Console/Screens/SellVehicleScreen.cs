using DEV_Car_Console.Models;
using DEV_Car_Console.Repository;
using DEV_Car_Console.Enum;

namespace DEV_Car_Console.Screens
{
    public class SellVehicleScreen
    {
        public void Start()
        {
            string subHeaderText = "Vender veículo";

            new MenuScreen().PrintMenu(20, 35, subHeaderText);

            Console.SetCursorPosition(2, 7);
            Console.WriteLine("Informe o CPF do comprador: ");
            Console.SetCursorPosition(2, 8);
            int BuyerCPF = int.Parse(Console.ReadLine());

            Console.SetCursorPosition(2, 9);
            Console.WriteLine("Informe a placa do veículo: ");
            Console.SetCursorPosition(2, 10);
            string plate = Console.ReadLine();

            SellVehicle(plate, BuyerCPF);

            Console.SetCursorPosition(2, 18);
            Console.WriteLine("Veículo vendido!");
            Console.SetCursorPosition(2, 19);
            Console.Write("pressione qualquer tecla para voltar");

            Console.Read();
        }
        private void SellVehicle(string plate, int buyerCPF)
        {
            Vehicle? query = VehiclesRepository.Vehicles
                .ToList()
                .Find(vehicle => vehicle.Plate == plate);

            query.SellVehicle(buyerCPF);
        }
    }
}
