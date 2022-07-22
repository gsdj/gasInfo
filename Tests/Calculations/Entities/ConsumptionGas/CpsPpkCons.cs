using Business.BusinessModels.BaseCalculations;
using Business.BusinessModels.BaseCalculations.Qn;
using Business.BusinessModels.Calculations.ConsGasQn;
using Business.BusinessModels.Calculations.QcRc;
using Business.BusinessModels.DataForCalculations;
using Business.DTO.Models.General;
using Business.DTO.Models.QcRc;
using Business.Interfaces;
using Business.Interfaces.BaseCalculations;
using Business.Interfaces.BaseCalculations.Consumption;
using Business.Interfaces.Calculations;
using Business.Interfaces.Calculations.ConsGasQn;
using Moq;
using Newtonsoft.Json;
using Xunit;

namespace Tests.Calculations.Entities.ConsumptionGas
{
   public class CpsPpkCons
   {
      private Mock<IQcRc> MockQcRc;
      private Mock<IConsGasQn<ConsGasQn4000>> MockConsGasQn4000;
      private Mock<ICalcQcRc<CpsPpkQcRc>> MockQcRcCpsPpk;
      private Mock<ICalcConsGasQnCpsPpk> Target;
      public CpsPpkCons()
      {
         MockQcRc = SetupHelper.QcRcSetup();
         MockConsGasQn4000 = SetupHelper.Qn4000Setup();
         QcRcCpsPpkSetup();
         ConsQnCpsPpkSetup();
      }
      private void QcRcCpsPpkSetup()
      {
         MockQcRcCpsPpk = new Mock<ICalcQcRc<CpsPpkQcRc>>();

         var qcrcKc2Calc = new CalcQcRcCpsPpk(MockQcRc.Object);

         MockQcRcCpsPpk.Setup(p => p.Calc(It.IsAny<QcRcData>()))
            .Returns((QcRcData data) =>
            qcrcKc2Calc.Calc(data));
      }
      private void ConsQnCpsPpkSetup()
      {
         var consqnCpsPpk = new CalcConsQnCpsPpk(MockQcRcCpsPpk.Object, MockConsGasQn4000.Object);

         Target = new Mock<ICalcConsGasQnCpsPpk>();
         Target.Setup(p => p.Calc(It.IsAny<QcRcData>()))
            .Returns((QcRcData data) =>
            consqnCpsPpk.Calc(data));
      }
      private CpsPpk ExpectedObject()
      {
         return new CpsPpk
         {
            Pko =
            {
               Pkp = 22573.4060365627m,
               Uvtp = 17258.0469590453m,
            },
            Spo = 26889.3347344404m,
         };
      }

      [Fact]
      public void ConsGasCpsPpk()
      {
         var Data = new QcRcKgData
         {
            CharacteristicsKg = TestDataHelper.CharacteristicsKgData(),
            Kip = TestDataHelper.DevicesKipData(),
            WetGas = TestDataHelper.DensityDTOData(),
         };

         var expected = JsonConvert.SerializeObject(ExpectedObject());

         var result = JsonConvert.SerializeObject(Target.Object.Calc(Data));

         Assert.Equal(expected, result);
      }
   }
}
