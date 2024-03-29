﻿using DEV_Car_Console.Models;
using DEV_Car_Console.Repository;

namespace DEV_Car_Console.Screens
{
    internal static class TransferHistoryScreen
    {
        public static void Start()
        {
            string subHeaderText = "Histórico de transferências";
            int canvasSize = TransferHistoryRepository.TransferHistory.Count * 2 + 10;
            int row = 7;

            MenuScreen.PrintMenu(canvasSize, 110, subHeaderText);

            foreach (Financial history in TransferHistoryRepository.TransferHistory)
            {
                Console.SetCursorPosition(2, row);
                Console.WriteLine(history.ShowInfo());
                row += 2;
            }

            Console.ReadLine();
        }
    }
}
