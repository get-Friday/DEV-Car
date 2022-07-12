using DEV_Car_Console.Models;
using DEV_Car_Console.Repository;

namespace DEV_Car_Console.Screens
{
    public class SoldVehiclesScreen
    {
        public void Start()
        {
            IEnumerable<Vehicle> query = VehiclesRepository.Vehicles.Where(vehicle => vehicle.BuyerCPF != null);
            int canvasSize = query.Count() * 2 + 10;
            string subHeaderText = "Veículos vendidos";
            int row = 7;

            if (query.Count() == 0)
            {
                MenuScreen.PrintMenu(10, 20, "Lista vazia :(");
                Console.ReadLine();
            }
            else
            {
                MenuScreen.PrintMenu(canvasSize, 85, subHeaderText);

                foreach (Vehicle vehicle in query)
                {
                    Console.SetCursorPosition(2, row);
                    Console.WriteLine(vehicle.ShowInfo());
                    row += 2;
                }

                PrintPopup(20, 3);
                PrintOptions();

                var option = short.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1: break;
                    case 2: break;
                    default:break;
                }
            }
        }
        private void PrintPopup(int sizeX, int sizeY)
        {
            Console.SetCursorPosition(87, 5);
            Console.Write("+");

            for (int i = 0; i <= sizeX; i++)
                System.Console.Write("-");

            Console.Write("+");

            for (int i = 0; i < sizeY; i++)
            {
                Console.SetCursorPosition(87, i + 6);
                Console.Write("|");

                for (int line = 0; line <= sizeX; line++)
                    Console.Write(" ");

                Console.Write("|");
            }

            Console.SetCursorPosition(87, sizeY + 6);
            Console.Write("+");

            for (int i = 0; i <= sizeX; i++)
                System.Console.Write("-");

            Console.Write("+");
        }
        private void PrintOptions()
        {
            Console.SetCursorPosition(89, 6);
            Console.WriteLine("Opções de filtro: ");
            Console.SetCursorPosition(89, 7);
            Console.WriteLine("1 - Mais vendido");
            Console.SetCursorPosition(89, 8);
            Console.WriteLine("2 - Menos vendido");
        }
    }
}
