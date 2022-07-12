using DEV_Car_Console.Repository;
using DEV_Car_Console.Models;

namespace DEV_Car_Console.Screens
{
    public class ShowVehiclesScreen
    {
        public static void Start(VehiclesRepository vehicles)
        {
            string subHeaderText = "Listar veículos";
            string[] menuOptions = { 
                "Motos/Triciclo",
                "Carros",
                "Caminhonetes",
                "Todos"
            };
            MenuScreen.PrintMenu(17, 35, subHeaderText, menuOptions, "Voltar");

            var option = short.Parse(Console.ReadLine());

            switch (option)
            {
                case 1: showBikesTricicles(vehicles); break;
                case 4: ShowAll(vehicles); break;
                default: break;
            }
        }
        public static void showBikesTricicles(VehiclesRepository repository)
        {
            string subHeaderText = $"Motos/Triciclos registrados";
            int canvasSize = repository.Vehicles.Count + 10;
            int row = 7;

            MenuScreen.PrintMenu(canvasSize, 105, subHeaderText);

            foreach (Vehicle vehicle in repository.Vehicles)
            {
                Console.SetCursorPosition(2, row);
                Console.WriteLine(vehicle);
                row++;
            }

            Console.ReadLine();

        }
        public static void ShowAll(VehiclesRepository repository)
        {
            string subHeaderText = $"{repository.Vehicles.Count} Veículos registrados";
            int canvasSize = repository.Vehicles.Count + 10;
            int row = 7;

            MenuScreen.PrintMenu(canvasSize, 105, subHeaderText);

            foreach (Vehicle vehicle in repository.Vehicles)
            {
                Console.SetCursorPosition(2, row);
                Console.WriteLine(vehicle.ShowInfo());
                row++;
            }
            
            Console.ReadLine();
        }
    }
}
