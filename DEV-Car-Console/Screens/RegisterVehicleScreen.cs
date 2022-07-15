using DEV_Car_Console.Repository;
using DEV_Car_Console.Models;
using DEV_Car_Console.Enum;

namespace DEV_Car_Console.Screens
{
    public static class RegisterVehicleScreen
    {
        public static void Start()
        {
            string subHeaderText = "Escolha tipo de veículo para registrar";
            string[] menuOptions = { "Moto/Triciclo", "Carro", "Caminhonete" };
            MenuScreen.PrintMenu(20, 55, subHeaderText, menuOptions, "Voltar");

            bool input = short.TryParse(Console.ReadLine(), out short option);

            if (input)
            {
                switch (option)
                {
                    case 0: break;
                    case 1: RegisterBikeTricicle(); break;
                    case 2: RegisterCar(); break;
                    case 3: RegisterPickup(); break;
                    default: MenuScreen.PrintError(20, "Opção inexistente"); Start(); break;
                }
            }
            else
            {
                MenuScreen.PrintError(20, "Opção inválida");
            }
        }
        private static void RegisterBikeTricicle()
        {
            int canvasSizeY = 27;
            int canvasSizeX = 50;
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
            MenuScreen.PrintMenu(canvasSizeY, canvasSizeX, subHeaderText, menuOptions);

            // Input user

            Console.SetCursorPosition(3, 8);
            bool potencyParse = int.TryParse(Console.ReadLine(), out int potency);

            Console.SetCursorPosition(3, 10);
            bool qntWheelsParse = int.TryParse(Console.ReadLine(), out int qntWheels);

            Console.SetCursorPosition(3, 12);
            bool fabricationDateParse = DateTime.TryParse(Console.ReadLine(), out DateTime fabricationDate);

            Console.SetCursorPosition(3, 14);
            string name = Console.ReadLine();

            Console.SetCursorPosition(3, 16);
            string plate = Console.ReadLine();

            Console.SetCursorPosition(3, 18);
            bool valueParse = Decimal.TryParse(Console.ReadLine(), out Decimal value);

            string[] colorsOptions = { "Branco", "Preto", "Cinza", "Prata", "Vermelho", "Roxo" };
            MenuScreen.PrintEnums(25, 8, canvasSizeX + 9, canvasSizeY - 21, colorsOptions, "Cor");

            Console.SetCursorPosition(3, 20);
            bool colorParse = EColors.TryParse<EColors>(Console.ReadLine(), out EColors color);

            // Verify inputs integrity

            if (
                !potencyParse ||
                !qntWheelsParse ||
                !fabricationDateParse ||
                name == null ||
                plate == null ||
                !valueParse ||
                !colorParse
                )
            {
                MenuScreen.PrintError(canvasSizeY, "Campo inválido");
                return;
            }

            // Verify if plate already exists

            if (VerifyPlate(plate))
            {
                MenuScreen.PrintError(canvasSizeY, "Placa já existente");
                return;
            }

            // Instance vehicle

            ETypeVehicle type = ETypeVehicle.MotoTriciclo;
            BikeTricicle bikeTricicle = new(potency, qntWheels, fabricationDate, name, plate, value, color, type);

            // Verify class integrity 

            if (!bikeTricicle.IsValid())
            {
                MenuScreen.PrintError(canvasSizeY, "Campo inválido");
                return;
            }

            // Push valid data to repository 

            VehiclesRepository.Vehicles.Add(bikeTricicle);
            PrintFooter(27);
        }
        private static void RegisterCar()
        {
            int canvasSizeY = 27;
            int canvasSizeX = 50;
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
            MenuScreen.PrintMenu(canvasSizeY, canvasSizeX, subHeaderText, menuOptions);

            // Input user

            Console.SetCursorPosition(3, 8);
            bool totalDoorsParse = int.TryParse(Console.ReadLine(), out int totalDoors);
            
            string[] fuelOptions = { "Flex", "Gasolina", "Diesel" };
            MenuScreen.PrintEnums(25, 8, canvasSizeX + 9, canvasSizeY - 21, fuelOptions, "Combustível");

            Console.SetCursorPosition(3, 10);
            bool fuelTypeParse = ETypeFuel.TryParse<ETypeFuel>(Console.ReadLine(), out ETypeFuel fuelType);

            Console.SetCursorPosition(3, 12);
            bool horsePowerParse = int.TryParse(Console.ReadLine(), out int horsePower);

            Console.SetCursorPosition(3, 14);
            bool fabricationDateParse = DateTime.TryParse(Console.ReadLine(), out DateTime fabricationDate);

            Console.SetCursorPosition(3, 16);
            string name = Console.ReadLine();

            Console.SetCursorPosition(3, 18);
            string plate = Console.ReadLine();

            Console.SetCursorPosition(3, 20);
            bool valueParse = Decimal.TryParse(Console.ReadLine(), out Decimal value);

            string[] colorsOptions = { "Branco", "Preto", "Cinza", "Prata", "Vermelho", "Roxo" };
            MenuScreen.PrintEnums(25, 8, canvasSizeX + 9, canvasSizeY - 21, colorsOptions, "Cor");

            Console.SetCursorPosition(3, 22);
            bool colorParse = EColors.TryParse<EColors>(Console.ReadLine(), out EColors color);

            // Verify inputs integrity

            if (
                !totalDoorsParse ||
                !fuelTypeParse ||
                !horsePowerParse ||
                !fabricationDateParse ||
                name == null ||
                plate == null ||
                !valueParse ||
                !colorParse
                )
            {
                MenuScreen.PrintError(canvasSizeY, "Campo inválido");
                return;
            }

            // Verify if plate already exists

            if (VerifyPlate(plate))
            {
                MenuScreen.PrintError(canvasSizeY, "Placa já existente");
                return;
            }

            // Instance vehicle

            ETypeVehicle type = ETypeVehicle.Carro;
            Car car = new(totalDoors, fuelType, horsePower, fabricationDate, name, plate, value, color, type);

            // Verify class integrity

            if (!car.IsValid())
            {
                MenuScreen.PrintError(canvasSizeY, "Campo inválido");
                return;
            }

            // Push valid data to repository

            VehiclesRepository.Vehicles.Add(car);
            PrintFooter(27);
        }
        private static void RegisterPickup()
        {
            int canvasSizeY = 27;
            int canvasSizeX = 50;
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
            MenuScreen.PrintMenu(canvasSizeY, canvasSizeX, subHeaderText, menuOptions);

            // Input user

            Console.SetCursorPosition(3, 8);
            bool totalDoorsParse = int.TryParse(Console.ReadLine(), out int totalDoors);

            Console.SetCursorPosition(3, 10);
            bool cargoSizeLitersParse = int.TryParse(Console.ReadLine(), out int cargoSizeLiters);

            Console.SetCursorPosition(3, 12);
            bool horsePowerParse = int.TryParse(Console.ReadLine(), out int horsePower);

            string[] fuelOptions = { "Flex", "Gasolina", "Diesel" };
            MenuScreen.PrintEnums(25, 8, canvasSizeX + 9, canvasSizeY - 21, fuelOptions, "Combustível");

            Console.SetCursorPosition(3, 14);
            bool fuelTypeParse = ETypeFuel.TryParse<ETypeFuel>(Console.ReadLine(), out ETypeFuel fuelType);

            Console.SetCursorPosition(3, 16);
            bool fabricationDateParse = DateTime.TryParse(Console.ReadLine(), out DateTime fabricationDate);

            Console.SetCursorPosition(3, 18);
            string name = Console.ReadLine();

            Console.SetCursorPosition(3, 20);
            string plate = Console.ReadLine();

            Console.SetCursorPosition(3, 22);
            bool valueParse = Decimal.TryParse(Console.ReadLine(), out Decimal value);

            string[] colorsOptions = { "Branco", "Preto", "Cinza", "Prata", "Vermelho", "Roxo" };
            MenuScreen.PrintEnums(25, 8, canvasSizeX + 9, canvasSizeY - 21, colorsOptions, "Cor");

            Console.SetCursorPosition(3, 24);
            bool colorParse = EColors.TryParse<EColors>(Console.ReadLine(), out EColors color);

            // Verify inputs integrity

            if (
                !totalDoorsParse ||
                !cargoSizeLitersParse ||
                !horsePowerParse ||
                !fuelTypeParse ||
                !fabricationDateParse ||
                name == null ||
                plate == null ||
                !valueParse ||
                !colorParse
                )
            {
                MenuScreen.PrintError(canvasSizeY, "Campo inválido");
                return;
            }

            // Verify if plate already exists

            if (VerifyPlate(plate))
            {
                MenuScreen.PrintError(canvasSizeY, "Placa já existente");
                return;
            }

            // Instance vehicle

            ETypeVehicle type = ETypeVehicle.Caminhonete;
            PickupTruck pickup = new(totalDoors, cargoSizeLiters, horsePower, fuelType, fabricationDate, name, plate, value, color, type);

            // Verify class integrity

            if (!pickup.IsValid())
            {
                MenuScreen.PrintError(canvasSizeY, "Campo inválido");
                return;
            }

            // Push valid data to repository

            VehiclesRepository.Vehicles.Add(pickup);
            PrintFooter(27);
        }
        private static bool VerifyPlate(string plate)
        {
            return VehiclesRepository.Vehicles
                .Select(vehicle => vehicle.Plate)
                .Contains(plate);
        }
        private static void PrintFooter(int lastRow)
        {
            Console.SetCursorPosition(2, lastRow - 1);
            Console.WriteLine("Veículo adicionado!");
            Console.SetCursorPosition(2, lastRow);
            Console.WriteLine("Pressione qualquer tecla para voltar");
            var option = Console.ReadLine();
        }
    }
}
