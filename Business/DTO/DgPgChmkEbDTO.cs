using Business.DTO.Consumption;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTO
{
   public class DgPgChmkEbDTO
   {
      public DateTime Date { get; set; }
      public ConsumptionKc1<int> ConsumptionDgKc1 { get; set; }
      public int ConsDgKc1Sum { get; set; }// => ConsDgCb1 + ConsDgCb2 + ConsDgCb3 + ConsDgCb4;
      public ConsumptionGru<int> ConsumptionPgGru { get; set; }
      public int ConsPgUpc { get; set; }// => ConsPgGru1 + ConsPgGru2;
   }
}
