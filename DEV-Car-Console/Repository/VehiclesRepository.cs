using DEV_Car_Console.Models;

namespace DEV_Car_Console.Repository
{
    public static class VehiclesRepository
    {
        public static IList<Vehicle> Vehicles { get; set; }
        static VehiclesRepository()
        {
            Vehicles = new List<Vehicle>();
        }
    }
}
