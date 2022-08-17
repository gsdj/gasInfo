using Business.BusinessModels.Calculations.Characteristics;
using Business.DTO;
using Business.Interfaces.Calculations.Characteristics;
using Business.Interfaces.Services;
using Business.Services;
using DataAccess.Entities.Characteristics;
using DataAccess.Interfaces;
using Moq;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Tests.Calculations.Entities
{
   public class CharacteristicsSteamTest
   {
      private ICalcCharacteristicsSteam Calc;
      private ISteamCharacteristicsService Service;
      public CharacteristicsSteamTest()
      {
         Calc = new CalcCharacteristicsSteam();
      }
      private SteamCharacteristicsDTO ExpectedCalcObject()
      {
         return new SteamCharacteristicsDTO
         {
            Temp = 34,
            Pmm = 39.900m,
            Pgm = 37.600m,
            Ptopp = 37.700m,
            Fkg = 0.0377m,
            PPa = 5319.5637600m,
            PKg = 0.0376m,
            Rh = 1.0026595745m,
         };
      }
      private Dictionary<int, SteamCharacteristicsDTO> ExpectedServiceObject()
      {
         return TestCalculatedDataHelper.SteamCharacteristicsData();
      }
      [Fact]
      public void CalcCharacteristicsSteam()
      {
         var expected = JsonConvert.SerializeObject(ExpectedCalcObject());

         var result = JsonConvert.SerializeObject(Calc.CalcEntity(TestDbDataHelper.SteamCharacteristicsData().FirstOrDefault()));

         Assert.Equal(expected, result);
      }
      [Fact]
      public void ServiceCharacteristicsSteam()
      {
         var mockCalc = new Mock<ICalcCharacteristicsSteam>();

         var calcSteam = new CalcCharacteristicsSteam();

         mockCalc.Setup(p => p.CalcEntities(It.IsAny<IEnumerable<SteamCharacteristics>>()))
            .Returns((IEnumerable<SteamCharacteristics> dataList) => calcSteam.CalcEntities(dataList));

         mockCalc.Setup(p => p.CalcEntity(It.IsAny<SteamCharacteristics>()))
            .Returns((SteamCharacteristics data) => calcSteam.CalcEntity(data));

         var mockRepository = new Mock<ISteamRepository>();
         mockRepository.Setup(p => p.GetAllCharacteristics()).Returns(TestDbDataHelper.SteamCharacteristicsData());

         Service = new SteamCharacteristicsService(mockCalc.Object, mockRepository.Object);

         var expected = JsonConvert.SerializeObject(ExpectedServiceObject());

         var result = JsonConvert.SerializeObject(Service.GetCharacteristics());

         Assert.Equal(expected, result);
      }

   }
}
