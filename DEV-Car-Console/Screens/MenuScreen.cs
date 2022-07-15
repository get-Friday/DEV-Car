namespace DEV_Car_Console.Screens
{
    internal static class MenuScreen
    {
        public static void Start()
        {
            string subHeaderText = "Bem vindo!";
            string[] menuOptions = {
                "Registrar novo veículo",
                "Vender veículo",
                "Alterar veículo",
                "Listar veículos",
                "Veículos disponíveis",
                "Veículos vendidos",
                "Histórico de transferências"
            };

            PrintMenu(20, 55, subHeaderText, menuOptions, "Sair");

            bool input = short.TryParse(Console.ReadLine(), out short option);

            if (input)
            {
                switch (option)
                {
                    case 0: Environment.Exit(0); break;
                    case 1: RegisterVehicleScreen.Start(); Start(); break;
                    case 2: SellVehicleScreen.Start(); Start(); break;
                    case 3: ChangeVehicleScreen.Start(); Start(); break;
                    case 4: ShowVehiclesScreen.Start(); Start(); break;
                    case 5: AvailableVehiclesScreen.Start(); Start(); break;
                    case 6: SoldVehiclesScreen.Start(); Start(); break;
                    case 7: TransferHistoryScreen.Start(); Start(); break;
                    default: PrintError(20, "Opção inexistente"); Start(); break;
                }
            }
            else
            {
                PrintError(20, "Opção inválida");
                Start();
            }

        }
        public static void PrintMenu(int canvasSizeY, int CanvasSizeX, string SubHeaderText, string[] menuOptions, string footerOption)
        {
            Console.Clear();
            ConfigureCanvas(canvasSizeY, CanvasSizeX);
            PrintHeader();
            ConfigureSubHeader(SubHeaderText);
            ConfigureOptions(menuOptions);
            ConfigureFooter(canvasSizeY, footerOption);
        }
        public static void PrintMenu(int canvasSizeY, int CanvasSizeX, string SubHeaderText, string[] menuOptions)
        {
            Console.Clear();
            ConfigureCanvas(canvasSizeY, CanvasSizeX);
            PrintHeader();
            ConfigureSubHeader(SubHeaderText);
            ConfigureQuery(menuOptions);
        }
        public static void PrintMenu(int canvasSizeY, int CanvasSizeX, string SubHeaderText)
        {
            Console.Clear();
            ConfigureCanvas(canvasSizeY, CanvasSizeX);
            PrintHeader();
            ConfigureSubHeader(SubHeaderText);
        }
        public static void PrintError(int positionY, string errorMessage)
        {
            Console.SetCursorPosition(2, positionY);
            Console.WriteLine($"{errorMessage}. Pressione uma tecla para voltar");
            var s = Console.ReadLine();
        }
        public static void PrintPopup(int sizeX, int sizeY, int positionX, int positionY)
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
        public static void PrintEnums(int sizeX, int sizeY, int positionX, int positionY, string[] options, string type)
        {
            // Popup has always to be 3 units away from text:
            // 123
            // | text

            PrintPopup(sizeX, sizeY, positionX - 3, positionY);
            PrintEnumOptions(options, type, positionX, positionY);
        }
        private static void PrintEnumOptions(string[] options, string type, int positionX, int positionY)
        {
            Console.SetCursorPosition(positionX, positionY + 1);
            Console.WriteLine($"Código {type}: ");

            int row = positionY + 2;
            for (int i = 0; i < options.Length; i++)
            {
                Console.SetCursorPosition(positionX, row);
                Console.WriteLine($"{i} - {options[i]}");
                row++;
            }
        }
        private static void ConfigureCanvas(int sizeY, int sizeX)
        {
            PrintHorizontalLine(sizeX);
            for (int i = 0; i < sizeY; i++)
            {
                Console.Write("|");

                for (int line = 0; line <= sizeX; line++)
                    Console.Write(" ");

                Console.Write("|");
                Console.Write(Environment.NewLine);
            }
            PrintHorizontalLine(sizeX);
        }
        private static void PrintHorizontalLine(int size)
        {
            Console.Write("+");

            for (int i = 0; i <= size; i++)
                System.Console.Write("-");

            Console.Write("+");
            Console.Write(Environment.NewLine);
        }
        private static void PrintHeader()
        {
            Console.SetCursorPosition(2, 2);
            Console.WriteLine("DEV Car");
            Console.SetCursorPosition(2, 3);
            Console.WriteLine("=================");
        }
        private static void ConfigureSubHeader(string text)
        {
            Console.SetCursorPosition(2, 5);
            Console.WriteLine(text);
        }
        private static void ConfigureOptions(string[] options)
        {
            int row = 7;
            for (int i = 0; i < options.Length; i++)
            {
                Console.SetCursorPosition(2, row);
                Console.WriteLine($"{i + 1} - {options[i]}");
                row++;
            }
        }
        private static void ConfigureQuery(string[] options)
        {
            int row = 7;
            for (int i = 0; i < options.Length; i++)
            {
                Console.SetCursorPosition(2, row);
                Console.WriteLine($"Informe {options[i]}: ");
                row += 2;
            }
        }
        private static void ConfigureFooter(int lastRow, string option)
        {
            Console.SetCursorPosition(2, lastRow - 3);
            Console.WriteLine($"0 - {option}");

            Console.SetCursorPosition(2, lastRow - 1);
            Console.Write("Selecionar opção: ");
        }
    }
}
