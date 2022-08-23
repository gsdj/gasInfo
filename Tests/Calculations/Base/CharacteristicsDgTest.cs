using BLL.Calculations.Base;
using BLL.Calculations.Base.Density;
using BLL.Calculations.Base.Qn;
using BLL.Interfaces.BaseCalculations;
using BLL.Interfaces.BaseCalculations.Density;
using BLL.Models.BaseModels.Components;
using DA.Entities;
using DA.Entities.Characteristics;
using Moq;
using Xunit;

namespace Tests.Calculations.Base
{
   public class CharacteristicsDgTest
   {
      private Mock<IAvgComponents<CharacteristicsDgAll, GasComponents>> MockAvgComponents;
      private CharacteristicsDgAll DgAll;
      public CharacteristicsDgTest()
      {
         DgAll = TestDbDataHelper.CharacteristicsDgAllData();

         MockAvgComponents = new Mock<IAvgComponents<CharacteristicsDgAll, GasComponents>>();

         MockAvgComponents.Setup(p => p.Calc(It.IsAny<CharacteristicsDgAll>()))
            .Returns((CharacteristicsDgAll data) => new AvgDgComponents().Calc(data));
      }
      [Fact]
      public void DefaultDensityDg()
      {
         var MockDensity = new Mock<IDensity<DG>>();

         MockDensity.Setup(x => x.Calc(It.IsAny<DG>()))
            .Returns((DG data) => new DefaultDensityDg().Calc(data));

         decimal expected = 1.21863270m;
         var actual = MockDensity.Object.Calc(DgAll.Kc1);

         Assert.Equal(expected, actual);
      }
      [Fact]
      public void DefaultQnDg()
      {
         var MockQn = new Mock<IQn<DG>>();

         MockQn.Setup(x => x.Calc(It.IsAny<DG>()))
            .Returns((DG data) => new DefaultQnDg().Calc(data));

         decimal expected = 718.1200m;
         var actual = MockQn.Object.Calc(DgAll.Kc1);

         Assert.Equal(expected, actual);
      }
      [Fact]
      public void AvgDensityDg()
      {
         var mockDensityAvg = new Mock<IDensity<CharacteristicsDgAll>>();

         mockDensityAvg.Setup(p => p.Calc(It.IsAny<CharacteristicsDgAll>()))
            .Returns((CharacteristicsDgAll data) => new AVGDensityDg(MockAvgComponents.Object).Calc(data));

         var result = mockDensityAvg.Object.Calc(DgAll);

         decimal expected = 1.2188838000m;
         Assert.Equal(expected, result);
      }
      [Fact]
      public void AvgQnDg()
      {
         var mockQnAvg = new Mock<IQn<CharacteristicsDgAll>>();

         mockQnAvg.Setup(p => p.Calc(It.IsAny<CharacteristicsDgAll>()))
            .Returns((CharacteristicsDgAll data) => new AVGQnDg(MockAvgComponents.Object).Calc(data));

         var result = mockQnAvg.Object.Calc(DgAll);

         decimal expected = 742.030000m;

         Assert.Equal(expected, result);
      }
   }
}
