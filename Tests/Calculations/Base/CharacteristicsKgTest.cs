using BLL.Calculations.Base.Density;
using BLL.Calculations.Base.Qn;
using BLL.Interfaces.BaseCalculations;
using BLL.Interfaces.BaseCalculations.Density;
using DA.Entities;
using DA.Entities.Characteristics;
using Moq;
using Xunit;

namespace Tests.Calculations.Base
{
   public class CharacteristicsKgTest
   {
      private CharacteristicsKgAll KgAll;
      public CharacteristicsKgTest()
      {
         KgAll = TestDbDataHelper.CharacteristicsKgAllData();
      }
      [Fact]
      public void DefaultDensityKg()
      {
         var MockDensity = new Mock<IDensity<KG>>();

         MockDensity.Setup(x => x.Calc(It.IsAny<KG>()))
            .Returns((KG data) => new DefaultDensityKg().Calc(data));

         decimal expected = 0.4490720m;
         var actual = MockDensity.Object.Calc(KgAll.Kc1);

         Assert.Equal(expected, actual);
      }
      [Fact]
      public void DefaultQnKg()
      {
         var MockQn = new Mock<IQn<KG>>();

         MockQn.Setup(x => x.Calc(It.IsAny<KG>()))
            .Returns((KG data) => new DefaultQnKg().Calc(data));

         decimal expected = 3600.400m;
         var actual = MockQn.Object.Calc(KgAll.Kc1);

         Assert.Equal(expected, actual);
      }
   }
}
