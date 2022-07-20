using Business.BusinessModels.DataForCalculations;
using Business.DTO;
using Business.DTO.Models.InfoSheet;
using Business.Interfaces.Calculations;
using System.Linq;

namespace Business.BusinessModels.Calculations
{
   public class CalcInfoSheet : ICalcInfoSheet
   {
      private InfoSheetData Data;

      public InfoSheetDTO CalcInfo(InfoSheetData data)
      {
         Data = data;
         var consDgPgPerDate = Data.ConsumptionDgPgDTOs.FirstOrDefault(p => p.Date == Data.Date);
         var outKgPerDate = Data.OutputKgDTOs.FirstOrDefault(p => p.Date == Data.Date);
         var consKgPerDate = Data.ConsumptionKgDTOs.FirstOrDefault(p => p.Date == Data.Date);
         var repKgPerDate = Data.ReportKgDTOs.FirstOrDefault(p => p.Date == Data.Date);

         var sumCu1 = Data.ConsumptionKgDTOs.Sum(p => p.PkoQcRcSum) + Data.OutputKgDTOs.Sum(p => p.Cu14000);
         var sumCu2 = Data.OutputKgDTOs.Sum(p => p.Cu24000);

         return new InfoSheetDTO
         {
            Date = Data.Date,
            CharacteristicsGas = CharacteristicsKgDg(),
            OutputKg = OutputKg(outKgPerDate, consKgPerDate, sumCu1, sumCu2),
            ConsumptionKg = ConsKg(repKgPerDate),
            TradeKg = TradeKg(outKgPerDate, consKgPerDate, repKgPerDate, sumCu1, sumCu2),
            ConsumptionDg = ConsDg(consDgPgPerDate),
            ConsumptionPg = ConsPg(consDgPgPerDate),
         };
      }

      private CharacteristicsKgDg CharacteristicsKgDg()
      {
         return new CharacteristicsKgDg
         {
            CharacteristicsDG =
               {
                  Qn = Data.CharacteristicsDg.AVG.Qn,
                  Density = Data.CharacteristicsDg.AVG.Density,
               },
            CharacteristicsKGKc1 =
               {
                  Qn = Data.CharacteristicsKg.Kc1.Qn,
                  Density = Data.CharacteristicsKg.Kc1.Density,
               },
            CharacteristicsKGKc2 =
               {
                  Qn = Data.CharacteristicsKg.Kc2.Qn,
                  Density = Data.CharacteristicsKg.Kc2.Density,
               }
         };
      }

      private OutputKg OutputKg(OutputKgDTO outKg, ConsumptionKgDTO consKg, decimal sumCu1, decimal sumCu2)
      {
         var prodPerDate = Data.ProductionDTOs.FirstOrDefault(p => p.Date == Data.Date);

         return new OutputKg
         {
            OutKgStCu1 = outKg.Cu14000 + consKg.PkoQcRcSum,
            OutKgUdSvCu1 = (outKg.Cu14000 + consKg.PkoQcRcSum) / prodPerDate.Cb16ConsDry,
            OutKgSthCu1 = (outKg.Cu14000 + consKg.PkoQcRcSum) / 24,
            SumOutKgCu1 = sumCu1,

            OutKgStCu2 = outKg.Cu24000,
            OutKgUdSvCu2 = outKg.Cu24000 / prodPerDate.Cb78ConsDry,
            OutKgSthCu2 = outKg.Cu24000 / 24,
            SumOutKgCu2 = sumCu2,

            OutKgUdSvMk = (outKg.Cu14000 + consKg.PkoQcRcSum + outKg.Cu24000) / prodPerDate.TnConsDry,
            OutKgStMk = outKg.Cu14000 + consKg.PkoQcRcSum + outKg.Cu24000,
            OutKgSthMk = (outKg.Cu14000 + consKg.PkoQcRcSum + outKg.Cu24000) / 24,
            SumOutKgMk = sumCu1 + sumCu2,

            UdOutKgTradeTheor = Data.ChartMonth.TheorOutKg,
            UdOutKgTradeAsdue = Data.ChartMonth.TradeOutKg,
            UdOutKgTradeChmk = Data.ChartMonth.TradeChmkOutKg,
            UdOutKgOperMk = Data.ChartMonth.OperOutKg,

            PgQnm = Data.AsdueDTO.NaturalGasQn,
         };
      }

      private ConsumptionKg ConsKg(ReportKgDTO repKg)
      {
         return new ConsumptionKg
         {
            UdSvCb = repKg.ConsumptionFvKc2,
            DayCb = repKg.ConsumptionKc2,
            HourCb =
            {
               Cb1 = repKg.ConsumptionKc2.Cb1 / 24,
               Cb2 = repKg.ConsumptionKc2.Cb2 / 24,
               Cb3 = repKg.ConsumptionKc2.Cb3 / 24,
               Cb4 = repKg.ConsumptionKc2.Cb4 / 24,
            },
            MonthCb =
            {
               Cb1 = Data.ReportKgDTOs.Sum(p => p.ConsumptionKc2.Cb1),
               Cb2 = Data.ReportKgDTOs.Sum(p => p.ConsumptionKc2.Cb2),
               Cb3 = Data.ReportKgDTOs.Sum(p => p.ConsumptionKc2.Cb3),
               Cb4 = Data.ReportKgDTOs.Sum(p => p.ConsumptionKc2.Cb4),
            },
            UdSvCpsPpk = repKg.ConsumptionFvCpsPpk,
            DayCpsPpk = repKg.ConsumptionCpsPpk,
            HourCpsPpk =
            {
               Pko =
               {
                  Pkp = repKg.ConsumptionCpsPpk.Pko.Pkp / 24,
                  Uvtp = repKg.ConsumptionCpsPpk.Pko.Uvtp / 24,
               },
               Spo = repKg.ConsumptionCpsPpk.Spo / 24,
            },
            MonthCpsPpk =
            {
               Pko = 
               {
                  Pkp = Data.ReportKgDTOs.Sum(p => p.ConsumptionCpsPpk.Pko.Pkp),
                  Uvtp = Data.ReportKgDTOs.Sum(p => p.ConsumptionCpsPpk.Pko.Uvtp),
               }, 
               Spo = Data.ReportKgDTOs.Sum(p => p.ConsumptionCpsPpk.Spo),
            },
            ConsKgUdSvCpsPpk = repKg.ConsFvCpsPpkSum,
            ConsKgDayCpsPpk = repKg.ConsKgCpsPpkSum,
            ConsKgHourCpsPpk = repKg.ConsKgCpsPpkSum / 24,
            ConsKgMonthCpsPpk = Data.ReportKgDTOs.Sum(p => p.ConsKgCpsPpkSum),

            ConsKgMkDay = repKg.ConsKgMk,
            ConsKgMkHour = repKg.ConsKgMk / 24,
            ConsKgMkMonth = Data.ReportKgDTOs.Sum(p => p.ConsKgMk),
         };
      }

      private ConsumptionDg ConsDg(ConsumptionDgPgDTO consDgPg)
      {
         var consDgPerDate = Data.ConsumptionDgDTOs.FirstOrDefault(p => p.Date == Data.Date);

         return new ConsumptionDg
         {
            UdFv = consDgPg.UdConsumptionKgFvCb,
            Day = consDgPerDate.ConsumptionDg,
            Hour =
            {
               Cb1 = consDgPerDate.ConsumptionDg.Cb1 / 24,
               Cb2 = consDgPerDate.ConsumptionDg.Cb2 / 24,
               Cb3 = consDgPerDate.ConsumptionDg.Cb3 / 24,
               Cb4 = consDgPerDate.ConsumptionDg.Cb4 / 24,
            },
            Month =
            {
               Cb1 = Data.ConsumptionDgDTOs.Sum(p => p.ConsumptionDg.Cb1),
               Cb2 = Data.ConsumptionDgDTOs.Sum(p => p.ConsumptionDg.Cb2),
               Cb3 = Data.ConsumptionDgDTOs.Sum(p => p.ConsumptionDg.Cb3),
               Cb4 = Data.ConsumptionDgDTOs.Sum(p => p.ConsumptionDg.Cb4),
            },
         };
      }

      private ConsumptionPg ConsPg(ConsumptionDgPgDTO consDgPg)
      {
         return new ConsumptionPg
         {
            UdFv = consDgPg.UdConsumptionPgGru,
            Day = consDgPg.ConsumptionPgGru,
            Hour =
            {
               Gru1 = consDgPg.ConsumptionPgGru.Gru1 / 24,
               Gru2 = consDgPg.ConsumptionPgGru.Gru2 / 24,
            },
            Month =
            {
               Gru1 = Data.ConsumptionDgPgDTOs.Sum(p => p.ConsumptionPgGru.Gru1),
               Gru2 = Data.ConsumptionDgPgDTOs.Sum(p => p.ConsumptionPgGru.Gru2),
            },
         };
      }

      private TradeKg TradeKg(OutputKgDTO outKg, ConsumptionKgDTO consKg, ReportKgDTO repKg, decimal sumCu1, decimal sumCu2)
      {
         return new TradeKg
         {
            TradeKgNorth4000 = outKg.Cu24000 - (consKg.ConsumptionCb.Cb3 + consKg.ConsumptionCb.Cb4),
            TradeKgNorthH = outKg.Cu24000 - (consKg.ConsumptionCb.Cb3 + consKg.ConsumptionCb.Cb4) / 24,
            TradeKgNorthM = sumCu2 - Data.ConsumptionKgDTOs.Sum(p => p.ConsumptionCb.Cb3 + p.ConsumptionCb.Cb4),

            TradeKgSouth4000 = (outKg.Cu14000 + consKg.PkoQcRcSum) - (consKg.ConsumptionCpsPpk.Spo - consKg.ConsumptionGsuf),
            TradeKgSouthH = ((outKg.Cu14000 + consKg.PkoQcRcSum) - (consKg.ConsumptionCpsPpk.Spo - consKg.ConsumptionGsuf)) / 24,
            TradeKgSouthM = sumCu1 - Data.ConsumptionKgDTOs.Sum(p => p.ConsumptionCpsPpk.Spo),

            Gsuf4000 = repKg.ConsGsuf,
            GsufH = repKg.ConsGsuf / 24,
            GsufM = Data.ReportKgDTOs.Sum(p => p.ConsGsuf),
         };
      }
   }
}
