using DEV_Car_Console.Models;
using DEV_Car_Console.Enum;

namespace DEV_Car_Tests
{
    public class TestColorPickup
    {
        [Theory]
        [InlineData(EColors.Roxo)]
        public void Test_Color_Pickup_Success(EColors color)
        {
            PickupTruck pickup = new(4, 100, 200, ETypeFuel.Diesel, DateTime.Parse("20/02/2022"), "CAMINHONETA", "TESTE1", 30M, color, ETypeVehicle.Caminhonete);

            Assert.True(pickup.IsValid());
        }

        [Theory]
        [InlineData(EColors.Branco)]
        [InlineData(EColors.Prata)]
        public void Test_Color_Pickup_Failure(EColors color)
        {
            PickupTruck pickup = new(4, 100, 200, ETypeFuel.Diesel, DateTime.Parse("20/02/2022"), "CAMINHONETA", "TESTE1", 30M, color, ETypeVehicle.Caminhonete);

            Assert.True(pickup.IsValid());
        }
    }
}