using BLL.Calculations.Base;
using BLL.Calculations.Base.Consumption;
using BLL.Calculations.Entities;
using BLL.Calculations.Entities.Production;
using BLL.DTO;
using BLL.Interfaces.BaseCalculations;
using BLL.Interfaces.BaseCalculations.Consumption;
using BLL.Interfaces.Calculations;
using BLL.Interfaces.Calculations.Production;
using BLL.Models.BaseModels.Production;
using Newtonsoft.Json;
using System;
using Xunit;

namespace Tests.Calculations.Entities
{
   public class ProductionTest
   {
      private ICalcProduction GetTestObject()
      {
         IDryCokeProduction<DefaultDryCokeProduction> dryCoke = new DefaultDryCokeProduction();
         IChargeConsFV<DefaultChargeConsFV> consFv = new DefaultChargeConsFV(new DefaultDryCokeProduction());
         ISpoPerKus<DefaultSpoPerKus> perKus = new DefaultSpoPerKus();

         ICokeCbGrossCalc GrossCalc = new CokeCbGrossCalc();
         ICokeCbDryCalc DryCalc = new CokeCbDryCalc(dryCoke);
         ICokeCbConsumptionDryCalc ConsumptionDryCalc = new CokeCbConsumptionDryCalc(dryCoke);
         ICokeCbConsumptionFvCalc ConsumptionFvCalc = new CokeCbConsumptionFvCalc(consFv);

         return new DefaultProduction(perKus, GrossCalc, DryCalc, ConsumptionDryCalc, ConsumptionFvCalc);
      }
      [Fact]
      public void Production()
      {
         var target = GetTestObject();

         ProductionDTO expectedResult = new ProductionDTO
         {
            Date = new DateTime(2019, 1, 1),
            AmmountCb = new Cb<int>
            {
               Cb1 = 78,
               Cb2 = 84,
               Cb3 = 0,
               Cb4 = 80,
               Cb5 = 48,
               Cb6 = 48,
               Cb7 = 47,
               Cb8 = 53,
               PKP = 12,
            },
            CokeCbGross =
            {
               Kc1 =
               {
                  Cb1 = 814.32m,
                  Cb2 = 1073.52m,
                  Cb3 = 0,
                  Cb4 = 1024.80m,
               },
               Kc2 =
               {
                  Cb1 = 639.84m,
                  Cb2 = 639.84m,
                  Cb3 = 626.51m,
                  Cb4 = 703.84m,
               },
            },
            CokeCbDry =
            {
               Kc1 =
               {
                  Cb1 = 765.4608m,
                  Cb2 = 1009.1088m,
                  Cb3 = 0.00m,
                  Cb4 = 963.3120m,
               },
               Kc2 =
               {
                  Cb1 = 601.4496m,
                  Cb2 = 601.4496m,
                  Cb3 = 588.9194m,
                  Cb4 = 661.6096m,
               },
               KpeDry = 83.28m,
            },
            //Cb16Val = 4192.32m,
            //Cb78Val = 1330.35m,
            //Cb16Dry = 3940.7808m,
            //Cb78Dry = 1250.5290m,
            //TnDry = 5191.3098m,
            //KpeDry = 83.28m,
            CokeCbConsumptionDry =
            {
               Kc1 =
               {
                  Cb1 = 975.1970592m,
                  Cb2 = 1285.6046112m,
                  Cb3 = 0.00000m,
                  Cb4 = 1227.2594880m,
               },
               Kc2 =
               {
                  Cb1 = 766.2467904m,
                  Cb2 = 766.2467904m,
                  Cb3 = 750.2833156m,
                  Cb4 = 842.8906304m,
               },
            },
            //Cb16ConsDry = 5020.5547m,
            //Cb78ConsDry = 1593.1739m,
            //TnConsDry = 6613.7287m,
            CokeCbConsumptionFv =
            {
               Kc1 =
               {
                  Cb1 = 1052.5086000m,
                  Cb2 = 1387.5246000m,
                  Cb3 = 0.00000m,
                  Cb4 = 1324.5540000m,
               },
               Kc2 =
               {
                  Cb1 = 826.9932000m,
                  Cb2 = 826.9932000m,
                  Cb3 = 809.7641750m,
                  Cb4 = 909.7132000m,
               },
            },
            PkoKpe = 4.2m,
            SpoPerKus = 24.3494857143m,
            SvC = 1.274m,
            FvC = 1.375m,
            KpeC = 420,
         };

         var expected = JsonConvert.SerializeObject(expectedResult);
         var result = JsonConvert.SerializeObject(target.CalcEntity(TestDbDataHelper.AmmountCbData()));

         Assert.Equal(expected, result);
      }
   }
}
