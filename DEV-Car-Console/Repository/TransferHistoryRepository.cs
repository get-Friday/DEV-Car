using DEV_Car_Console.Models;

namespace DEV_Car_Console.Repository
{
    public static class TransferHistoryRepository
    {
        public static IList<Financial> TransferHistory { get; set; }
        static TransferHistoryRepository()
        {
            TransferHistory = new List<Financial>();
        }
    }
}
