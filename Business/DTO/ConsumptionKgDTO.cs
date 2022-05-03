using Business.DTO.Consumption;
using Business.DTO.General;
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
      public ConsumptionKgDTO()
      {
         QcRcCb = new QcRcKc2();
         ConsumptionCb = new CbKc();
         QcRcCpsPpk = new CpsPpkQcRc();
         ConsumptionCpsPpk = new ConsumptionCpsPpk();
      }
      public DateTime Date { get; set; }
      public QcRcKc2 QcRcCb { get; set; }
      public CbKc ConsumptionCb { get; set; }
      public CpsPpkQcRc QcRcCpsPpk { get; set; }
      public ConsumptionCpsPpk ConsumptionCpsPpk { get; set; }
      public decimal QcRcGsuf { get; set; }
      public decimal ConsumptionGsuf { get; set; }
      public decimal ConsumptionKc2Sum { get; set; }
      public decimal PkoQcRcSum { get; set; }
      public decimal ConsumptionCpsPpkSum { get; set; }
      public decimal ConsumptionMkSum { get; set; }
      public decimal ConsumptionMkGsufSum { get; set; }
   }
}
