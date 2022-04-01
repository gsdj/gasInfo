using Business.BusinessModels.DataForCalculations;
using Business.DTO.QcRc;
using Business.Interfaces.BaseCalculations;
using Business.Interfaces.Calculations;

namespace Business.BusinessModels.Calculations
{
   public class CalcQcRcKc2 : ICalcQcRc<QcRcKc2>
   {
      private IQcRc QcRc;
      public CalcQcRcKc2(IQcRc qcrc)
      {
         QcRc = qcrc;
      }

      public QcRcKc2 Calc(QcRcData data)
      {
         QcRcKgData Data = data as QcRcKgData;
         var kip = Data.Kip;
         var charKg = Data.CharacteristicsKg;
         var wetGas = Data.WetGas;

         return new QcRcKc2
         {
            Cb5 = QcRc.Calc(kip.Cb5.Consumption, wetGas.Cb5, kip.Cb5.TempBeforeHeating, charKg.Kc1.Characteristics.Density, true),
            Cb6 = QcRc.Calc(kip.Cb6.Consumption, wetGas.Cb6, kip.Cb6.TempBeforeHeating, charKg.Kc1.Characteristics.Density, true),
            Cb7 =
               {
                  Ms = QcRc.Calc(kip.Cb7.ConsumptionMs, wetGas.Cb7, kip.Cb7.TempBeforeHeating, charKg.Kc2.Characteristics.Density),
                  Ks = QcRc.Calc(kip.Cb7.ConsumptionKs, wetGas.Cb7, kip.Cb7.TempBeforeHeating, charKg.Kc2.Characteristics.Density),
               },
            Cb8 =
               {
                  Ms = QcRc.Calc(kip.Cb8.ConsumptionMs, wetGas.Cb8, kip.Cb8.TempBeforeHeating, charKg.Kc2.Characteristics.Density),
                  Ks = QcRc.Calc(kip.Cb8.ConsumptionKs, wetGas.Cb8, kip.Cb8.TempBeforeHeating, charKg.Kc2.Characteristics.Density),
               },
         };
      }
   }
}
