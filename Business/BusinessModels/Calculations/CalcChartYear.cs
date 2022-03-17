using Business.BusinessModels.DataForCalculations;
using Business.DTO;
using Business.Interfaces.Calculations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.BusinessModels.Calculations
{
   public class CalcChartYear : ICalculation<ChartYearDTO>, ICalculations<ChartYearDTO>
   {
      public IEnumerable<ChartYearDTO> CalcEntities(EnumerableData data)
      {
         var Data = data as ChartEnumData;
         var prod = Data.Production;
         var charKg = Data.CharacteristicsKg;
         var quality = Data.Quality;
         var outputKg = Data.OutputKg;
         var consKg = Data.ConsKg;
         var asdue = Data.Asdue;
         var kgChmk = Data.KgChmkEb;

         var d =
            from t1prod in prod
            join t2charKg in charKg on new { t1prod.Date } equals new { t2charKg.Date }
            join t3quality in quality on new { t2charKg.Date } equals new { t3quality.Date }
            join t4outputKg in outputKg on new { t3quality.Date } equals new { t4outputKg.Date }
            join t5consKg in consKg on new { t4outputKg.Date } equals new { t5consKg.Date }
            join t6asdue in asdue on new { t5consKg.Date } equals new { t6asdue.Date }
            join t7kgChmk in kgChmk on new { t6asdue.Date } equals new { t7kgChmk.Date }
            select new ChartData
            {
               Production = t1prod,
               CharacteristicsKg = t2charKg,
               Quality = t3quality,
               OutputKg = t4outputKg,
               ConsKg = t5consKg,
               Asdue = t6asdue,
               KgChmkEb = t7kgChmk
            };

         List<ChartYearDTO> chartYearDTO = new List<ChartYearDTO>(d.Count());

         foreach (var item in d)
         {
            chartYearDTO.Add(CalcEntity(item));
         }
         return chartYearDTO;
      }

      public ChartYearDTO CalcEntity(Data data)
      {
         ChartData Data = data as ChartData;
         var data1 = new
         {
            Kc2Sum = (Data.ConsKg.ConsumptionKc2Sum == 0 && Data.ConsKg.ConsumptionCpsPpkSum == 0) ? 0 : (Data.ConsKg.ConsumptionKc2Sum + Data.ConsKg.ConsumptionCpsPpkSum) / 24,
            GSUF4000 = (Data.ConsKg.ConsumptionGsuf == 0) ? 0 : Data.ConsKg.ConsumptionGsuf / 24,
            PrMk4000 = (Data.OutputKg.PrMk4000 == 0) ? 0 : Data.OutputKg.PrMk4000 / 24,

            TradeGasEB = Data.KgChmkEb.Consumption,
            TradeGasTn = Data.Production.TnConsDry * 10,

            TradeGasAsdue = (Data.Asdue.StmDay == 0 || Data.CharacteristicsKg.Kc1.Characteristics.Qn == 0) ? 0 : ((Data.Asdue.StmDay / 24) * Data.CharacteristicsKg.Kc1.Characteristics.Qn) / 4000,
            TheorOutKg = (Data.Production.Cb16ConsDry == 0 || Data.Production.TnConsDry == 0) ? 0 :
                       Math.Round((Data.Quality.Kc1.KgFh * (Data.Production.Cb16ConsDry / Data.Production.TnConsDry) + Data.Quality.Kc2.KgFh * (Data.Production.Cb78ConsDry / Data.Production.TnConsDry)) * 1000, 0),
         };

         return new ChartYearDTO
         {
            Date = Data.Production.Date,
            TradeGasMK = Math.Round(data1.PrMk4000 - data1.Kc2Sum - data1.GSUF4000, 0),
            TradeGasEB = Math.Round(data1.TradeGasEB, 0),
            TradeGasTn = Math.Round(data1.TradeGasTn, 0),
            TradeGasAsdue = Math.Round(data1.TradeGasAsdue, 0),
            TradeGasV = (data1.TheorOutKg == 0) ? 0 : Math.Round(Data.Production.TnConsDry * (data1.TheorOutKg / 24) - data1.Kc2Sum - data1.GSUF4000, 0),
            TradeGasDev = (data1.TradeGasEB == 0 || data1.TradeGasAsdue == 0) ? 0 : Math.Round((data1.TradeGasEB / data1.TradeGasAsdue) * 100, 0),
         };
      }
   }
}
