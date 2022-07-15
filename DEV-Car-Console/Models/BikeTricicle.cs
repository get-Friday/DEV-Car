﻿using DEV_Car_Console.Enum;

namespace DEV_Car_Console.Models
{
    public class BikeTricicle : Vehicle
    {
        public int Potency { get; set; }
        public int QntWheels { get; set; }
        public BikeTricicle(int potency,
                            int qntWheels,
                            DateTime fabricationDate,
                            string name,
                            string plate,
                            decimal value,
                            EColors color,
                            ETypeVehicle type) : base(fabricationDate, name, plate, value, color, type)
        {
            Potency = potency;
            QntWheels = qntWheels;
        }
        public override string ShowInfo()
        {
            return $"{base.ShowInfo()} \n| POTENCIA: {Potency}cc | RODAS: {QntWheels}";
        }
        public override bool IsValid()
        {
            if (
                Potency <= 0 ||
                (QntWheels < 2 || QntWheels > 3)
                )
            {
                return false;
            }
            return base.IsValid();
        }
    }
}
