﻿using DEV_Car_Console.Models;

namespace DEV_Car_Console.Repository
{
    public class TransferHistoryRepository
    {
        public IList<Financial> TransferHistory { get; set; }
        public TransferHistoryRepository()
        {
            TransferHistory = new List<Financial>();
        }
    }
}
