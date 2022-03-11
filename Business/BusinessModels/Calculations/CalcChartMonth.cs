using Business.BusinessModels.DataForCalculations;
using Business.DTO;
using Business.Interfaces.Calculations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.BusinessModels.Calculations
{
   public class CalcChartMonth : ICalculation<ChartMonthDTO>// ICalcChart<ChartMonthDTO>
   {
      //public IEnumerable<ChartMonthDTO> CalcEntities(IEnumerable<ProductionDTO> prod, IEnumerable<CharacteristicsKgDTO> charKg, 
      //                                                IEnumerable<QualityDTO> quality, IEnumerable<OutputKgDTO> outputKg, 
      //                                                IEnumerable<ConsumptionKgDTO> consKg, IEnumerable<AsdueDTO> asdue, IEnumerable<KgChmkEbDTO> kgChmk)
      //{
      //   List<ChartMonthDTO> chartMonthDTO = new List<ChartMonthDTO>(prod.Count());
      //   var data =
      //      from t1prod in prod
      //      join t2charKg in charKg on new { t1prod.Date } equals new { t2charKg.Date }
      //      join t3quality in quality on new { t2charKg.Date } equals new { t3quality.Date }
      //      join t4outputKg in outputKg on new { t3quality.Date } equals new { t4outputKg.Date }
      //      join t5consKg in consKg on new { t4outputKg.Date } equals new { t5consKg.Date }
      //      join t6asdue in asdue on new { t5consKg.Date } equals new { t6asdue.Date }
      //      join t7kgChmk in kgChmk on new { t6asdue.Date } equals new { t7kgChmk.Date }
      //      select new
      //      {
      //         Prod = t1prod,
      //         CharKg = t2charKg,
      //         Quality = t3quality,
      //         OutputKg = t4outputKg,
      //         ConsKg = t5consKg,
      //         Asdue = t6asdue,
      //         KgChmkEb = t7kgChmk
      //      };
      //   foreach (var item in data)
      //   {
      //      chartMonthDTO.Add(CalcEntity(item.Prod, item.CharKg, item.Quality, item.OutputKg, item.ConsKg, item.Asdue, item.KgChmkEb));
      //   }
      //   return chartMonthDTO;
      //}

      //public ChartMonthDTO CalcEntity(ProductionDTO prod, CharacteristicsKgDTO charKg, QualityDTO quality, 
      //                                 OutputKgDTO outputKg, ConsumptionKgDTO consKg, AsdueDTO asdue, KgChmkEbDTO kgChmk)
      //{
      //   var data = new
      //   {
      //      Kc2Sum = (consKg.ConsumptionKc2Sum + consKg.ConsumptionCpsPpkSum) / 24,
      //      Gsuf4000 = consKg.ConsumptionGsuf / 24,
      //      Asdue = (asdue.StmDay / 24) * charKg.Kc1.Characteristics.Qn / 4000,
      //      Oper = outputKg.PrMk4000 / prod.TnConsDry,
      //   };

      //   return new ChartMonthDTO
      //   {
      //      Date = prod.Date,
      //      TheorOutKg = (prod.Cb16ConsDry == 0 || prod.TnConsDry == 0) ? 0 : 
      //                     Math.Round((quality.Kc1.KgFh * (prod.Cb16ConsDry / prod.TnConsDry) + quality.Kc2.KgFh * (prod.Cb78ConsDry / prod.TnConsDry)) * 1000, 0),
      //      OperOutKg = Math.Round(data.Oper, 0),
      //      TradeOutKg = (prod.TnConsDry == 0) ? 0 : Math.Round((data.Kc2Sum + data.Gsuf4000 + data.Asdue) * 24 / prod.TnConsDry, 0),
      //      TradeChmkOutKg = (prod.TnConsDry == 0) ? 0 : Math.Round((data.Kc2Sum + data.Gsuf4000 + kgChmk.Consumption) * 24 / prod.TnConsDry, 0),
      //   };
      //}

      public ChartMonthDTO CalcEntity(Data data)
      {
         ChartData Data = data as ChartData;
         var data1 = new
         {
            Kc2Sum = (Data.ConsKg.ConsumptionKc2Sum + Data.ConsKg.ConsumptionCpsPpkSum) / 24,
            Gsuf4000 = Data.ConsKg.ConsumptionGsuf / 24,
            Asdue = (Data.Asdue.StmDay / 24) * Data.CharacteristicsKg.Kc1.Characteristics.Qn / 4000,
            Oper = Data.OutputKg.PrMk4000 / Data.Production.TnConsDry,
         };

         return new ChartMonthDTO
         {
            Date = Data.Production.Date,
            TheorOutKg = (Data.Production.Cb16ConsDry == 0 || Data.Production.TnConsDry == 0) ? 0 :
                           Math.Round((Data.Quality.Kc1.KgFh * (Data.Production.Cb16ConsDry / Data.Production.TnConsDry) + Data.Quality.Kc2.KgFh * (Data.Production.Cb78ConsDry / Data.Production.TnConsDry)) * 1000, 0),
            OperOutKg = Math.Round(data1.Oper, 0),
            TradeOutKg = (Data.Production.TnConsDry == 0) ? 0 : Math.Round((data1.Kc2Sum + data1.Gsuf4000 + data1.Asdue) * 24 / Data.Production.TnConsDry, 0),
            TradeChmkOutKg = (Data.Production.TnConsDry == 0) ? 0 : Math.Round((data1.Kc2Sum + data1.Gsuf4000 + Data.KgChmkEb.Consumption) * 24 / Data.Production.TnConsDry, 0),
         };
      }
   }
}
