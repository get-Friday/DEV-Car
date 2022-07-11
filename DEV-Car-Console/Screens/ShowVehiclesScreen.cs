using DEV_Car_Console.Repository;
using DEV_Car_Console.Models;

namespace DEV_Car_Console.Screens
{
    public class ShowVehiclesScreen
    {
        public static void Start(VehiclesRepository vehicle, TransferHistoryRepository transferHistory)
        {
            Console.Clear();
            MenuScreen.PrintCanvas();
            MenuScreen.PrintHeader();
            PrintContent(vehicle);

            var option = short.Parse(Console.ReadLine());
        }

        public static void PrintContent(VehiclesRepository vehicle)
        {
            Console.SetCursorPosition(2, 5);
            Console.WriteLine("Lista de veículos cadastrados:");
            Console.SetCursorPosition(2, 7);

            foreach (Vehicle vehicles in vehicle.Vehicles)
            {
                Console.WriteLine(vehicles);
            }
        }
    }
}
