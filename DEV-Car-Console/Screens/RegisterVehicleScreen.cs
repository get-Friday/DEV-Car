using DEV_Car_Console.Repository;
using DEV_Car_Console.Models;

namespace DEV_Car_Console.Screens
{
    public static class RegisterVehicleScreen
    {
        public static void Start(VehiclesRepository vehicles, TransferHistoryRepository transferHistory)
        {
            string subHeaderText = "Escolha tipo de veículo para registrar";
            string[] menuOptions = { "Moto/Triciclo", "Carro", "Caminhonete" };
            MenuScreen.PrintMenu(17, 55, subHeaderText, menuOptions, "Voltar");

            var options = short.Parse(Console.ReadLine());

            switch (options)
            {
                case 1: RegisterBikeTricicle(vehicles); break;
                case 2: RegisterCar(vehicles); break;
                case 3: RegisterPickup(vehicles); break;
                default: break;
            }
        }
        public static void PrintFooter(int lastRow)
        {
            Console.SetCursorPosition(2, lastRow - 1);
            Console.WriteLine("Veículo adicionado!");
            Console.SetCursorPosition(2, lastRow);
            Console.WriteLine("Pressione qualquer tecla para voltar");
            var option = Console.ReadLine();
        }
        public static void RegisterBikeTricicle(VehiclesRepository vehicles)
        {
            string subHeaderText = "Registre Moto/Triciclo";
            string[] menuOptions = { 
                "potência", 
                "quantidade de rodas",
                "data de fabricação (dd/mm/yy)",
                "nome",
                "placa",
                "valor",
                "cor"
            };
            MenuScreen.PrintMenu(27, 55, subHeaderText, menuOptions);

            // Query start printintg a row 7
            Console.SetCursorPosition(3, 8);
            int potency = int.Parse(Console.ReadLine());
            Console.SetCursorPosition(3, 10);
            int qntWheels = int.Parse(Console.ReadLine());
            Console.SetCursorPosition(3, 12);
            DateTime fabricationDate = DateTime.Parse(Console.ReadLine());
            Console.SetCursorPosition(3, 14);
            string name = Console.ReadLine();
            Console.SetCursorPosition(3, 16);
            string plate = Console.ReadLine();
            Console.SetCursorPosition(3, 18);
            decimal value = Decimal.Parse(Console.ReadLine());
            Console.SetCursorPosition(3, 20);
            string color = Console.ReadLine();

            BikeTricicle bikeTricicle = new(potency, qntWheels, fabricationDate, name, plate, value, color);

            vehicles.Vehicles.Add(bikeTricicle);

            PrintFooter(27);
        }
        public static void RegisterCar(VehiclesRepository vehicles)
        {
            string subHeaderText = "Registre Carro";
            string[] menuOptions = {
                "quantidade de portas",
                "tipo de combustível",
                "cavalos de força",
                "data de fabricação (dd/mm/yy)",
                "nome",
                "placa",
                "valor",
                "cor"
            };
            MenuScreen.PrintMenu(27, 55, subHeaderText, menuOptions);

            // Query start printintg a row 7
            Console.SetCursorPosition(3, 8);
            int totalDoors = int.Parse(Console.ReadLine());
            Console.SetCursorPosition(3, 10);
            string fuelType = Console.ReadLine();
            Console.SetCursorPosition(3, 12);
            int horsePower = int.Parse(Console.ReadLine());
            Console.SetCursorPosition(3, 14);
            DateTime fabricationDate = DateTime.Parse(Console.ReadLine());
            Console.SetCursorPosition(3, 16);
            string name = Console.ReadLine();
            Console.SetCursorPosition(3, 18);
            string plate = Console.ReadLine();
            Console.SetCursorPosition(3, 20);
            decimal value = Decimal.Parse(Console.ReadLine());
            Console.SetCursorPosition(3, 22);
            string color = Console.ReadLine();

            Car car = new(totalDoors, fuelType, horsePower, fabricationDate, name, plate, value, color);

            vehicles.Vehicles.Add(car);

            PrintFooter(27);
        }
        public static void RegisterPickup(VehiclesRepository vehicles)
        {
            string subHeaderText = "Registre Caminhonete";
            string[] menuOptions = {
                "quantidade de portas",
                "capacidade de carga (Litros)",
                "cavalos de força",
                "tipo combustível",
                "data de fabricação (dd/mm/yy)",
                "nome",
                "placa",
                "valor",
                "cor"
            };
            MenuScreen.PrintMenu(27, 55, subHeaderText, menuOptions);

            // Query start printintg a row 7
            Console.SetCursorPosition(3, 8);
            int totalDoors = int.Parse(Console.ReadLine());
            Console.SetCursorPosition(3, 10);
            int cargoSizeLiters = int.Parse(Console.ReadLine());
            Console.SetCursorPosition(3, 12);
            int horsePower = int.Parse(Console.ReadLine());
            Console.SetCursorPosition(3, 14);
            string typeFuel = Console.ReadLine();
            Console.SetCursorPosition(3, 16);
            DateTime fabricationDate = DateTime.Parse(Console.ReadLine());
            Console.SetCursorPosition(3, 18);
            string name = Console.ReadLine();
            Console.SetCursorPosition(3, 20);
            string plate = Console.ReadLine();
            Console.SetCursorPosition(3, 22);
            decimal value = Decimal.Parse(Console.ReadLine());
            Console.SetCursorPosition(3, 24);
            string color = Console.ReadLine();

            PickupTruck pickup = new(totalDoors, cargoSizeLiters, horsePower, typeFuel, fabricationDate, name, plate, value, color);

            vehicles.Vehicles.Add(pickup);

            PrintFooter(27);
        }
    }
}
