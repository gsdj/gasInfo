using BLL.Models.BaseModels.Production;
using System;

namespace BLL.DTO.Input
{
   public class AmmountCbDTO : AmmountCb<int>
   {
      public DateTime Date { get; set; }
   }
}
