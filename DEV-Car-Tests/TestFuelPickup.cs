using DEV_Car_Console.Models;
using DEV_Car_Console.Enum;

namespace DEV_Car_Tests
{
    public class TestFuelPickup
    {
        [Theory]
        [InlineData(ETypeFuel.Diesel)]
        [InlineData(ETypeFuel.Gasolina)]
        public void Test_Pickup_Fuel_Success(ETypeFuel fuelType)
        {
            PickupTruck pickup = new(4, 2903, 288, fuelType, DateTime.Parse("06/06/2006"), "CAMINHONETA", "PLACA01", 49620.0M, EColors.Roxo, ETypeVehicle.Caminhonete);

            Assert.True(pickup.IsValid());
        }
        [Theory]
        [InlineData(ETypeFuel.Flex)]
        public void Test_Pickup_Fuel_Failure(ETypeFuel fuelType)
        {
            PickupTruck pickup = new(4, 2903, 288, fuelType, DateTime.Parse("06/06/2006"), "CAMINHONETA", "PLACA01", 49620.0M, EColors.Roxo, ETypeVehicle.Caminhonete);

            Assert.False(pickup.IsValid());
        }
    }
}
