using Business.BusinessModels.DataForCalculations;
using Business.DTO.QcRc;
using Business.Interfaces.BaseCalculations;
using Business.Interfaces.Calculations;

namespace Business.BusinessModels.Calculations.QcRc
{
   public class CalcQcRcCpsPpk : ICalcQcRc<QcRcCpsPpk>
   {
      private IQcRc QcRc;
      public CalcQcRcCpsPpk(IQcRc qcrc)
      {
         QcRc = qcrc;
      }

      public QcRcCpsPpk Calc(QcRcData data)
      {
         QcRcKgData Data = data as QcRcKgData;
         var kip = Data.Kip;
         var charKg = Data.CharacteristicsKg;
         var wetGas = Data.WetGas;

         return new QcRcCpsPpk
         {
            Pko =
               {
                  Ms = QcRc.Calc(kip.Pkc.ConsumptionMs, wetGas.Pkc, kip.Pkc.Temperature, charKg.Kc1.Characteristics.Density),
                  Ks = QcRc.Calc(kip.Pkc.ConsumptionKs, wetGas.Pkc, kip.Pkc.Temperature, charKg.Kc1.Characteristics.Density),
               },
            Uvtp = QcRc.Calc(kip.Uvtp.Consumption, wetGas.Uvtp, kip.Uvtp.Temperature, charKg.Kc1.Characteristics.Density),
            Spo = QcRc.Calc(kip.Spo.Consumption, wetGas.Spo, kip.Spo.Temperature, charKg.Kc1.Characteristics.Density),
            Gsuf = QcRc.Calc(kip.Gsuf45.Consumption, wetGas.Gsuf, kip.Gsuf45.Temperature, charKg.Kc1.Characteristics.Density),
         };
      }
   }
}
