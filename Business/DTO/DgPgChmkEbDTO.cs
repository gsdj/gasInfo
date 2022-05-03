using Business.DTO.Consumption;
using Business.DTO.General;
using System;

namespace Business.DTO
{
   public class DgPgChmkEbDTO
   {
      public DateTime Date { get; set; }
      public CbKc ConsumptionDgKc1 { get; set; }
      public decimal ConsDgKc1Sum { get; set; }// => ConsDgCb1 + ConsDgCb2 + ConsDgCb3 + ConsDgCb4;
      public ConsumptionGru<int> ConsumptionPgGru { get; set; }
      public int ConsPgUpc { get; set; }// => ConsPgGru1 + ConsPgGru2;
   }
}
