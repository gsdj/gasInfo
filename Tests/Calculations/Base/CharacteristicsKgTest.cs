using Business.BusinessModels.BaseCalculations;
using Business.Interfaces.BaseCalculations;
using DataAccess.Entities.Characteristics;
using Xunit;

namespace Tests.Calculations.Base
{
   public class CharacteristicsKgTest
   {
      private IDensity<KG> GetTestDensityObject()
      {
         return new DefaultDensityKg();
      }
      private IQn<KG> GetTestQnObject()
      {
         return new DefaultQnKg();
      }
      private KG GetDataForTest()
      {
         return new KG
         {
            CO2 = 2.4m,
            O2 = 1.4m,
            CO = 7.6m,
            CnHm = 1.7m,
            CH4 = 21.5m,
            H2 = 59.6m,
            N2 = 5.8m,
         };
      }
      [Fact]
      public void Density()
      {
         IDensity<KG> target = GetTestDensityObject();

         var kg = GetDataForTest();

         decimal expected = 0.4333697m;
         var actual = target.Calc(kg);
         Assert.Equal(expected, actual);
      }
      [Fact]
      public void Qn()
      {
         IQn<KG> target = GetTestQnObject();

         var kg = GetDataForTest();

         decimal expected = 3604.69m;
         var actual = target.Calc(kg);
         Assert.Equal(expected, actual);
      }
   }
}
