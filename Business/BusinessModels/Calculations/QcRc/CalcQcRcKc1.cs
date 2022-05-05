using Business.BusinessModels.DataForCalculations;
using Business.DTO.QcRc;
using Business.Interfaces.BaseCalculations;
using Business.Interfaces.Calculations;

namespace Business.BusinessModels.Calculations.QcRc
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
            //Cb1 = QcRc.Calc(kip.Cb1.Consumption, wetGas.Cb1, kip.Cb1.Temperature, charDg.CharacteristicsAVG.Density),
            Cb1 =
            {
               Value = QcRc.Calc(kip.Kc1.Cb1.Consumption.Value, wetGas.Kc1.Cb1, kip.Kc1.Cb1.Temperature, charDg.CharacteristicsAVG.Density),
            },
            Cb2 =
            {
               Value = QcRc.Calc(kip.Kc1.Cb2.Consumption.Value, wetGas.Kc1.Cb2, kip.Kc1.Cb2.Temperature, charDg.CharacteristicsAVG.Density),
            },
            Cb3 =
            {
               Value = QcRc.Calc(kip.Kc1.Cb3.Consumption.Value, wetGas.Kc1.Cb3, kip.Kc1.Cb3.Temperature, charDg.CharacteristicsAVG.Density),
            },
            Cb4 =
            {
               Value = QcRc.Calc(kip.Kc1.Cb4.Consumption.Value, wetGas.Kc1.Cb4, kip.Kc1.Cb4.Temperature, charDg.CharacteristicsAVG.Density),
            },
            //Cb2 = QcRc.Calc(kip.Cb2.Consumption, wetGas.Cb2, kip.Cb2.Temperature, charDg.CharacteristicsAVG.Density),
            //Cb3 = QcRc.Calc(kip.Cb3.Consumption, wetGas.Cb3, kip.Cb3.Temperature, charDg.CharacteristicsAVG.Density),
            //Cb4 = QcRc.Calc(kip.Cb4.Consumption, wetGas.Cb4, kip.Cb4.Temperature, charDg.CharacteristicsAVG.Density),
         };
      }
   }
}
