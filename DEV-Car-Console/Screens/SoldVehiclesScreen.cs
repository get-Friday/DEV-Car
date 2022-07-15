using DEV_Car_Console.Models;
using DEV_Car_Console.Repository;

namespace DEV_Car_Console.Screens
{
    public static class SoldVehiclesScreen
    {
        public static void Start()
        {
            IEnumerable<Vehicle> query = VehiclesRepository.Vehicles
                .Where(vehicle => vehicle.BuyerCPF != null);
            int canvasSize = query.Count() * 2 + 15;
            string subHeaderText = "Veículos vendidos";
            int row = 7;

            if (query.Count() == 0)
            {
                EmptyList();
            }
            else
            {
                PrintSold(query, canvasSize, subHeaderText, row);
                MostLeastSold(canvasSize - 4);
                Console.ReadLine();
            }
        }
        private static void EmptyList()
        {
            MenuScreen.PrintMenu(10, 20, "Lista vazia :(");
            Console.ReadLine();
        }
        private static void PrintSold(IEnumerable<Vehicle> query, int canvasSize, string subHeaderText, int row)
        {
            MenuScreen.PrintMenu(canvasSize, 92, subHeaderText);

            foreach (Vehicle vehicle in query)
            {
                Console.SetCursorPosition(2, row);
                Console.WriteLine(vehicle.ShowInfo());
                row += 2;
            }
        }
        private static void MostLeastSold(int row)
        {
            decimal highestPrice = VehiclesRepository.Vehicles
                .Where(vehicle => vehicle.BuyerCPF != null)
                .Select(vehicle => vehicle.Value)
                .Max();

            decimal lowestPrice = VehiclesRepository.Vehicles
                .Where(vehicle => vehicle.BuyerCPF != null)
                .Select(vehicle => vehicle.Value)
                .Min();

            Console.SetCursorPosition(2, row);
            Console.WriteLine("Preços de vendas:");
            Console.SetCursorPosition(2, row + 1);
            Console.WriteLine($"Maior valor: R${highestPrice}");
            Console.SetCursorPosition(2, row + 2);
            Console.WriteLine($"Menor valor: R${lowestPrice}");
        }
    }
}
