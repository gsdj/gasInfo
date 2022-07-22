using Business.BusinessModels.BaseCalculations;
using Business.BusinessModels.BaseCalculations.Qn;
using Business.Interfaces;
using Business.Interfaces.BaseCalculations;
using Business.Interfaces.BaseCalculations.Consumption;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
   public static class SetupHelper
   {
      public static Mock<ISteamCharacteristicsService> SteamSetup()
      {
         var MockSteam = new Mock<ISteamCharacteristicsService>();
         MockSteam.Setup(p => p.GetCharacteristics()).Returns(TestDataHelper.SteamCharacteristicsData());
         return MockSteam;
      }
      public static Mock<IQcRc> QcRcSetup()
      {
         var steam = SteamSetup().Object;
         var MockQcRc = new Mock<IQcRc>();
         MockQcRc.SetupProperty(p => p.SteamCharacteristicsService, steam);

         var defQcRc = new DefaultQcRc(steam);

         MockQcRc.Setup(p => p.Calc(It.IsAny<decimal>(), It.IsAny<decimal>(), It.IsAny<decimal>(), It.IsAny<decimal>(), It.Is<bool>(p => p)))
            .Returns((decimal cons, decimal wetGas, decimal temp, decimal density, bool perHour) =>
            defQcRc.Calc(cons, wetGas, temp, density, true));

         MockQcRc.Setup(p => p.Calc(It.IsAny<decimal>(), It.IsAny<decimal>(), It.IsAny<decimal>(), It.IsAny<decimal>(), It.Is<bool>(p => !p)))
            .Returns((decimal cons, decimal wetGas, decimal temp, decimal density, bool perHour) =>
            defQcRc.Calc(cons, wetGas, temp, density, false));

         return MockQcRc;
      }
      public static Mock<IConsGasQn<ConsGasQn1000>> Qn1000Setup()
      {
         var MockConsGasQn1000 = new Mock<IConsGasQn<ConsGasQn1000>>();

         var consGas1000 = new ConsGasQn1000();

         MockConsGasQn1000.Setup(p => p.Calc(It.IsAny<decimal>(), It.IsAny<decimal>()))
            .Returns((decimal qcrc, decimal qn) =>
            consGas1000.Calc(qcrc, qn));

         return MockConsGasQn1000;
      }
      public static Mock<IConsGasQn<ConsGasQn4000>> Qn4000Setup()
      {
         var MockConsGasQn4000 = new Mock<IConsGasQn<ConsGasQn4000>>();

         var consGas4000 = new ConsGasQn4000();

         MockConsGasQn4000.Setup(p => p.Calc(It.IsAny<decimal>(), It.IsAny<decimal>()))
            .Returns((decimal qcrc, decimal qn) =>
            consGas4000.Calc(qcrc, qn));

         return MockConsGasQn4000;
      }

   }
}
