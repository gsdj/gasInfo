using BLL.Models.BaseModels.Production;
using System;

namespace BLL.DTO.Input
{
   public class OutputMultipliersDTO : Cb<decimal>
   {
      public DateTime Date { get; set; }
      public decimal Sv { get; set; }
      public decimal Fv { get; set; }
      public decimal Peka { get; set; }
   }
}
