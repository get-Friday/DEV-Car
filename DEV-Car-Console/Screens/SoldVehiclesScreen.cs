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
                MostLeastSold(canvasSize - 5);
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
            Decimal highestPrice = VehiclesRepository.Vehicles
                .Where(vehicle => vehicle.BuyerCPF != null)
                .Select(vehicle => vehicle.Value)
                .Max();

            IEnumerable<Vehicle> mostExpensiveVehicle = VehiclesRepository.Vehicles
                .Where(vehicle => vehicle.Value == highestPrice);

            Decimal lowestPrice = VehiclesRepository.Vehicles
                .Where(vehicle => vehicle.BuyerCPF != null)
                .Select(vehicle => vehicle.Value)
                .Min();

            IEnumerable<Vehicle> leastExpensiveVehicle = VehiclesRepository.Vehicles
                .Where(vehicle => vehicle.Value == lowestPrice);

            Console.SetCursorPosition(2, row);
            Console.WriteLine("Maior / Menor preço");
            Console.SetCursorPosition(2, row + 1);
            Console.WriteLine($"$$$: {mostExpensiveVehicle.First().ShowInfo()}");
            Console.SetCursorPosition(2, row + 3);
            Console.WriteLine($" $ : {leastExpensiveVehicle.First().ShowInfo()}");
        }
    }
}
