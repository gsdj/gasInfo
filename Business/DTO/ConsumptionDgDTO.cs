using Business.DTO.General;
using Business.DTO.QcRc;
using System;

namespace Business.DTO
{
   public class ConsumptionDgDTO
   {
      public DateTime Date { get; set; }
      public QcRcKc1 QcRc { get; set; }
      public CbKc ConsumptionDg { get; set; }
      public decimal ConsumptionDgMk { get; set; }
   }
}
