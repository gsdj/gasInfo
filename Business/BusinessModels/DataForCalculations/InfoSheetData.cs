﻿using Business.DTO;
using Business.DTO.Charts;
using Business.DTO.Consumption;
using Business.DTO.Input;
using Business.DTO.Models.Characteristics.Gas;
using System;
using System.Collections.Generic;

namespace Business.BusinessModels.DataForCalculations
{
   public class InfoSheetData
   {
      public DateTime Date { get; set; }
      public CharacteristicsKG CharacteristicsKg { get; set; }
      public CharacteristicsDG CharacteristicsDg { get; set; }
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
