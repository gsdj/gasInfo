using Business.DTO.Consumption;
using Business.DTO.QcRc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTO
{
   public class ConsumptionKgDTO
   {
      public DateTime Date { get; set; }
      public QcRcKc2 QcRcCb { get; set; }
      public ConsumptionKc2 Consumption { get; set; }
      public QcRcEtc QcRcEtc { get; set; }
      public ConsumptionEtc ConsumptionEtc { get; set; }
      public decimal QcRcKc2 { get; set; }
      public decimal PkoSum { get; set; }
      public decimal CpsppkSum4000 { get; set; }
      public decimal MkSum4000 { get; set; }
      public decimal MkGsufSum4000 { get; set; }
   }
}
