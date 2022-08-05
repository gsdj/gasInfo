using Business.BusinessModels.Calculations;
using Business.BusinessModels.DataForCalculations;
using Business.DTO;
using Business.Interfaces.Calculations;
using Business.Interfaces.Calculations.ConsGasQn;
using Moq;
using Newtonsoft.Json;
using System;
using Xunit;

namespace Tests.Calculations.Entities
{
   public class ConsumtionKgTest
   {
      private Mock<ICalcConsGasQnKc2> MockConsGasQnKc2;
      private Mock<ICalcConsGasQnCpsPpk> MockConsGasQnCpsPpk;
      private Mock<ICalculation<DensityDTO>> MockWetGasDensity;

      private ICalculation<ConsumptionKgDTO> ConsKg;
      private Data Data;
      public ConsumtionKgTest()
      {
         MockConsGasQnKc2 = SetupHelper.ConsQnKc2DefaultSetup();
         MockConsGasQnCpsPpk = SetupHelper.ConsQnCpsPpkDefaultSetup();
         MockWetGasDensity = SetupHelper.WetGasDensityDefaultSetup();

         ConsKg = new CalcConsumptionKg(MockWetGasDensity.Object, MockConsGasQnKc2.Object, MockConsGasQnCpsPpk.Object);

         Data = new Data
         {
            CharacteristicsDg = TestCalculatedDataHelper.CharacteristicsDgData(),
            CharacteristicsKg = TestCalculatedDataHelper.CharacteristicsKgData(),
            Kip = TestCalculatedDataHelper.DevicesKipData(),
            Pressure = TestCalculatedDataHelper.PressureData(),
         };
      }
      private ConsumptionKgDTO ExpectedObject()
      {
         return new ConsumptionKgDTO
         {
            Date = new DateTime(2019, 1, 1),
            QcRcCb =
            {
               Cb1 = { Value = 172764.7187806236m },
               Cb2 = { Value = 169818.8865273301m },
               Cb3 =
               {
                  Ms = 2483.0345146359m,
                  Ks = 2480.1041041151m,
               },
               Cb4 =
               {
                  Ms = 2477.1381279019m,
                  Ks = 2904.1311981978m,
               },
            },
            QcRcCpsPpk =
            {
               Pko =
               {
                  Pkp = 
                  {
                     Ms = 13012.0786034459m,
                     Ks = 12069.4892580468m,
                  },
                  Uvtp = 19175.6120086851m,
               },
               Spo = 29877.0533268474m,
            },
            QcRcGsuf = 5488.5674320788m,
            ConsumptionCb =
            {
               Cb1 = 155488.2469025612m,
               Cb2 = 152836.9978745971m,
               Cb3 = 113397.7911612228m,
               Cb4 = 122951.2415627259m,
            },
            ConsumptionCpsPpk =
            {
               //Pko = { Total = 39831.4529956080m },
               Pko = 
               { 
                  Pkp = 22573.4110753434m,
                  Uvtp = 17258.0508078166m, 
               },
               Spo = 26889.3479941627m,
            },
            ConsumptionKc2Sum = 544674.2775011070m,
            PkoQcRcSum = 44257.1798701778m,
            ConsumptionCpsPpkSum = 66720.8098773227m,
            ConsumptionGsuf = 4939.7106888709m,
            ConsumptionMkSum = 611395.0873784297m,
            ConsumptionMkGsufSum = 616334.7980673006m,
         };
      }
      [Fact]
      public void CounsumptionKg()
      {

         var expected = JsonConvert.SerializeObject(ExpectedObject());

         var result = JsonConvert.SerializeObject(ConsKg.CalcEntity(Data));

         Assert.Equal(expected, result);
      }
   }
}
