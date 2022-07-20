using Business.DTO.Models.General;
using System;

namespace Business.DTO
{
   public class DgPgChmkEbDTO : Entity
   {
      public CbKc ConsumptionDgKc1 { get; set; }
      public decimal ConsDgKc1Sum { get; set; }// => ConsDgCb1 + ConsDgCb2 + ConsDgCb3 + ConsDgCb4;
      public Gru ConsumptionPgGru { get; set; }
      public int ConsPgUpc { get; set; }// => ConsPgGru1 + ConsPgGru2;
   }
}
