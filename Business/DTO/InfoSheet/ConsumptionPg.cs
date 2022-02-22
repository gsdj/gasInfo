using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTO.InfoSheet
{
   public class ConsumptionPg
   {
      //Расход природного газа на разогрев
      public decimal ConsPgGru1Stm { get; set; } = 0; // (EdRepSum Sum_cons_pg_gru1) // ст.м³ с начала месяца
      public decimal ConsPgGru1St { get; set; } = 0; // (ConsDgPg Cons_pg_gru1) // ст.м³ 
      public decimal ConsPgGru1Sth { get; set; } = 0; // (ConsDgPg Cons_pg_gru1 / 24) // ст.м³/час
      public decimal ConsPgGru1UdFv { get; set; } = 0; // (ConsDgPg Ud_cons_pg_gru1) // Удельный, ст.м³/тн. шихты в ф.в.
      public decimal ConsPgGru2Stm { get; set; } = 0; // (EdRepSum Sum_cons_pg_gru2) // ст.м³ с начала месяца
      public decimal ConsPgGru2St { get; set; } = 0; // (ConsDgPg Cons_pg_gru2) // ст.м³ 
      public decimal ConsPgGru2Sth { get; set; } = 0; // (ConsDgPg Cons_pg_gru2 / 24) // ст.м³/час
      public decimal ConsPgGru2UdFv { get; set; } = 0; // (ConsDgPg Ud_cons_pg_gru2) // Удельный, ст.м³/тн. шихты в ф.в.
   }
}
