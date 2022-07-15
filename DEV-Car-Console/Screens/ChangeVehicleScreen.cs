using DEV_Car_Console.Repository;
using DEV_Car_Console.Models;
using DEV_Car_Console.Enum;

namespace DEV_Car_Console.Screens
{
    public static class ChangeVehicleScreen
    {
        public static void Start()
        {
            int canvasSizeY = 20;
            int canvasSizeX = 65;
            string subHeaderText = "Alterar informação do veículo veículo";

            MenuScreen.PrintMenu(canvasSizeY, canvasSizeX, subHeaderText);

            // Input plate

            Console.SetCursorPosition(2, 7);
            Console.WriteLine("Informe placa do veículo a alterar:");
            Console.SetCursorPosition(2, 8);
            string plate = Console.ReadLine()!;

            // Verify plate

            if (plate == null)
            {
                MenuScreen.PrintError(canvasSizeY, "Campo inválido");
                return;
            }

            bool containsPlate = VehiclesRepository.Vehicles
                .Select(vehicle => vehicle.Plate)
                .Contains(plate);

            if (!containsPlate)
            {
                MenuScreen.PrintError(canvasSizeY, "Placa inexistente");
                return;
            }

            // Get vehicle

            Vehicle? query = VehiclesRepository.Vehicles
                .ToList()
                .Find(vehicle => vehicle.Plate == plate);

            // Print found data

            Decimal oldValue = query.Value;
            EColors oldColor = query.Color;
            string[] carData = { $"R${oldValue}", $"{oldColor}" };
            PrintData(26, 5, canvasSizeX + 6, canvasSizeY - 5, carData);

            // Values to change input

            Console.SetCursorPosition(2, 10);
            Console.WriteLine("Novo preço:");
            Console.SetCursorPosition(2, 12);
            Console.WriteLine("Nova cor:");

            Console.SetCursorPosition(2, 11);
            bool valueParse = Decimal.TryParse(Console.ReadLine(), out Decimal value);

            string[] colorsOptions = { "Branco", "Preto", "Cinza", "Prata", "Vermelho", "Roxo" };
            PrintEnums(26, 8, canvasSizeX + 6, canvasSizeY - 15, colorsOptions);

            Console.SetCursorPosition(2, 13);
            bool colorParse = EColors.TryParse<EColors>(Console.ReadLine(), out EColors color);

            // Verify inputs integrity

            if (!valueParse || !colorParse)
            {
                MenuScreen.PrintError(canvasSizeY, "Campo inválido");
                return;
            }

            // Changes values

            query.ChangeInfo(value, color);

            // Verify class integrity

            if (!query.IsValid())
            {
                // Changes values back

                query.ChangeInfo(oldValue, oldColor);

                MenuScreen.PrintError(canvasSizeY, "Mudança inválida, revertendo");
            }
        }
        private static void PrintData(int sizeX, int sizeY, int positionX, int positionY, string[] data)
        {
            // Popup has always to be 3 units away from text:
            // 123
            // | text

            PrintPopup(sizeX, sizeY, positionX - 3, positionY);

            Console.SetCursorPosition(positionX, positionY + 1);
            Console.WriteLine("Valor e cor do veículo");

            int row = positionY + 3;
            for (int i = 0; i < data.Length; i++)
            {
                Console.SetCursorPosition(positionX, row);
                Console.WriteLine($"{data[i]}");
                row++;
            }
        }
        private static void PrintEnums(int sizeX, int sizeY, int positionX, int positionY, string[] options)
        {
            // Popup has always to be 3 units away from text:
            // 123
            // | text

            PrintPopup(sizeX, sizeY, positionX - 3, positionY);
            PrintEnumOptions(options, positionX, positionY);
        }
        private static void PrintPopup(int sizeX, int sizeY, int positionX, int positionY)
        {
            Console.SetCursorPosition(positionX, positionY);
            Console.Write("+");
            for (int i = 0; i <= sizeX; i++)
                Console.Write("-");
            Console.Write("+");

            for (int i = 0; i < sizeY; i++)
            {
                Console.SetCursorPosition(positionX, i + positionY + 1);
                Console.Write("|");
                for (int line = 0; line <= sizeX; line++)
                    Console.Write(" ");
                Console.Write("|");
            }

            Console.SetCursorPosition(positionX, sizeY + positionY + 1);
            Console.Write("+");
            for (int i = 0; i <= sizeX; i++)
                Console.Write("-");
            Console.Write("+");
        }
        private static void PrintEnumOptions(string[] EnumOptions, int positionX, int positionY)
        {
            Console.SetCursorPosition(positionX, positionY + 1);
            Console.WriteLine("Usar código de cada cor: ");

            int row = positionY + 2;
            for (int i = 0; i < EnumOptions.Length; i++)
            {
                Console.SetCursorPosition(positionX, row);
                Console.WriteLine($"{i} - {EnumOptions[i]}");
                row++;
            }
        }
    }
}
