﻿namespace DEV_Car_Console.Models
{
    public class Vehicle
    {
        public Guid FrameNumber { get; set; }
        public DateTime FabricationDate { get; set; }
        public string Name { get; set; }
        public string Plate { get; set; }
        public decimal Value { get; set; }
        public string BuyerCPF { get; set; }
        public string Color { get; set; }
        public Vehicle(DateTime fabricationDate,
                       string name,
                       string plate,
                       decimal value,
                       string color)
        {
            FrameNumber = Guid.NewGuid();
            FabricationDate = fabricationDate;
            Name = name;
            Plate = plate;
            Value = value;
            BuyerCPF = "0";
            Color = color;
        }
        public void SellVehicle()
        {

        }
        public string ShowInfo()
        {
            return "";
        }
        public void ChangeInfo()
        {

        }
    }
}
