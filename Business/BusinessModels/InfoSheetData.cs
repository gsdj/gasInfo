using Business.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.BusinessModels
{
   public class InfoSheetData
   {
      public CharacteristicsKgDTO CharacteristicsKg { get; set; }
      public CharacteristicsDgDTO CharacteristicsDg { get; set; }
      public List<OutputKgDTO> OutputKgDTOs { get; set; }
      public List<ConsumptionKgDTO> ConsumptionKgDTOs { get; set; }
      public List<ProductionDTO> ProductionDTOs { get; set; }
      public List<ReportKgDTO> ReportKgDTOs { get; set; }
      public List<ConsumptionDgPgDTO> ConsumptionDgPgDTOs { get; set; }
      public List<ConsumptionDgDTO> ConsumptionDgDTOs { get; set; }
      public AsdueDTO AsdueDTO { get; set; }
      public ChartMonthDTO ChartMonth { get; set; }
   }
}
