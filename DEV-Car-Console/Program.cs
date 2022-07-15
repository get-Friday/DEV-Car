using DEV_Car_Console.Screens;
using DEV_Car_Console.Models;
using DEV_Car_Console.Repository;
using DEV_Car_Console.Enum;

namespace DEV_Car_Console;
class Program
{
    static void Main(string[] args)
    {
        PopulateList();
        MenuScreen.Start();
    }
    static void PopulateList()
    {
        BikeTricicle CRF = new(250, 2, DateTime.Parse("20/06/2013"), "Honda CRF", "A08ADV8", 4499.0M, EColors.Preto, ETypeVehicle.MotoTriciclo);
        BikeTricicle Husaberg = new(250, 2, DateTime.Parse("01/03/2013"), "Husaberg FE 250", "P01KE2L", 8649.0M, EColors.Vermelho, ETypeVehicle.MotoTriciclo);
        BikeTricicle Spyder = new(1330, 3, DateTime.Parse("04/04/2019"), "Cam-Am Spyder RT Limited", "K01SY9", 26999.0M, EColors.Preto, ETypeVehicle.MotoTriciclo);

        VehiclesRepository.Vehicles.Add(CRF);
        VehiclesRepository.Vehicles.Add(Husaberg);
        VehiclesRepository.Vehicles.Add(Spyder);

        Car A3 = new(4, ETypeFuel.Flex, 110, DateTime.Parse("08/11/2020"), "Audi A3", "LA92CM1", 243990.0M, EColors.Branco, ETypeVehicle.Carro);
        Car TT = new(2, ETypeFuel.Flex, 245, DateTime.Parse("06/06/2019"), "Audi TT Coupe", "LTT02M4", 442990.0M, EColors.Preto, ETypeVehicle.Carro);
        Car Across = new(4, ETypeFuel.Flex, 306, DateTime.Parse("20/02/2020"), "Suziki Across", "AC5S50", 58725.0M, EColors.Branco, ETypeVehicle.Carro);

        TT.SellVehicle(1234);
        A3.SellVehicle(0004);
        Financial FTT = new(TT, DateTime.Parse("07/06/2019"));
        Financial FA3 = new(A3, DateTime.Parse("23/11/2020"));

        TransferHistoryRepository.TransferHistory.Add(FTT);
        TransferHistoryRepository.TransferHistory.Add(FA3);

        VehiclesRepository.Vehicles.Add(A3);
        VehiclesRepository.Vehicles.Add(TT);
        VehiclesRepository.Vehicles.Add(Across);

        PickupTruck Silverado = new(4, 2903, 288, ETypeFuel.Diesel, DateTime.Parse("18/09/2014"), "Silverado 1500", "SL400MA", 49620.0M, EColors.Roxo, ETypeVehicle.Caminhonete);


        VehiclesRepository.Vehicles.Add(Silverado);
    }
}