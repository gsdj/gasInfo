using BLL.Models.BaseModels.Production;
using System;

namespace BLL.DTO.Input
{
   public class AmmountCbDTO : Cb<int>
   {
      public DateTime Date { get; set; }
   }
}
