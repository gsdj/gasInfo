using Business.BusinessModels.BaseCalculations;
using Business.DTO.Characteristics.CharacteristicsGas;
using Business.Interfaces.BaseCalculations;
using DataAccess.Entities;
using DataAccess.Entities.Characteristics;
using Moq;
using Newtonsoft.Json;
using System;
using Xunit;

namespace Tests.Calculations.Base
{
   public class CharacteristicsDgTest
   {
      private IDensity<DG> GetTestDensityObject()
      {
         return new DefaultDensityDg();
      }
      private IQn<DG> GetTestQnObject()
      {
         return new DefaultQnDg();
      }
      private CharacteristicsDgAll GetDgAllForTest()
      {
         return new CharacteristicsDgAll
         {
            Kc1 = new DG
            {
               CO2 = 16.8m,
               CO = 24.6m,
               H2 = 9.6m,
               N2 = 48.6m,
            },
            Kc2 = new DG
            {
               CO2 = 16.3m,
               CO = 24.9m,
               H2 = 10.1m,
               N2 = 48.1m,
            }
         };
      }
      [Fact]
      public void Density()
      {
         IDensity<DG> target = GetTestDensityObject();

         var dg = GetDgAllForTest();

         decimal kc1 = 1.1707572m;
         decimal kc2 = 1.1596307m;

         var actual1 = target.Calc(dg.Kc1);
         var actual2 = target.Calc(dg.Kc2);

         Assert.Equal(kc1, actual1);
         Assert.Equal(kc2, actual2);
      }
      [Fact]
      public void Qn()
      {
         IQn<DG> target = GetTestQnObject();

         var dg = GetDgAllForTest();

         decimal kc1 = 921.66m;
         decimal kc2 = 942.09m;

         var actual1 = target.Calc(dg.Kc1);
         var actual2 = target.Calc(dg.Kc2);

         Assert.Equal(kc1, actual1);
         Assert.Equal(kc2, actual2);
      }
   }
}
