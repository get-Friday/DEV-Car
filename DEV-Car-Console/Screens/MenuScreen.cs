﻿namespace DEV_Car_Console.Screens
{
    public static class MenuScreen
    {
        public static void Start()
        {
            string[] menuOptions = {
                "Registrar novo veículo",
                "Listar veículos",
                "Carros disponíveis",
                "Carros vendidos",
                "Histórico de transferências"
            };

            PrintMenu(17, 35, "Bem vindo!", menuOptions, "Sair");

            var option = short.Parse(Console.ReadLine());

            switch (option)
            {
                case 0: Environment.Exit(0); break;
                case 1: new RegisterVehicleScreen().Start(); Start(); break;
                case 2: new ShowVehiclesScreen().Start(); Start(); break;
                case 3: new AvailableVehiclesScreen().Start(); Start(); break;
                case 4: break;
                case 5: break;
                default: Start(); break;
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
