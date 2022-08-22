using Business.DTO.Models.Production;
using System;

namespace Business.DTO.Input
{
   public class AmmountCbDTO : AmmountCb<int>
   {
      public DateTime Date { get; set; }
   }
}
