using Business.BusinessModels.BaseCalculations;
using Business.BusinessModels.BaseCalculations.Density;
using Business.BusinessModels.BaseCalculations.Qn;
using Business.BusinessModels.Calculations;
using Business.BusinessModels.DataForCalculations;
using Business.DTO;
using Business.Interfaces;
using Business.Interfaces.BaseCalculations;
using Business.Interfaces.BaseCalculations.Consumption;
using Business.Interfaces.BaseCalculations.Density;
using Business.Interfaces.Calculations;
using Moq;
using Newtonsoft.Json;
using System;
using Xunit;

namespace Tests.Calculations.Entities
{
   public class ConsumtionKgTest
   {
      private Mock<ISteamCharacteristicsService> MockSteam;
      private IDryDensity DryDensity;
      private IWetDensity WetDensity;
      private ICalculation<DensityDTO> WetGasDensity;
      private ICalculation<ConsumptionKgDTO> ConsKg;
      private Mock<IQcRc> MockQcRc;
      private Mock<IConsGasQn<ConsGasQn4000>> MockConsGasQn;
      private Data Data;
      public ConsumtionKgTest()
      {
         //MockSteam = new Mock<ISteamCharacteristicsService>();
         //MockSteam.Setup(p => p.GetCharacteristics()).Returns(TestHelper.SteamCharacteristicsData());

         //MockConsGasQn = new Mock<IConsGasQn<ConsGasQn4000>>();
         //MockQcRc = new Mock<IQcRc>();

         //DryDensity = new DryDensity(MockSteam.Object);
         //WetDensity = new WetDensity(MockSteam.Object);
         //WetGasDensity = new CalcWetGasDensity(WetDensity, DryDensity);

         //MockQcRc.SetupProperty(p => p.SteamCharacteristicsService, MockSteam.Object);
         //var qcrcDef = new DefaultQcRc(MockSteam.Object);
         //var consGasQn4 = new ConsGasQn4000();

         //MockQcRc.Setup(p => p.Calc(It.IsAny<decimal>(), It.IsAny<decimal>(), It.IsAny<decimal>(), It.IsAny<decimal>(), It.Is<bool>(p => false)))
         //   .Returns((decimal cons, decimal wetGas, decimal temp, decimal density, bool perHour) =>
         //   qcrcDef.Calc(cons, wetGas, temp, density, perHour));

         //MockQcRc.Setup(p => p.Calc(It.IsAny<decimal>(), It.IsAny<decimal>(), It.IsAny<decimal>(), It.IsAny<decimal>(), It.Is<bool>(p => true)))
         //   .Returns((decimal cons, decimal wetGas, decimal temp, decimal density, bool perHour) =>
         //   qcrcDef.Calc(cons, wetGas, temp, density, perHour));

         //MockConsGasQn.Setup(p => p.Calc(It.IsAny<decimal>(), It.IsAny<decimal>()))
         //   .Returns((decimal qcrc, decimal qn) => consGasQn4.Calc(qcrc, qn));

         //ConsKg = new CalcConsumptionKg(WetGasDensity, MockQcRc.Object, MockConsGasQn.Object);

         //Data = new Data
         //{
         //   CharacteristicsDg = TestHelper.CharacteristicsDgData(),
         //   CharacteristicsKg = TestHelper.CharacteristicsKgData(),
         //   Kip = TestHelper.DevicesKipData(),
         //   Pressure = TestHelper.PressureData(),
         //};
      }

      private ConsumptionKgDTO ExpectedObject()
      {
         return new ConsumptionKgDTO
         {
            Date = new DateTime(2019, 1, 1),
            QcRcCb =
            {
               Cb1 = { Value = 172766.4177360802m },
               Cb2 = { Value = 169816.6033372864m },
               Cb3 =
               {
                  Ms = 2482.9866551005m,
                  Ks = 2480.0563010622m,
               },
               Cb4 =
               {
                  Ms = 2477.1255244498m,
                  Ks = 2904.1164222440m,
               },
            },
            QcRcCpsPpk =
            {
               Pko =
               {
                  Pkp = 
                  {
                     Ms = 13012.0756989220m,
                     Ks = 12069.4865639254m,
                  },
                  Uvtp = 19175.6077322726m,
               },
               Spo = 29877.0385938227m,
            },
            QcRcGsuf = 5488.5469273737m,
            ConsumptionCb =
            {
               Cb1 = 155489.7759624722m,
               Cb2 = 152834.9430035578m,
               Cb3 = 113395.6054624054m,
               Cb4 = 122950.6159980599m,
            },
            ConsumptionCpsPpk =
            {
               Pko = { Total = 39831.4529956080m },
               Spo = 26889.3347344404m,
            },
            ConsumptionKc2Sum = 544670.9404264953m,
            PkoQcRcSum = 44257.1699951200m,
            ConsumptionCpsPpkSum = 66720.7877300484m,
            ConsumptionGsuf = 4939.6922346363m,
            ConsumptionMkSum = 611391.7281565437m,
            ConsumptionMkGsufSum = 616331.4203911800m,
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
