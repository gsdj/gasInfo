using Business.DTO.Models.General;
using Business.DTO.Models.InfoSheet;

namespace Business.DTO
{
   public class InfoSheetDTO : Entity
   {
      public CharacteristicsKgDg CharacteristicsGas { get; set; }
      //public decimal AvgMkDGQn { get; set; } = 0;
      //public decimal AvgMkDgPkg { get; set; } = 0;
      //public decimal Cu1Qn { get; set; } = 0;
      //public decimal Cu1Pkg { get; set; } = 0;
      //public decimal Cu2Qn { get; set; } = 0;
      //public decimal Cu2Pkg { get; set; } = 0;

      //Выход коксового газа
      public OutputKg OutputKg { get; set; }

      //Расход КГ на обогрев
      public ConsumptionKg ConsumptionKg { get; set; }

      //Товарный коксовый газ
      public TradeKg TradeKg { get; set; }

      //Расход доменного газа на обогрев (Оценочный, приведение "М-К")
      public ConsumptionDg ConsumptionDg { get; set; }
      //public decimal ConsDgCb1M { get; set; } = 0; // (EdRepSum Sum_Cb1_1000) // ст.м³ с начала месяца
      //public decimal ConsDgCb11000 { get; set; } = 0; // (ConsDG Cb1_1000) // ст.м³ (1000кКал/м³)
      //public decimal ConsDgCb1H { get; set; } = 0; // (ConsDG Cb1_1000 / 24) // ст.м³/час
      //public decimal ConsDgCb1UdFv { get; set; } = 0; // (ConsDgPg Ud_cons_kg_fv_Cb1) // Удельный, ст.м³/тн. шихты в ф.в.
      //public decimal ConsDgCb2M { get; set; } = 0; // (EdRepSum Sum_Cb2_1000) // ст.м³ с начала месяца
      //public decimal ConsDgCb21000 { get; set; } = 0; // (ConsDG Cb2_1000) // ст.м³ (1000кКал/м³)
      //public decimal ConsDgCb2H { get; set; } = 0; // (ConsDG Cb2_1000 / 24) // ст.м³/час
      //public decimal ConsDgCb2UdFv { get; set; } = 0; // (ConsDgPg Ud_cons_kg_fv_Cb2) // Удельный, ст.м³/тн. шихты в ф.в.
      //public decimal ConsDgCb3M { get; set; } = 0; // (EdRepSum Sum_Cb3_1000) // ст.м³ с начала месяца
      //public decimal ConsDgCb31000 { get; set; } = 0; // (ConsDG Cb3_1000) // ст.м³ (1000кКал/м³)
      //public decimal ConsDgCb3H { get; set; } = 0; // (ConsDG Cb3_1000 / 24) // ст.м³/час
      //public decimal ConsDgCb3UdFv { get; set; } = 0; // (ConsDgPg Ud_cons_kg_fv_Cb3) // Удельный, ст.м³/тн. шихты в ф.в.
      //public decimal ConsDgCb4M { get; set; } = 0; // (EdRepSum Sum_Cb4_1000) // ст.м³ с начала месяца
      //public decimal ConsDgCb41000 { get; set; } = 0; // (ConsDG Cb4_1000) // ст.м³ (1000кКал/м³)
      //public decimal ConsDgCb4H { get; set; } = 0; // (ConsDG Cb4_1000 / 24) // ст.м³/час
      //public decimal ConsDgCb4UdFv { get; set; } = 0; // (ConsDgPg Ud_cons_kg_fv_Cb4) // Удельный, ст.м³/тн. шихты в ф.в.

      ////Расход природного газа на разогрев
      public ConsumptionPg ConsumptionPg { get; set; }
      //public decimal ConsPgGru1Stm { get; set; } = 0; // (EdRepSum Sum_cons_pg_gru1) // ст.м³ с начала месяца
      //public decimal ConsPgGru1St { get; set; } = 0; // (ConsDgPg Cons_pg_gru1) // ст.м³ 
      //public decimal ConsPgGru1Sth { get; set; } = 0; // (ConsDgPg Cons_pg_gru1 / 24) // ст.м³/час
      //public decimal ConsPgGru1UdFv { get; set; } = 0; // (ConsDgPg Ud_cons_pg_gru1) // Удельный, ст.м³/тн. шихты в ф.в.
      //public decimal ConsPgGru2Stm { get; set; } = 0; // (EdRepSum Sum_cons_pg_gru2) // ст.м³ с начала месяца
      //public decimal ConsPgGru2St { get; set; } = 0; // (ConsDgPg Cons_pg_gru2) // ст.м³ 
      //public decimal ConsPgGru2Sth { get; set; } = 0; // (ConsDgPg Cons_pg_gru2 / 24) // ст.м³/час
      //public decimal ConsPgGru2UdFv { get; set; } = 0; // (ConsDgPg Ud_cons_pg_gru2) // Удельный, ст.м³/тн. шихты в ф.в.
   }
}
