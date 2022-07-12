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
                            string color) : base(fabricationDate, name, plate, value, color)
        {
            Potency = potency;
            QntWheels = qntWheels;
        }
    }
}
