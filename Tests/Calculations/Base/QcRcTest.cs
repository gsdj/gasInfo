using Business.BusinessModels.BaseCalculations;
using Business.DTO.QcRc;
using Business.Interfaces;
using Business.Interfaces.BaseCalculations;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Tests.Calculations.Base
{
   public class QcRcTest
   {
      private Mock<ISteamCharacteristicsService> MockSteam;
      private IQcRc QcRc;
      public QcRcTest()
      {
         MockSteam = new Mock<ISteamCharacteristicsService>();
         MockSteam.Setup(p => p.GetCharacteristics()).Returns(TestHelper.SteamCharacteristicsData());

         QcRc = new DefaultQcRc(MockSteam.Object);
      }
      //Cb5
      [Fact]
      public void QcRcPerHour()
      {
         decimal cons = 7435;
         decimal wetGas = 0.459123837535828m;
         decimal temp = 26;
         decimal densityKg = 0.449m;

         var result = QcRc.Calc(cons, wetGas, temp, densityKg, true);

         decimal expected = 172766.4177503188m;

         Assert.Equal(expected, result);
      }
      //Spo
      [Fact]
      public void QcRcDefault()
      {
         decimal cons = 29001;
         decimal wetGas = 0.478963026366234m;
         decimal temp = 19;
         decimal densityKg = 0.449m;

         var result = QcRc.Calc(cons, wetGas, temp, densityKg);

         decimal expected = 29877.0385916418m;

         Assert.Equal(expected, result);
      }
      //Cb7
      [Fact]
      public void QcRcWithMsKs()
      {
         decimal consMs = 2542;
         decimal consKs = 2539;
         decimal wetGas = 0.440395995998558m;
         decimal temp = 31;
         decimal densityKg = 0.418m;

         var ms = QcRc.Calc(consMs, wetGas, temp, densityKg);
         var ks = QcRc.Calc(consKs, wetGas, temp, densityKg);

         var result = new QcRcMsKsDefault
         {
            Ms = ms,
            Ks = ks,
         }.Value;

         decimal expected = 119113.0309474824m;

         Assert.Equal(expected, result);
      }
   }
}
