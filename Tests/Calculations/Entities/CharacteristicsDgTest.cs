using Business.BusinessModels.BaseCalculations;
using Business.BusinessModels.BaseCalculations.Density;
using Business.BusinessModels.BaseCalculations.Qn;
using Business.BusinessModels.Calculations;
using Business.DTO.Models.Characteristics.Gas;
using Business.DTO.Models.Components;
using Business.Interfaces.BaseCalculations;
using Business.Interfaces.BaseCalculations.Density;
using Business.Interfaces.Calculations;
using DataAccess.Entities;
using DataAccess.Entities.Characteristics;
using Moq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Tests.Calculations.Entities
{
   public class CharacteristicsDgTest
   {
      private Mock<IQn<DG>> Qn;
      private Mock<IDensity<DG>> Density;
      private Mock<IQn<CharacteristicsDgAll>> QnAvg;
      private Mock<IDensity<CharacteristicsDgAll>> DensityAvg;
      private Mock<IAvgComponents<CharacteristicsDgAll, GasComponents>> AvgC;
      private ICalcCharacteristicsDg Target;
      public CharacteristicsDgTest()
      {
         Qn = new Mock<IQn<DG>>();
         Qn.Setup(p => p.Calc(It.IsAny<DG>()))
            .Returns((DG data) => new DefaultQnDg().Calc(data));

         Density = new Mock<IDensity<DG>>();
         Density.Setup(p => p.Calc(It.IsAny<DG>()))
            .Returns((DG data) => new DefaultDensityDg().Calc(data));

         AvgC = new Mock<IAvgComponents<CharacteristicsDgAll, GasComponents>>();
         AvgC.Setup(p => p.Calc(It.IsAny<CharacteristicsDgAll>()))
            .Returns((CharacteristicsDgAll data) => new AvgDgComponents().Calc(data));

         QnAvg = new Mock<IQn<CharacteristicsDgAll>>();
         QnAvg.Setup(p => p.Calc(It.IsAny<CharacteristicsDgAll>()))
            .Returns((CharacteristicsDgAll data) => new AVGQnDg(AvgC.Object).Calc(data));

         DensityAvg = new Mock<IDensity<CharacteristicsDgAll>>();
         DensityAvg.Setup(p => p.Calc(It.IsAny<CharacteristicsDgAll>()))
            .Returns((CharacteristicsDgAll data) => new AVGDensityDg(AvgC.Object).Calc(data));

         Target = new CalcCharacteristicsDG(Qn.Object, Density.Object, QnAvg.Object, DensityAvg.Object);
      }
      private CharacteristicsDG ExpectedObject()
      {
         return new CharacteristicsDG
         {
            Date = new DateTime(2019, 1, 1),
            Kc1 =
            {
               Density = 1.21863270m,
               Qn = 718.1200m,
            },
            Kc2 =
            {
               Density = 1.21863270m,
               Qn = 718.1200m,
            },
            AVG =
            {
               Density = 1.2188838000m,
               Qn = 742.030000m,
            },
         };
      }
      [Fact]
      public void CharacteristicsDG()
      {
         var expected = JsonConvert.SerializeObject(ExpectedObject());

         var result = JsonConvert.SerializeObject(Target.CalcEntity(TestDbDataHelper.CharacteristicsDgAllData()));

         Assert.Equal(expected, result);
      }
   }
}
