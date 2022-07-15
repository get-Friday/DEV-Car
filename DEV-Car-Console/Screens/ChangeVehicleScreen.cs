using DEV_Car_Console.Repository;
using DEV_Car_Console.Models;
using DEV_Car_Console.Enum;

namespace DEV_Car_Console.Screens
{
    public static class ChangeVehicleScreen
    {
        public static void Start()
        {
            string subHeaderText = "Alterar informação do veículo veículo";

            MenuScreen.PrintMenu(20, 55, subHeaderText);

            Console.SetCursorPosition(2, 7);
            Console.WriteLine("Informe placa do veículo a alterar:");
            Console.SetCursorPosition(2, 8);
            string plate = Console.ReadLine();
            if (plate == null)
            {
                MenuScreen.PrintError(20, "Placa inválida");
                return;
            }
            
            if (VerifyPlate(plate))
            {
                Vehicle query = VehiclesRepository.Vehicles
                    .ToList()
                    .Find(vehicle => vehicle.Plate == plate);

                string[] carData = { $"R${query.Value}", $"{query.Color}" };
                PrintData(25, 5, 15, carData);

                Console.SetCursorPosition(2, 10);
                Console.WriteLine("Novo preço:");
                Console.SetCursorPosition(2, 12);
                Console.WriteLine("Nova cor:");

                Console.SetCursorPosition(2, 11);
                bool valueParse = decimal.TryParse(Console.ReadLine(), out Decimal value);
                if (!valueParse || value == 0)
                {
                    MenuScreen.PrintError(20, "Valor inválido");
                    return;
                }

                string[] colorsOptions = { "Branco", "Preto", "Cinza", "Prata", "Vermelho", "Roxo" };
                PrintEnums(25, 8, 5, colorsOptions);

                Console.SetCursorPosition(2, 13);
                bool colorParse = EColors.TryParse<EColors>(Console.ReadLine(), out EColors color);
                if (!colorParse || (query.Type == ETypeVehicle.Caminhonete && (int)color != 5) || ((int) color < 0 || (int) color > 5))
                {
                    MenuScreen.PrintError(20, "Cor inválida");
                    return;
                }

                query.ChangeInfo(value, color);
            }
            else
            {
                MenuScreen.PrintError(20, "Placa inexistênte");
                return;
            }
        }
        private static void PrintData(int sizeX, int sizeY, int positionY, string[] data)
        {
            PrintPopup(sizeX, sizeY, positionY);

            Console.SetCursorPosition(59, positionY + 1);
            Console.WriteLine("Valor e cor do veículo");

            int row = positionY + 3;
            for (int i = 0; i < data.Length; i++)
            {
                Console.SetCursorPosition(59, row);
                Console.WriteLine($"{data[i]}");
                row++;
            }
        }
        private static void PrintEnums(int sizeX, int sizeY, int positionY, string[] options)
        {
            PrintPopup(sizeX, sizeY, positionY);
            PrintEnumOptions(options, positionY);
        }
        private static void PrintPopup(int sizeX, int sizeY, int positionY)
        {
            Console.SetCursorPosition(57, positionY);
            Console.Write("+");
            for (int i = 0; i <= sizeX; i++)
                Console.Write("-");
            Console.Write("+");

            for (int i = 0; i < sizeY; i++)
            {
                Console.SetCursorPosition(57, i + positionY + 1);
                Console.Write("|");
                for (int line = 0; line <= sizeX; line++)
                    Console.Write(" ");
                Console.Write("|");
            }

            Console.SetCursorPosition(57, sizeY + positionY + 1);
            Console.Write("+");
            for (int i = 0; i <= sizeX; i++)
                Console.Write("-");
            Console.Write("+");
        }
        private static void PrintEnumOptions(string[] EnumOptions, int positionY)
        {
            Console.SetCursorPosition(59, positionY + 1);
            Console.WriteLine("Usar código de cada cor: ");

            int row = positionY + 2;
            for (int i = 0; i < EnumOptions.Length; i++)
            {
                Console.SetCursorPosition(59, row);
                Console.WriteLine($"{i} - {EnumOptions[i]}");
                row++;
            }
        }
        private static bool VerifyPlate(string plate)
        {
            return VehiclesRepository.Vehicles
                .Select(vehicle => vehicle.Plate)
                .Contains(plate);
        }
    }
}
