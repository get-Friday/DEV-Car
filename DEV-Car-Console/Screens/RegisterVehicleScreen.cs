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

            bool input = short.TryParse(Console.ReadLine(), out short option);

            if (input)
            {
                switch (option)
                {
                    case 0: break;
                    case 1: RegisterBikeTricicle(); break;
                    case 2: RegisterCar(); break;
                    case 3: RegisterPickup(); break;
                    default: new MenuScreen().PrintError(20, "Opção inexistente"); Start(); break;
                }
            }
            else
            {
                new MenuScreen().PrintError(20, "Opção inválida");
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

            Console.SetCursorPosition(3, 8);
            bool potencyParse = int.TryParse(Console.ReadLine(), out int potency);
            if (!potencyParse || potency == 0)
            {
                new MenuScreen().PrintError(27, "Potência inválida");
                return;
            }

            Console.SetCursorPosition(3, 10);
            bool qntWheelsParse = int.TryParse(Console.ReadLine(), out int qntWheels);
            if (!qntWheelsParse)
            {
                new MenuScreen().PrintError(27, "Rodas inválidas");
                return;
            }
            else if (qntWheels < 2 || qntWheels > 3)
            {
                new MenuScreen().PrintError(27, "Quantidade inválida");
                return;
            }

            Console.SetCursorPosition(3, 12);
            bool fabricationDateParse = DateTime.TryParse(Console.ReadLine(), out DateTime fabricationDate);
            if (!fabricationDateParse)
            {
                new MenuScreen().PrintError(27, "Data inválida");
                return;
            }

            Console.SetCursorPosition(3, 14);
            string name = Console.ReadLine();
            if (name == null)
            {
                new MenuScreen().PrintError(27, "Nome inválido");
                return;
            }

            Console.SetCursorPosition(3, 16);
            string plate = Console.ReadLine();
            if (plate == null)
            {
                new MenuScreen().PrintError(27, "Placa inválida");
                return;
            }
            else if (VerifyPlate(plate))
            {
                new MenuScreen().PrintError(27, "Placa já existente");
                return;
            }

            Console.SetCursorPosition(3, 18);
            bool valueParse = Decimal.TryParse(Console.ReadLine(), out Decimal value);
            if (!valueParse || value <= 0)
            {
                new MenuScreen().PrintError(27, "Valor inválido");
                return;
            }

            string[] colorsOptions = { "Branco", "Preto", "Cinza", "Prata", "Vermelho", "Roxo" };
            PrintEnums(25, 8, colorsOptions);
            
            Console.SetCursorPosition(3, 20);
            bool colorParse = EColors.TryParse<EColors>(Console.ReadLine(), out EColors color);
            if (!colorParse || (int) color < 0 || (int) color > 5)
            {
                new MenuScreen().PrintError(27, "Cor inválida");
                return;
            }

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
            bool totalDoorsParse = int.TryParse(Console.ReadLine(), out int totalDoors);
            if (!totalDoorsParse)
            {
                new MenuScreen().PrintError(27, "Portas inválidas");
                return;
            }
            else if (totalDoors < 2 || totalDoors > 4)
            {
                new MenuScreen().PrintError(27, "Quantidade inválida");
                return;
            }
            
            string[] fuelOptions = { "Flex", "Gasolina", "Diesel" };
            PrintEnums(25, 5, fuelOptions);

            Console.SetCursorPosition(3, 10);
            bool fuelTypeParse = ETypeFuel.TryParse<ETypeFuel>(Console.ReadLine(), out ETypeFuel fuelType);
            if (!fuelTypeParse || (int) fuelType < 0 || (int) fuelType > 1)
            {
                new MenuScreen().PrintError(27, "Combustível inválido");
                return;
            }

            Console.SetCursorPosition(3, 12);
            bool horsePowerParse = int.TryParse(Console.ReadLine(), out int horsePower);
            if (!horsePowerParse || horsePower == 0)
            {
                new MenuScreen().PrintError(27, "CVs inválidos");
                return;
            }

            Console.SetCursorPosition(3, 14);
            bool fabricationDateParse = DateTime.TryParse(Console.ReadLine(), out DateTime fabricationDate);
            if (fabricationDateParse)
            {
                new MenuScreen().PrintError(27, "Data inválida");
                return;
            }

            Console.SetCursorPosition(3, 16);
            string name = Console.ReadLine();
            if (name == null)
            {
                new MenuScreen().PrintError(27, "Nome inválido");
                return;
            }

            Console.SetCursorPosition(3, 18);
            string plate = Console.ReadLine();
            if (plate == null)
            {
                new MenuScreen().PrintError(27, "Nome inválido");
                return;
            }
            else if (VerifyPlate(plate))
            {
                new MenuScreen().PrintError(27, "Placa já existente");
                return;
            }

            Console.SetCursorPosition(3, 20);
            bool valueParse = Decimal.TryParse(Console.ReadLine(), out Decimal value);
            if (!valueParse || value <= 0)
            {
                new MenuScreen().PrintError(27, "Valor inválido");
                return;
            }

            string[] colorsOptions = { "Branco", "Preto", "Cinza", "Prata", "Vermelho", "Roxo" };
            PrintEnums(25, 8, colorsOptions);

            Console.SetCursorPosition(3, 22);
            bool colorParse = EColors.TryParse<EColors>(Console.ReadLine(), out EColors color);
            if(!colorParse || (int) color < 0 || (int) color > 5)
            {
                new MenuScreen().PrintError(27, "Cor inválida");
                return;
            }

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

            Console.SetCursorPosition(3, 8);
            bool totalDoorsParse = int.TryParse(Console.ReadLine(), out int totalDoors);
            if (!totalDoorsParse || totalDoors < 2 || totalDoors > 6 )
            {
                new MenuScreen().PrintError(27, "Portas inválidas");
                return;
            }

            Console.SetCursorPosition(3, 10);
            bool cargoSizeLitersParse = int.TryParse(Console.ReadLine(), out int cargoSizeLiters);
            if (!cargoSizeLitersParse)
            {
                new MenuScreen().PrintError(27, "Carga inválida");
                return;
            }

            Console.SetCursorPosition(3, 12);
            bool horsePowerParse = int.TryParse(Console.ReadLine(), out int horsePower);
            if (!horsePowerParse || horsePower == 0)
            {
                new MenuScreen().PrintError(27, "CVs inválidos");
                return;
            }

            string[] fuelOptions = { "Flex", "Gasolina", "Diesel" };
            PrintEnums(25, 5, fuelOptions);
            Console.SetCursorPosition(3, 14);
            bool fuelTypeParse = ETypeFuel.TryParse<ETypeFuel>(Console.ReadLine(), out ETypeFuel fuelType);
            if (!fuelTypeParse || (int) fuelType < 1 || (int) fuelType > 2)
            {
                new MenuScreen().PrintError(27, "Combustível inválido");
                return;
            }

            Console.SetCursorPosition(3, 16);
            bool fabricationDateParse = DateTime.TryParse(Console.ReadLine(), out DateTime fabricationDate);
            if (!fabricationDateParse)
            {
                new MenuScreen().PrintError(27, "Data inválida");
                return;
            }

            Console.SetCursorPosition(3, 18);
            string name = Console.ReadLine();
            if (name == null)
            {
                new MenuScreen().PrintError(27, "Nome inválido");
                return;
            }

            Console.SetCursorPosition(3, 20);
            string plate = Console.ReadLine();
            if (plate == null)
            {
                new MenuScreen().PrintError(27, "Placa inválida");
                return;
            }
            else if(VerifyPlate(plate))
            {
                new MenuScreen().PrintError(27, "Placa já existente");
                return;
            }

            Console.SetCursorPosition(3, 22);
            bool valueParse = Decimal.TryParse(Console.ReadLine(), out Decimal value);
            if (!valueParse || value <= 0)
            {
                new MenuScreen().PrintError(27, "Valor inválido");
                return;
            }

            string[] colorsOptions = { "Branco", "Preto", "Cinza", "Prata", "Vermelho", "Roxo" };
            PrintEnums(25, 8, colorsOptions);

            Console.SetCursorPosition(3, 24);
            bool colorParse = EColors.TryParse<EColors>(Console.ReadLine(), out EColors color);
            if (!colorParse || (int)color != 5)
            {
                new MenuScreen().PrintError(27, "Cor inválida");
                return;
            }

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
        private bool VerifyPlate(string plate)
        {
            return VehiclesRepository.Vehicles
                .Select(vehicle => vehicle.Plate)
                .Contains(plate);
        }
    }
}
