using DEV_Car_Console.Models;
using DEV_Car_Console.Repository;

namespace DEV_Car_Console.Screens
{
    public class SoldVehiclesScreen
    {
        public void Start()
        {
            IEnumerable<Vehicle> query = VehiclesRepository.Vehicles.Where(vehicle => vehicle.BuyerCPF != null);
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
                MostLeastSold(query, canvasSize - 4);
                Console.ReadLine();
            }
        }
        private void EmptyList()
        {
            new MenuScreen().PrintMenu(10, 20, "Lista vazia :(");
            Console.ReadLine();
        }
        private void PrintSold(IEnumerable<Vehicle> query, int canvasSize, string subHeaderText, int row)
        {
            new MenuScreen().PrintMenu(canvasSize, 85, subHeaderText);

            foreach (Vehicle vehicle in query)
            {
                Console.SetCursorPosition(2, row);
                Console.WriteLine(vehicle.ShowInfo());
                row += 2;
            }
        }
        private void MostLeastSold(IEnumerable<Vehicle> query, int row)
        {
            string? highestPrice = query.Max(e => e.ShowInfo());
            string? lowestPrice = query.Min(e => e.ShowInfo());

            Console.SetCursorPosition(2, row);
            Console.WriteLine("Veículos vendidos por preço:");
            Console.SetCursorPosition(2, row + 1);
            Console.WriteLine($"$$$ {highestPrice}");
            Console.SetCursorPosition(2, row + 3);
            Console.WriteLine($" $  {lowestPrice}");
        }
    }
}
