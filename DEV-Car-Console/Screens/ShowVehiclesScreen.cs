using DEV_Car_Console.Repository;
using DEV_Car_Console.Models;
using DEV_Car_Console.Enum;

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
            new MenuScreen().PrintMenu(17, 35, subHeaderText, menuOptions, "Voltar");

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
            IEnumerable<Vehicle> query = VehiclesRepository.Vehicles
                .ToList()
                .Where(vehicle => vehicle.Type == ETypeVehicle.MotoTriciclo);

            string subHeaderText = $"Motos/Triciclos registrados";
            int canvasSize = query.Count() * 2 + 10;
            int row = 7;

            new MenuScreen().PrintMenu(canvasSize, 85, subHeaderText);

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
            IEnumerable<Vehicle> query = VehiclesRepository.Vehicles
                .ToList()
                .Where(vehicle => vehicle.Type == ETypeVehicle.Carro);

            string subHeaderText = $"Carros registrados";
            int canvasSize = query.Count() * 2 + 10;
            int row = 7;

            new MenuScreen().PrintMenu(canvasSize, 85, subHeaderText);

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
            IEnumerable<Vehicle> query = VehiclesRepository.Vehicles
                .ToList()
                .Where(vehicle => vehicle.Type == ETypeVehicle.Caminhonete);

            string subHeaderText = $"Caminhonetes registradas";
            int canvasSize = query.Count() * 2 + 10;
            int row = 7;

            new MenuScreen().PrintMenu(canvasSize, 85, subHeaderText);

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

            new MenuScreen().PrintMenu(canvasSize, 85, subHeaderText);

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
