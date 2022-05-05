using Business.BusinessModels.BaseCalculations.Qn;
using Business.Interfaces.BaseCalculations.Consumption;
using Xunit;

namespace Tests.Calculations.Base
{
   public class ConsGasQnTest
   {
      private IConsGasQn<ConsGasQn4000> CGQn4000;
      private IConsGasQn<ConsGasQn1000> CGQn1000;
      public ConsGasQnTest()
      {
         CGQn1000 = new ConsGasQn1000();
         CGQn4000 = new ConsGasQn4000();
      }
      //Cb5
      [Fact]
      public void ConsGasQn4000()
      {
         decimal qcrc = 172779.08m;
         decimal qnKg = 3600;

         decimal expected = 155501.172m;

         var result = CGQn4000.Calc(qcrc, qnKg);

         Assert.Equal(expected, result);
      }
      //Cb1
      [Fact]
      public void ConsGasQn1000()
      {
         decimal qcrc = 890817.61m;
         decimal qnDg = 742;

         decimal expected = 660986.66662m;

         var result = CGQn1000.Calc(qcrc, qnDg);

         Assert.Equal(expected, result);
      }
   }
}
