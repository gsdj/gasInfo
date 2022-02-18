using Business.BusinessModels.Calculations;
using Business.Interfaces.Calculations;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Tests.Calculations
{
   public class CharacteristicksKg
   {
      Mock<ICalcCharacteristicsKg> _Kg;
      public CharacteristicksKg()
      {
         _Kg = new Mock<ICalcCharacteristicsKg>();
      }
      [Fact]
      public void Density()
      {
         decimal CO2 = 2.4m;
         decimal O2 = 1.4m;
         decimal CO = 7.6m;
         decimal CnHm = 1.7m;
         decimal CH4 = 21.5m;
         decimal H2 = 59.6m;
         decimal N2 = 5.8m;
         decimal expected = 0.4333697m;
         _Kg.Setup(x => x.Density(CO2, O2, CO, CnHm, CH4, H2, N2)).Returns(expected);
         var actual = _Kg.Object.Density(CO2, O2, CO, CnHm, CH4, H2, N2);
         Assert.Equal(expected, actual);
      }
      [Fact]
      public void Qn()
      {
         CalcCharacteristicsKG kg = new CalcCharacteristicsKG();
         decimal CO = 7.6m;
         decimal CnHm = 1.7m;
         decimal CH4 = 21.5m;
         decimal H2 = 59.6m;
         decimal expected = 3604.69m;
         decimal act = kg.Qn(CO, CnHm, CH4, H2);
         Assert.Equal(expected, act);
      }
   }
}
