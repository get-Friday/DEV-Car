using DEV_Car_Console.Repository;

namespace DEV_Car_Console.Screens
{
    public static class RegisterVehicleScreen
    {
        public static void Start(VehiclesRepository vehicle, TransferHistoryRepository transferHistory)
        {
            Console.Clear();
            MenuScreen.PrintCanvas();
            MenuScreen.PrintHeader();
            PrintOption();

            var option = short.Parse(Console.ReadLine());
        }
        public static void PrintOption()
        {
            Console.SetCursorPosition(2, 5);
            Console.WriteLine("Escolha o tipo do veículo:");
            Console.SetCursorPosition(2, 7);
            Console.WriteLine("1 - Motos/Triciclos");
            Console.SetCursorPosition(2, 8);
            Console.WriteLine("2 - Carros");
            Console.SetCursorPosition(2, 9);
            Console.WriteLine("3 - Caminhonete");

            Console.SetCursorPosition(2, 11);
            Console.WriteLine("Pressione outra tecla para voltar");

            Console.SetCursorPosition(2, 14);
            Console.Write("Opção selecionada: ");
        }
    }
}
