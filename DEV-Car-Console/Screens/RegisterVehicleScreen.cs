using DEV_Car_Console.Repository;
using DEV_Car_Console.Models;
using DEV_Car_Console.Enum;

namespace DEV_Car_Console.Screens
{
    public class RegisterVehicleScreen
    {
        public void Start()
        {
            string subHeaderText = "Escolha tipo de veículo para registrar";
            string[] menuOptions = { "Moto/Triciclo", "Carro", "Caminhonete" };
            new MenuScreen().PrintMenu(20, 55, subHeaderText, menuOptions, "Voltar");

            var options = short.Parse(Console.ReadLine());

            switch (options)
            {
                case 1: RegisterBikeTricicle(); break;
                case 2: RegisterCar(); break;
                case 3: RegisterPickup(); break;
                default: break;
            }
        }
        private void PrintFooter(int lastRow)
        {
            Console.SetCursorPosition(2, lastRow - 1);
            Console.WriteLine("Veículo adicionado!");
            Console.SetCursorPosition(2, lastRow);
            Console.WriteLine("Pressione qualquer tecla para voltar");
            var option = Console.ReadLine();
        }
        private void RegisterBikeTricicle()
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
            new MenuScreen().PrintMenu(27, 50, subHeaderText, menuOptions);

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
            
            string[] colorsOptions = { "Branco", "Preto", "Cinza", "Prata", "Vermelho", "Roxo" };
            PrintEnums(25, 8, colorsOptions);
            
            Console.SetCursorPosition(3, 20);
            EColors color = EColors.Parse<EColors>(Console.ReadLine());

            ETypeVehicle type = ETypeVehicle.MotoTriciclo;

            BikeTricicle bikeTricicle = new(potency, qntWheels, fabricationDate, name, plate, value, color, type);

            VehiclesRepository.Vehicles.Add(bikeTricicle);

            PrintFooter(27);
        }
        private void RegisterCar()
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
            new MenuScreen().PrintMenu(27, 50, subHeaderText, menuOptions);

            // Query start printintg a row 7
            Console.SetCursorPosition(3, 8);
            int totalDoors = int.Parse(Console.ReadLine());

            string[] fuelOptions = { "Flex", "Gasolina", "Diesel"};
            PrintEnums(25, 5, fuelOptions);

            Console.SetCursorPosition(3, 10);
            ETypeFuel fuelType = ETypeFuel.Parse<ETypeFuel>(Console.ReadLine());
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

            string[] colorsOptions = { "Branco", "Preto", "Cinza", "Prata", "Vermelho", "Roxo" };
            PrintEnums(25, 8, colorsOptions);

            Console.SetCursorPosition(3, 22);
            EColors color = EColors.Parse<EColors>(Console.ReadLine());
            ETypeVehicle type = ETypeVehicle.Carro;

            Car car = new(totalDoors, fuelType, horsePower, fabricationDate, name, plate, value, color, type);

            VehiclesRepository.Vehicles.Add(car);

            PrintFooter(27);
        }
        private void RegisterPickup()
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
            new MenuScreen().PrintMenu(27, 50, subHeaderText, menuOptions);

            // Query start printintg a row 7
            Console.SetCursorPosition(3, 8);
            int totalDoors = int.Parse(Console.ReadLine());
            Console.SetCursorPosition(3, 10);
            int cargoSizeLiters = int.Parse(Console.ReadLine());
            Console.SetCursorPosition(3, 12);
            int horsePower = int.Parse(Console.ReadLine());

            string[] fuelOptions = { "Flex", "Gasolina", "Diesel" };
            PrintEnums(25, 5, fuelOptions);

            Console.SetCursorPosition(3, 14);
            ETypeFuel fuelType = ETypeFuel.Parse<ETypeFuel>(Console.ReadLine());
            Console.SetCursorPosition(3, 16);
            DateTime fabricationDate = DateTime.Parse(Console.ReadLine());
            Console.SetCursorPosition(3, 18);
            string name = Console.ReadLine();
            Console.SetCursorPosition(3, 20);
            string plate = Console.ReadLine();
            Console.SetCursorPosition(3, 22);
            decimal value = Decimal.Parse(Console.ReadLine());

            string[] colorsOptions = { "Branco", "Preto", "Cinza", "Prata", "Vermelho", "Roxo" };
            PrintEnums(25, 8, colorsOptions);

            Console.SetCursorPosition(3, 24);
            EColors color = EColors.Parse<EColors>(Console.ReadLine());
            ETypeVehicle type = ETypeVehicle.Caminhonete;

            PickupTruck pickup = new(totalDoors, cargoSizeLiters, horsePower, fuelType, fabricationDate, name, plate, value, color, type);

            VehiclesRepository.Vehicles.Add(pickup);

            PrintFooter(27);
        }
        private void PrintEnums(int sizeX, int sizeY, string[] options)
        {
            PrintPopup(sizeX, sizeY);
            PrintEnumOptions(options);
        }
        private void PrintPopup(int sizeX, int sizeY)
        {
            Console.SetCursorPosition(57, 5);
            Console.Write("+");

            for (int i = 0; i <= sizeX; i++)
                System.Console.Write("-");

            Console.Write("+");

            for (int i = 0; i < sizeY; i++)
            {
                Console.SetCursorPosition(57, i + 6);
                Console.Write("|");

                for (int line = 0; line <= sizeX; line++)
                    Console.Write(" ");

                Console.Write("|");
            }

            Console.SetCursorPosition(57, sizeY + 6);
            Console.Write("+");

            for (int i = 0; i <= sizeX; i++)
                System.Console.Write("-");

            Console.Write("+");
        }
        private void PrintEnumOptions(string[] EnumOptions)
        {
            Console.SetCursorPosition(59, 6);
            Console.WriteLine("Usar código de cada cor: ");
            
            int row = 8;
            for (int i = 0; i < EnumOptions.Length; i++)
            {
                Console.SetCursorPosition(59, row);
                Console.WriteLine($"{i} - {EnumOptions[i]}");
                row++;
            }
        }
    }
}
