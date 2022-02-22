using Business.DTO;
using Business.Interfaces.Calculations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.BusinessModels.Calculations
{
   public class CalcChartYear : ICalcChart<ChartYearDTO>
   {
      public IEnumerable<ChartYearDTO> CalcEntities(IEnumerable<ProductionDTO> prod, IEnumerable<CharacteristicsKgDTO> charKg, 
                                                      IEnumerable<QualityDTO> quality, IEnumerable<OutputKgDTO> outputKg, 
                                                      IEnumerable<ConsumptionKgDTO> consKg, IEnumerable<AsdueDTO> asdue, IEnumerable<KgChmkEbDTO> kgChmk)
      {
         List<ChartYearDTO> chartYearDTO = new List<ChartYearDTO>(prod.Count());
         var data =
            from t1prod in prod
            join t2charKg in charKg on new { t1prod.Date } equals new { t2charKg.Date }
            join t3quality in quality on new { t2charKg.Date } equals new { t3quality.Date }
            join t4outputKg in outputKg on new { t3quality.Date } equals new { t4outputKg.Date }
            join t5consKg in consKg on new { t4outputKg.Date } equals new { t5consKg.Date }
            join t6asdue in asdue on new { t5consKg.Date } equals new { t6asdue.Date }
            join t7kgChmk in kgChmk on new { t6asdue.Date } equals new { t7kgChmk.Date }
            select new
            {
               Prod = t1prod,
               CharKg = t2charKg,
               Quality = t3quality,
               OutputKg = t4outputKg,
               ConsKg = t5consKg,
               Asdue = t6asdue,
               KgChmkEb = t7kgChmk
            };
         foreach (var item in data)
         {
            chartYearDTO.Add(CalcEntity(item.Prod, item.CharKg, item.Quality, item.OutputKg, item.ConsKg, item.Asdue, item.KgChmkEb));
         }
         return chartYearDTO;
      }

      public ChartYearDTO CalcEntity(ProductionDTO prod, CharacteristicsKgDTO charKg, QualityDTO quality, 
                                       OutputKgDTO outputKg, ConsumptionKgDTO consKg, AsdueDTO asdue, KgChmkEbDTO kgChmk)
      {
         var data = new
         {
            Kc2Sum = (consKg.Kc2Sum == 0 && consKg.CpsppkSum4000 == 0) ? 0 : (consKg.Kc2Sum + consKg.CpsppkSum4000) / 24,
            GSUF4000 = (consKg.Gsuf4000 == 0) ? 0 : consKg.Gsuf4000 / 24,
            PrMk4000 = (outputKg.PrMk4000 == 0) ? 0 : outputKg.PrMk4000 / 24,

            TradeGasEB = kgChmk.Consumption,
            TradeGasTn = prod.TnConsDry * 10,

            TradeGasAsdue = (asdue.StmDay == 0 || charKg.Kc1.Characteristics.Qn == 0) ? 0 : ((asdue.StmDay / 24) * charKg.Kc1.Characteristics.Qn) / 4000,
            TheorOutKg = (prod.Cb16ConsDry == 0 || prod.TnConsDry == 0) ? 0 :
                                Math.Round((quality.Kc1.KgFh * (prod.Cb16ConsDry / prod.TnConsDry) + quality.Kc2.KgFh * (prod.Cb78ConsDry / prod.TnConsDry)) * 1000, 0),
         };

         return new ChartYearDTO
         {
            Date = prod.Date,
            TradeGasMK = Math.Round(data.PrMk4000 - data.Kc2Sum - data.GSUF4000, 0),
            TradeGasEB = Math.Round(data.TradeGasEB, 0),
            TradeGasTn = Math.Round(data.TradeGasTn, 0),
            TradeGasAsdue = Math.Round(data.TradeGasAsdue, 0),
            TradeGasV = (data.TheorOutKg == 0) ? 0 : Math.Round(prod.TnConsDry * (data.TheorOutKg / 24) - data.Kc2Sum - data.GSUF4000, 0),
            TradeGasDev = (data.TradeGasEB == 0 || data.TradeGasAsdue == 0) ? 0 : Math.Round((data.TradeGasEB / data.TradeGasAsdue) * 100, 0),
         };
      }
   }
}
