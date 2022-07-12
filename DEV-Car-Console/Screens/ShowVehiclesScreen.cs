using DEV_Car_Console.Repository;
using DEV_Car_Console.Models;

namespace DEV_Car_Console.Screens
{
    public class ShowVehiclesScreen
    {
        public void Start()
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
                case 1: ShowBikesTricicles(); break;
                case 2: ShowCar(); break;
                case 3: ShowPickupTruck(); break;
                case 4: ShowAll(); break;
                default: break;
            }
        }
        private void ShowBikesTricicles()
        {
            IEnumerable<Vehicle> query = VehiclesRepository.Vehicles.ToList().Where(vehicle => vehicle.Type == Enum.ETypeVehicle.MotoTriciclo);
            string subHeaderText = $"Motos/Triciclos registrados";
            int canvasSize = query.Count() * 2 + 10;
            int row = 7;

            MenuScreen.PrintMenu(canvasSize, 80, subHeaderText);

            foreach (Vehicle vehicle in query)
            {
                Console.SetCursorPosition(2, row);
                Console.WriteLine(vehicle.ShowInfo());
                row += 2;
            }

            Console.ReadLine();

        }
        private void ShowCar()
        {
            IEnumerable<Vehicle> query = VehiclesRepository.Vehicles.ToList().Where(vehicle => vehicle.Type == Enum.ETypeVehicle.Carro);
            string subHeaderText = $"Carros registrados";
            int canvasSize = query.Count() * 2 + 10;
            int row = 7;

            MenuScreen.PrintMenu(canvasSize, 80, subHeaderText);

            foreach (Vehicle vehicle in query)
            {
                Console.SetCursorPosition(2, row);
                Console.WriteLine(vehicle.ShowInfo());
                row += 2;
            }

            Console.ReadLine();
        }
        private void ShowPickupTruck()
        {
            IEnumerable<Vehicle> query = VehiclesRepository.Vehicles.ToList().Where(vehicle => vehicle.Type == Enum.ETypeVehicle.Caminhonete);
            string subHeaderText = $"Caminhonetes registradas";
            int canvasSize = query.Count() * 2 + 10;
            int row = 7;

            MenuScreen.PrintMenu(canvasSize, 80, subHeaderText);

            foreach (Vehicle vehicle in query)
            {
                Console.SetCursorPosition(2, row);
                Console.WriteLine(vehicle.ShowInfo());
                row += 2;
            }

            Console.ReadLine();
        }
        private void ShowAll()
        {
            string subHeaderText = $"{VehiclesRepository.Vehicles.Count} Veículos registrados";
            int canvasSize = VehiclesRepository.Vehicles.Count * 2 + 10;
            int row = 7;

            MenuScreen.PrintMenu(canvasSize, 80, subHeaderText);

            foreach (Vehicle vehicle in VehiclesRepository.Vehicles)
            {
                Console.SetCursorPosition(2, row);
                Console.WriteLine(vehicle.ShowInfo());
                row += 2;
            }
            
            Console.ReadLine();
        }
    }
}
