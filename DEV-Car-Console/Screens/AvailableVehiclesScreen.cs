﻿using DEV_Car_Console.Repository;
using DEV_Car_Console.Models;

namespace DEV_Car_Console.Screens
{
    public class AvailableVehiclesScreen
    {
        public void Start()
        {
            IEnumerable<Vehicle> query = VehiclesRepository.Vehicles.Where(vehicle => vehicle.BuyerCPF == null);
            
            string subHeaderText = "Veículos disponíveis pra compra";
            int canvasSize = query.Count() * 2 + 10;
            int row = 7;

            new MenuScreen().PrintMenu(canvasSize, 85, subHeaderText);

            foreach (Vehicle vehicle in query)
            {
                Console.SetCursorPosition(2, row);
                Console.WriteLine(vehicle.ShowInfo());
                row += 2;
            }

            Console.ReadLine();
        }
    }
}
