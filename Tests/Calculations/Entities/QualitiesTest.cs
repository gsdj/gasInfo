using BLL.Calculations.Base.Density;
using BLL.Calculations.Entities;
using BLL.Interfaces.BaseCalculations.Density;
using BLL.Interfaces.Calculations;
using BLL.Models.BaseModels.Characteristics.Quality;
using DA.Entities.Characteristics;
using Moq;
using Newtonsoft.Json;
using System;
using Xunit;

namespace Tests.Calculations.Entities
{
   public class QualitiesTest
   {
      private Mock<IDensity<KG>> Density;
      private ICalcQuality Target;
      public QualitiesTest()
      {
         Density = new Mock<IDensity<KG>>();
         Density.Setup(p => p.Calc(It.IsAny<KG>()))
            .Returns((KG data) => new DefaultDensityKg().Calc(data));

         Target = new DefaultQualities(Density.Object);
      }
      private QualityCharacteristics ExpectedObject()
      {
         return new QualityCharacteristics
         {
            Date = new DateTime(2019, 1, 1),
            Kc1 =
            {
               Vc = 25.9233m,
               KgFv = 14.7391082356m,
               KgFh = 0.3282125859m,
               Density = 0.4490720m,
            },
            Kc2 =
            {
               Vc = 25.7114m,
               KgFv = 14.6787450558m,
               KgFh = 0.3477601798m,
               Density = 0.4220939m,
            },
         };
      }
      [Fact]
      public void Qualities()
      {
         var expected = JsonConvert.SerializeObject(ExpectedObject());

         var result = JsonConvert.SerializeObject(Target.CalcEntity(TestDbDataHelper.QualityAllData(), TestDbDataHelper.CharacteristicsKgAllData()));

         Assert.Equal(expected, result);
      }
   }
}
