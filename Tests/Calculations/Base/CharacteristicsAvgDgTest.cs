using Business.BusinessModels.BaseCalculations;
using Business.BusinessModels.BaseCalculations.Density;
using Business.BusinessModels.BaseCalculations.Qn;
using Business.DTO.Characteristics.CharacteristicsGas;
using Business.Interfaces.BaseCalculations;
using Business.Interfaces.BaseCalculations.Density;
using DataAccess.Entities;
using DataAccess.Entities.Characteristics;
using Moq;
using Newtonsoft.Json;
using System;
using Xunit;

namespace Tests.Calculations.Base
{
   public class CharacteristicsAvgDgTest
   {
      private IAvgComponents<CharacteristicsDgAll, GasComponents> GetTestComponentsAvgObject()
      {
         return new AvgDgComponents();
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
      public void DensityAVG()
      {
         var mock = new Mock<IAvgComponents<CharacteristicsDgAll, GasComponents>>();

         var mockResult = new GasComponents
         {
            CO2 = 16.465m,
            CO = 24.801m,
            H2 = 9.935m,
            N2 = 48.265m,
         };

         mock.Setup(p => p.Calc(It.IsAny<CharacteristicsDgAll>())).Returns(mockResult);

         IDensity<CharacteristicsDgAll> target = new AVGDensityDg(mock.Object);

         var dg = GetDgAllForTest();

         decimal expected = 1.163749403m;
         var actual = target.Calc(dg);
         Assert.Equal(expected, actual);
      }
      [Fact]
      public void QnAVG()
      {
         var mock = new Mock<IAvgComponents<CharacteristicsDgAll, GasComponents>>();

         var mockResult = new GasComponents
         {
            CO2 = 16.465m,
            CO = 24.801m,
            H2 = 9.935m,
            N2 = 48.265m,
         };

         mock.Setup(p => p.Calc(It.IsAny<CharacteristicsDgAll>())).Returns(mockResult);

         IQn<CharacteristicsDgAll> target = new AVGQnDg(mock.Object);

         var dg = GetDgAllForTest();

         decimal expected = 977.90790m;
         var actual = target.Calc(dg);

         Assert.Equal(expected, actual);
      }
      [Fact]
      public void ComponentsAVG()
      {
         IAvgComponents<CharacteristicsDgAll, GasComponents> target = GetTestComponentsAvgObject();

         var dg = GetDgAllForTest();

         var expected = new GasComponents
         {
            CO2 = 16.465m,
            CO = 24.801m,
            H2 = 9.935m,
            N2 = 48.265m,
         };

         var actual = target.Calc(dg);

         var expectedStr = JsonConvert.SerializeObject(expected);
         var actualStr = JsonConvert.SerializeObject(actual);

         Assert.Equal(expectedStr, actualStr);
      }
   }
}
