using DEV_Car_Console.Repository;
using DEV_Car_Console.Models;
using DEV_Car_Console.Enum;

namespace DEV_Car_Console.Screens
{
    public class ChangeVehicleScreen
    {
        public void Start()
        {
            string subHeaderText = "Alterar informação do veículo veículo";

            new MenuScreen().PrintMenu(20, 40, subHeaderText);

            Console.SetCursorPosition(2, 7);
            Console.WriteLine("Informe placa do veículo a alterar:");
            Console.SetCursorPosition(2, 8);
            string plate = Console.ReadLine();

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
            decimal value = decimal.Parse(Console.ReadLine());

            string[] colorsOptions = { "Branco", "Preto", "Cinza", "Prata", "Vermelho", "Roxo" };
            PrintEnums(25, 8, 5, colorsOptions);

            Console.SetCursorPosition(2, 13);
            EColors color = EColors.Parse<EColors>(Console.ReadLine());
        }
        private void PrintData(int sizeX, int sizeY, int positionY, string[] data)
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
        private void PrintEnums(int sizeX, int sizeY, int positionY, string[] options)
        {
            PrintPopup(sizeX, sizeY, positionY);
            PrintEnumOptions(options, positionY);
        }
        private void PrintPopup(int sizeX, int sizeY, int positionY)
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
        private void PrintEnumOptions(string[] EnumOptions, int positionY)
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
    }
}
