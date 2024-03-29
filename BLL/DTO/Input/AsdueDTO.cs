﻿using BLL.Models.BaseModels.General;

namespace BLL.DTO.Input
{
   public class AsdueDTO : Entity
   {
      public decimal TecNorth { get; set; } = 0;
      public decimal TecSouth { get; set; } = 0;
      public decimal Gps2Gss1 { get; set; } = 0;
      public decimal Gps2Gss2 { get; set; } = 0;
      public decimal NaturalGasQn { get; set; } = 0;
      public decimal OutPkg { get; set; } = 0;
      public decimal StmDay { get; set; }//=> (TecNorth + TecSouth + Gps2Gss1 + Gps2Gss2);
   }
}
