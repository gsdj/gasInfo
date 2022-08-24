using BLL.DataHelpers;
using BLL.Interfaces.BaseCalculations;
using BLL.Interfaces.Calculations;
using BLL.Models.BaseModels.QcRc;

namespace BLL.Calculations.Entities.QcRc
{
   public class CalcQcRcKc1 : ICalcQcRc<QcRcKc1>
   {
      public IQcRc QcRc { get; private set; }
      public CalcQcRcKc1(IQcRc qcrc)
      {
         QcRc = qcrc;
      }

      public QcRcKc1 Calc(QcRcData data)
      {
         QcRcDgData Data = data as QcRcDgData;
         var kip = Data.Kip;
         var charDg = Data.CharacteristicsDg;
         var wetGas = data.WetGas;

         return new QcRcKc1
         {
            Cb1 =
            {
               Value = QcRc.Calc(kip.Kc1.Cb1.Consumption.Value, wetGas.Kc1.Cb1, kip.Kc1.Cb1.Temperature, charDg.AVG.Density),
            },
            Cb2 =
            {
               Value = QcRc.Calc(kip.Kc1.Cb2.Consumption.Value, wetGas.Kc1.Cb2, kip.Kc1.Cb2.Temperature, charDg.AVG.Density),
            },
            Cb3 =
            {
               Value = QcRc.Calc(kip.Kc1.Cb3.Consumption.Value, wetGas.Kc1.Cb3, kip.Kc1.Cb3.Temperature, charDg.AVG.Density),
            },
            Cb4 =
            {
               Value = QcRc.Calc(kip.Kc1.Cb4.Consumption.Value, wetGas.Kc1.Cb4, kip.Kc1.Cb4.Temperature, charDg.AVG.Density),
            },
         };
      }
   }
}
