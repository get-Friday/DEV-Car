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
            MenuScreen.PrintMenu(15, 30, subHeaderText, menuOptions, "Voltar");

            var options = short.Parse(Console.ReadLine());

            switch (options)
            {
                case 1: RegisterBikeTricicle(vehicles); break;
                default: break;
            }
        }
        public static void RegisterBikeTricicle(VehiclesRepository vehicles)
        {

        }
    }
}
