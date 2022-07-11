using DEV_Car_Console.Screens;
using DEV_Car_Console.Models;
using DEV_Car_Console.Repository;

namespace DEV_Car_Console;
class Program
{
    static void Main(string[] args)
    {
        VehiclesRepository vehicles = new ();
        TransferHistoryRepository transferHistory = new ();
        MenuScreen.Start(vehicles, transferHistory);
    }
    static void PopulateList()
    {
        // TODO:
        // popular lista com veículos
    }
}