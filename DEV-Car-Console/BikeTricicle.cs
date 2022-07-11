namespace DEV_Car_Console
{
    public class BikeTricicle : Vehicle
    {
        public int Potency { get; set; }
        public int Wheels { get; set; }
        public BikeTricicle(int potency,
                            int wheels,
                            DateTime fabricationDate,
                            string name,
                            string plate,
                            decimal value,
                            string color) : base(fabricationDate, name, plate, value, color)
        {
            Potency = potency;
            Wheels = wheels;
        }
    }
}
