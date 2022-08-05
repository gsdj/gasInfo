using Business.BusinessModels.BaseCalculations;
using Business.BusinessModels.Calculations.QcRc;
using Business.BusinessModels.DataForCalculations;
using Business.DTO.Models.QcRc;
using Business.Interfaces;
using Business.Interfaces.BaseCalculations;
using Business.Interfaces.Calculations;
using Moq;
using Newtonsoft.Json;
using Xunit;

namespace Tests.Calculations.Entities.QcRc
{
   public class CpsPpk
   {
      private Mock<IQcRc> MockQcRc;
      private Mock<ICalcQcRc<CpsPpkQcRc>> Target;
      public CpsPpk()
      {
         MockQcRc = SetupHelper.DefaultQcRcSetup();
         QcRcCpsPpkSetup();
      }
      private void QcRcCpsPpkSetup()
      {
         Target = new Mock<ICalcQcRc<CpsPpkQcRc>>();

         var qcrcKc1Calc = new CalcQcRcCpsPpk(MockQcRc.Object);

         Target.Setup(p => p.Calc(It.IsAny<QcRcData>()))
            .Returns((QcRcData data) =>
            qcrcKc1Calc.Calc(data));
      }
      private CpsPpkQcRc ExpectedObject()
      {
         return new CpsPpkQcRc
         {
            Pko =
            {
               Pkp =
               {
                  Ms = 13012.0756989220m,
                  Ks = 12069.4865639254m,
                  Value = 0.0m,
               },
               Uvtp = 19175.6077322726m,
            },
            Spo = 29877.0385938227m,
         };
      }

      [Fact]
      public void QcRcCpsPpkDefault()
      {
         var Data = new QcRcKgData
         {
            CharacteristicsKg = TestCalculatedDataHelper.CharacteristicsKgData(),
            Kip = TestCalculatedDataHelper.DevicesKipData(),
            WetGas = TestCalculatedDataHelper.DensityDTOData(),
         };

         var expected = JsonConvert.SerializeObject(ExpectedObject());

         var result = JsonConvert.SerializeObject(Target.Object.Calc(Data));

         Assert.Equal(expected, result);
      }
   }
}
