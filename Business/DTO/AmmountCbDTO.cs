using Business.DTO.Models.Production;
using System;

namespace Business.DTO
{
   public class AmmountCbDTO : AmmountCb<int>
   {
      public DateTime Date { get; set; }
   }
}
