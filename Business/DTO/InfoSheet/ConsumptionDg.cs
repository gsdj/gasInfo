using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTO.InfoSheet
{
   public class ConsumptionDg
   {
      //Расход доменного газа на обогрев (Оценочный, приведение "М-К")
      public decimal ConsDgCb1M { get; set; } = 0; // (EdRepSum Sum_Cb1_1000) // ст.м³ с начала месяца
      public decimal ConsDgCb11000 { get; set; } = 0; // (ConsDG Cb1_1000) // ст.м³ (1000кКал/м³)
      public decimal ConsDgCb1H { get; set; } = 0; // (ConsDG Cb1_1000 / 24) // ст.м³/час
      public decimal ConsDgCb1UdFv { get; set; } = 0; // (ConsDgPg Ud_cons_kg_fv_Cb1) // Удельный, ст.м³/тн. шихты в ф.в.
      public decimal ConsDgCb2M { get; set; } = 0; // (EdRepSum Sum_Cb2_1000) // ст.м³ с начала месяца
      public decimal ConsDgCb21000 { get; set; } = 0; // (ConsDG Cb2_1000) // ст.м³ (1000кКал/м³)
      public decimal ConsDgCb2H { get; set; } = 0; // (ConsDG Cb2_1000 / 24) // ст.м³/час
      public decimal ConsDgCb2UdFv { get; set; } = 0; // (ConsDgPg Ud_cons_kg_fv_Cb2) // Удельный, ст.м³/тн. шихты в ф.в.
      public decimal ConsDgCb3M { get; set; } = 0; // (EdRepSum Sum_Cb3_1000) // ст.м³ с начала месяца
      public decimal ConsDgCb31000 { get; set; } = 0; // (ConsDG Cb3_1000) // ст.м³ (1000кКал/м³)
      public decimal ConsDgCb3H { get; set; } = 0; // (ConsDG Cb3_1000 / 24) // ст.м³/час
      public decimal ConsDgCb3UdFv { get; set; } = 0; // (ConsDgPg Ud_cons_kg_fv_Cb3) // Удельный, ст.м³/тн. шихты в ф.в.
      public decimal ConsDgCb4M { get; set; } = 0; // (EdRepSum Sum_Cb4_1000) // ст.м³ с начала месяца
      public decimal ConsDgCb41000 { get; set; } = 0; // (ConsDG Cb4_1000) // ст.м³ (1000кКал/м³)
      public decimal ConsDgCb4H { get; set; } = 0; // (ConsDG Cb4_1000 / 24) // ст.м³/час
      public decimal ConsDgCb4UdFv { get; set; } = 0; // (ConsDgPg Ud_cons_kg_fv_Cb4) // Удельный, ст.м³/тн. шихты в ф.в.
   }
}
