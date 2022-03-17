using Business.DTO;
using System;
using System.Collections.Generic;

namespace Business.BusinessModels.DataForCalculations
{
   public class InfoSheetData
   {
      public DateTime Date { get; set; }
      public CharacteristicsKgDTO CharacteristicsKg { get; set; }
      public CharacteristicsDgDTO CharacteristicsDg { get; set; }
      public IEnumerable<OutputKgDTO> OutputKgDTOs { get; set; }
      public IEnumerable<ConsumptionKgDTO> ConsumptionKgDTOs { get; set; }
      public IEnumerable<ProductionDTO> ProductionDTOs { get; set; }
      public IEnumerable<ReportKgDTO> ReportKgDTOs { get; set; }
      public IEnumerable<ConsumptionDgPgDTO> ConsumptionDgPgDTOs { get; set; }
      public IEnumerable<ConsumptionDgDTO> ConsumptionDgDTOs { get; set; }
      public AsdueDTO AsdueDTO { get; set; }
      public ChartMonthDTO ChartMonth { get; set; }
   }
}
