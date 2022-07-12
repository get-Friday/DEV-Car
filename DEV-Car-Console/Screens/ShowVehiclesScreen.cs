using DEV_Car_Console.Repository;
using DEV_Car_Console.Models;

namespace DEV_Car_Console.Screens
{
    public class ShowVehiclesScreen
    {
        public static void Start(VehiclesRepository vehicles)
        {
            string subHeaderText = "Veículos registrados";
            int canvasSize = vehicles.Vehicles.Count + 10;
            MenuScreen.PrintMenu(canvasSize, 105, subHeaderText);

            int row = 7;
            foreach (Vehicle vehicle in vehicles.Vehicles)
            {
                Console.SetCursorPosition(2, row);
                Console.WriteLine(vehicle.ShowInfo());
                row++;
            }

            Console.ReadLine();
        }
    }
}
