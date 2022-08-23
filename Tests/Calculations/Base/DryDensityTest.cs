using BLL.Calculations.Base.Density;
using BLL.DTO;
using BLL.Interfaces.Services;
using Business.Interfaces.BaseCalculations.Density;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace Tests.Calculations.Base
{
   public class DryDensityTest
   {
      private Dictionary<int, SteamCharacteristicsDTO> GetData()
      {
         var st1 = new SteamCharacteristicsDTO
         {
            Temp = 31,
            Pmm = 33.700m,
            Pgm = 32.000m,
            Ptopp = 32.100m,
            Fkg = 0.0321m,
            PPa = 4492.9648m,
            PKg = 0.032m,
            Rh = 1.0031m,
         };
         var st2 = new SteamCharacteristicsDTO
         {
            Temp = 61,
            Pmm = 156.500m,
            Pgm = 135.200m,
            Ptopp = 135.900m,
            Fkg = 0.1359m,
            PPa = 20864.9556m,
            PKg = 0.1352m,
            Rh = 1.0051m,
         };
         var st3 = new SteamCharacteristicsDTO
         {
            Temp = 26,
            Pmm = 25.210m,
            Pgm = 24.300m,
            Ptopp = 24.400m,
            Fkg = 0.0244m,
            PPa = 3361.0577m,
            PKg = 0.0243m,
            Rh = 1.0041m,
         };

         var stDict = new Dictionary<int, SteamCharacteristicsDTO>();
         stDict.Add(st1.Temp, st1);
         stDict.Add(st2.Temp, st2);
         stDict.Add(st3.Temp, st3);
         return stDict;
      }
      //CU2
      [Fact]
      public void DryDensity()
      {
         var mock = new Mock<ISteamCharacteristicsService>();

         var mockResult = TestCalculatedDataHelper.SteamCharacteristicsData();

         mock.Setup(p => p.GetCharacteristics()).Returns(mockResult);

         IDryDensity target = new DryDensity(mock.Object);

         decimal pkg = 0.418m;
         decimal Ppa = 100258;
         decimal p = 744;
         decimal temp = 31;

         decimal expected = 0.4097310713m;
         Assert.Equal(expected, target.Calc(pkg, Ppa, p, temp));
      }
      //Cb5
      [Fact]
      public void DryDensityWithTempBefore()
      {
         var mock = new Mock<ISteamCharacteristicsService>();

         var mockResult = GetData();

         mock.Setup(p => p.GetCharacteristics()).Returns(mockResult);

         IDryDensity target = new DryDensity(mock.Object);

         decimal pkg = 0.449m;
         decimal Ppa = 100258;
         decimal p = 391;
         decimal temp = 61;
         decimal tempDo = 26;

         decimal expected = 0.3232207975m;
         Assert.Equal(expected, target.Calc(pkg, Ppa, p, temp, tempDo));
      }
   }
}
