using DEV_Car_Console.Models;

namespace DEV_Car_Console.Repository
{
    public class VehiclesRepository
    {
        public IList<Vehicle> Vehicles { get; set; }
        public VehiclesRepository()
        {
            Vehicles = new List<Vehicle>();
        }
    }
}
