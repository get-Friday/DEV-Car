using DEV_Car_Console.Repository;
using DEV_Car_Console.Models;

namespace DEV_Car_Console.Screens
{
    public static class AvailableVehiclesScreen
    {
        public static void Start(VehiclesRepository vehicles, TransferHistoryRepository transferHistory)
        {
           
        }
        public static void PrintContent(VehiclesRepository vehicles)
        {
            Console.SetCursorPosition(2, 5);
            Console.WriteLine("Lista de veículos disponíveis:");

            int row = 7;
            foreach (Vehicle vehicle in vehicles.Vehicles)
            {
                if (vehicle.BuyerCPF == null)
                {
                    Console.SetCursorPosition(2, row);
                    Console.WriteLine(vehicle.Name);
                    row++;
                }                
            }
        }
    }
}
