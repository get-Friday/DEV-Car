using DEV_Car_Console.Repository;
using DEV_Car_Console.Models;

namespace DEV_Car_Console.Screens
{
    public static class RegisterVehicleScreen
    {
        public static void Start(VehiclesRepository vehicles, TransferHistoryRepository transferHistory)
        {
            string subHeaderText = "Escolha tipo de veículo para registrar";
            string[] menuOptions = { "Moto/Triciclo", "Carro", "Caminhonete" };
            MenuScreen.PrintMenu(17, 55, subHeaderText, menuOptions, "Voltar");

            var options = short.Parse(Console.ReadLine());

            switch (options)
            {
                case 1: RegisterBikeTricicle(vehicles); break;
                default: break;
            }
        }
        public static void RegisterBikeTricicle(VehiclesRepository vehicles)
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
            MenuScreen.PrintMenu(23, 55, subHeaderText, menuOptions);

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
            Console.SetCursorPosition(3, 20);
            string color = Console.ReadLine();

            BikeTricicle bikeTricicle = new(potency, qntWheels, fabricationDate, name, plate, value, color);

            vehicles.Vehicles.Add(bikeTricicle);

            Console.SetCursorPosition(2, 22);
            Console.WriteLine("Veículo adicionado!");
            Console.SetCursorPosition(2, 23);
            Console.WriteLine("Pressione qualquer tecla para voltar");
            var option = Console.ReadLine();
        }
    }
}
