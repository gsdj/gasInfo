using Business.BusinessModels.BaseCalculations.Density;
using Business.BusinessModels.BaseCalculations.Qn;
using Business.BusinessModels.Calculations.Characteristics;
using Business.DTO.Models.Characteristics.Gas;
using Business.Interfaces.BaseCalculations;
using Business.Interfaces.BaseCalculations.Density;
using Business.Interfaces.Calculations.Characteristics;
using DataAccess.Entities.Characteristics;
using Moq;
using Newtonsoft.Json;
using System;
using Xunit;

namespace Tests.Calculations.Entities
{
   public class CharacteristicsKgTest
   {
      private Mock<IQn<KG>> Qn;
      private Mock<IDensity<KG>> Density;
      private ICalcCharacteristicsKg Target;
      public CharacteristicsKgTest()
      {
         Qn = new Mock<IQn<KG>>();
         Qn.Setup(p => p.Calc(It.IsAny<KG>()))
            .Returns((KG data) => new DefaultQnKg().Calc(data));

         Density = new Mock<IDensity<KG>>();
         Density.Setup(p => p.Calc(It.IsAny<KG>()))
            .Returns((KG data) => new DefaultDensityKg().Calc(data));

         Target = new CalcCharacteristicsKG(Qn.Object, Density.Object);
      }
      private CharacteristicsKG ExpectedObject()
      {
         return new CharacteristicsKG
         {
            Date = new DateTime(2019, 1, 1),
            Kc1 =
            {
               Density = 0.4490720m,
               Qn = 3600.400m,
            },
            Kc2 =
            {
               Density = 0.4220939m,
               Qn = 3808.170m,
            },
         };
      }
      [Fact]
      public void CharacteristicsKG()
      {
         var expected = JsonConvert.SerializeObject(ExpectedObject());

         var result = JsonConvert.SerializeObject(Target.CalcEntity(TestDbDataHelper.CharacteristicsKgAllData()));

         Assert.Equal(expected, result);
      }
   }
}
