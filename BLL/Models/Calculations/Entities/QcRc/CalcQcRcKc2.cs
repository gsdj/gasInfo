using BLL.DataHelpers;
using BLL.Interfaces.BaseCalculations;
using BLL.Interfaces.Calculations;
using BLL.Models.BaseModels.QcRc;

namespace BLL.Calculations.Entities.QcRc
{
   public class CalcQcRcKc2 : ICalcQcRc<QcRcKc2>
   {
      public IQcRc QcRc { get; private set; }
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
            Cb1 =
               {
                  Value = QcRc.Calc(kip.Kc2.Cb1.Consumption.Value, wetGas.Kc2.Cb1, kip.Kc2.Cb1.TempBeforeHeating, charKg.Kc1.Density, true),
               },
            Cb2 =
               {
                  Value = QcRc.Calc(kip.Kc2.Cb2.Consumption.Value, wetGas.Kc2.Cb2, kip.Kc2.Cb2.TempBeforeHeating, charKg.Kc1.Density, true),
               },
            Cb3 =
               {
                  Ms = QcRc.Calc(kip.Kc2.Cb3.Consumption.Ms, wetGas.Kc2.Cb3, kip.Kc2.Cb3.TempBeforeHeating, charKg.Kc2.Density),
                  Ks = QcRc.Calc(kip.Kc2.Cb3.Consumption.Ks, wetGas.Kc2.Cb3, kip.Kc2.Cb3.TempBeforeHeating, charKg.Kc2.Density),
               },
            Cb4 =
               {
                  Ms = QcRc.Calc(kip.Kc2.Cb4.Consumption.Ms, wetGas.Kc2.Cb4, kip.Kc2.Cb4.TempBeforeHeating, charKg.Kc2.Density),
                  Ks = QcRc.Calc(kip.Kc2.Cb4.Consumption.Ks, wetGas.Kc2.Cb4, kip.Kc2.Cb4.TempBeforeHeating, charKg.Kc2.Density),
               },
         };
      }
   }
}
