using DEV_Car_Console.Repository;

namespace DEV_Car_Console.Screens
{
    public static class MenuScreen
    {
        public static void Start(VehiclesRepository vehicles, TransferHistoryRepository transferHistory)
        {
            Console.Clear();
            PrintCanvas();
            PrintHeader();
            PrintOptions();

            var option = short.Parse(Console.ReadLine());

            switch (option)
            {
                case 1: RegisterVehicleScreen.Start(vehicles, transferHistory); break;
                default: break;
            }

        }
        public static void PrintCanvas()
        {
            PrintHorizontalLine();
            for (int i = 0; i < 15; i++)
            {
                Console.Write("|");

                for (int line = 0; line <= 35; line++)
                    Console.Write(" ");

                Console.Write("|");
                Console.Write(Environment.NewLine);
            }
            PrintHorizontalLine();
        }
        public static void PrintHeader()
        {
            Console.SetCursorPosition(2, 2);
            Console.WriteLine("DEV Car");
            Console.SetCursorPosition(2, 3);
            Console.WriteLine("=================");
        }
        public static void PrintOptions()
        {
            Console.SetCursorPosition(2, 5);
            Console.WriteLine("1 - Registrar novo veículo");
            Console.SetCursorPosition(2, 6);
            Console.WriteLine("2 - Listar veículos");
            Console.SetCursorPosition(2, 7);
            Console.WriteLine("3 - Carros disponíveis");
            Console.SetCursorPosition(2, 8);
            Console.WriteLine("4 - Carros vendidos");
            // TODO?
            // Para listar menor/maior valor usar o LINQ
            // https://docs.microsoft.com/pt-br/dotnet/csharp/linq/write-linq-queries
            Console.SetCursorPosition(2, 9);
            Console.WriteLine("5 - Histórico de transferências");
            Console.SetCursorPosition(2, 11);
            Console.WriteLine("0 - Sair");

            Console.SetCursorPosition(2, 14);
            Console.Write("Opção selecionada: ");
        }
        public static void PrintHorizontalLine()
        {
            Console.Write("+");

            for (int i = 0; i <= 35; i++)
                System.Console.Write("-");

            Console.Write("+");
            Console.Write(Environment.NewLine);
        }
    }
}
