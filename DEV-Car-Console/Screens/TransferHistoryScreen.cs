using DEV_Car_Console.Models;
using DEV_Car_Console.Repository;

namespace DEV_Car_Console.Screens
{
    public class TransferHistoryScreen
    {
        public void Start()
        {
            string subHeaderText = "Histórico de transferências";
            int canvasSize = TransferHistoryRepository.TransferHistory.Count * 2 + 10;
            int row = 7;

            new MenuScreen().PrintMenu(canvasSize, 110, subHeaderText);

            foreach (var item in TransferHistoryRepository.TransferHistory)
            {
                Console.SetCursorPosition(2, row);
                Console.WriteLine(item.ShowInfo());
                row += 2;
            }

            Console.ReadLine();
        }
    }
}
