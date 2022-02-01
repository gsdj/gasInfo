using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTO
{
   public class InfoSheetDTO
   {
      public DateTime Date { get; private set; }
      public decimal AvgMkDGQn { get; private set; } = 0;
      public decimal AvgMkDgPkg { get; private set; } = 0;
      public decimal Cu1Qn { get; private set; } = 0;
      public decimal Cu1Pkg { get; private set; } = 0;
      public decimal Cu2Qn { get; private set; } = 0;
      public decimal Cu2Pkg { get; private set; } = 0;

      //Выход коксового газа
      //ЦУ1 ст.м³ с начала месяца
      public decimal OutKgUdSvCu1 { get; private set; } = 0; // Удельный, ст.м³/тн. шихты в с.в.
      public decimal OutKgStCu1 { get; private set; } = 0; // ст.м³ (4000кКал/м³)
      public decimal OutKgSthCu1 => (OutKgStCu1 == 0) ? 0 : Math.Round((OutKgStCu1 / 24), 2); // ст.м³/час
      public decimal SumOutKgCu1 { get; private set; } = 0;

      //ЦУ2
      public decimal OutKgUdSvCu2 { get; private set; } = 0; // Удельный, ст.м³/тн. шихты в с.в.
      public decimal OutKgStCu2 { get; private set; } = 0; // ст.м³ (4000кКал/м³)
      public decimal OutKgSthCu2 => (OutKgStCu2 == 0) ? 0 : Math.Round((OutKgStCu2 / 24), 2); // ст.м³/час
      public decimal SumOutKgCu2 { get; private set; } = 0;

      //МК
      public decimal OutKgUdSvMk { get; private set; } = 0;
      public decimal OutKgStMk => Math.Round((OutKgStCu1 + OutKgStCu2), 2); // ст.м³ (4000кКал/м³)
      public decimal OutKgSthMk => (OutKgStMk == 0) ? 0 : Math.Round((OutKgStMk / 24), 2); // ст.м³/час
      public decimal SumOutKgMk => Math.Round((SumOutKgCu1 + SumOutKgCu2), 2);

      //Удельный выход коксового газа
      public decimal UdOutKgTradeChmk { get; private set; } = 0; //по товарному КГ ЭБ "ЧМК" (ReportKg Ud_out_sh_mk)
      public decimal UdOutKgTradeAsdue { get; private set; } = 0; //по товарному КГ АСДУЭ приведение кал. "М-К"
      public decimal UdOutKgTradeTheor { get; private set; } = 0; //Теоретический
      public decimal UdOutKgOperMk { get; private set; } = 0; //по оперативному учету МК
      public decimal PgQnm { get; private set; } = 0; //Характеристики отопительных газов (Природный газ)

      //Расход КГ на обогрев
      public decimal ConsKgObUdSvCb5 { get; private set; } = 0;
      public decimal ConsKgObUdSvCb6 { get; private set; } = 0;
      public decimal ConsKgObUdSvCb7 { get; private set; } = 0;
      public decimal ConsKgObUdSvCb8 { get; private set; } = 0;
      public decimal ConsKgObUdSvSpo { get; private set; } = 0;
      public decimal ConsKgObUdSvPko { get; private set; } = 0;
      public decimal ConsKgObUdSvCpsppk { get; private set; } = 0;

      public decimal ConsKgObStCb5 { get; private set; } = 0;
      public decimal ConsKgObStCb6 { get; private set; } = 0;
      public decimal ConsKgObStCb7 { get; private set; } = 0;
      public decimal ConsKgObStCb8 { get; private set; } = 0;
      public decimal ConsKgObStSpo { get; private set; } = 0;
      public decimal ConsKgObStPko { get; private set; } = 0;
      public decimal ConsKgObStCpsppk { get; private set; } = 0;
      public decimal ConsKgObStMk { get; private set; } = 0;

      public decimal ConsKgObSthCb5 => (ConsKgObStCb5 == 0) ? 0 : Math.Round((ConsKgObStCb5 / 24), 2);
      public decimal ConsKgObSthCb6 => (ConsKgObStCb6 == 0) ? 0 : Math.Round((ConsKgObStCb6 / 24), 2);
      public decimal ConsKgObSthCb7 => (ConsKgObStCb7 == 0) ? 0 : Math.Round((ConsKgObStCb7 / 24), 2);
      public decimal ConsKgObSthCb8 => (ConsKgObStCb8 == 0) ? 0 : Math.Round((ConsKgObStCb8 / 24), 2);
      public decimal ConsKgObSthSpo => (ConsKgObStSpo == 0) ? 0 : Math.Round((ConsKgObStSpo / 24), 2);
      public decimal ConsKgObSthPko => (ConsKgObStPko == 0) ? 0 : Math.Round((ConsKgObStPko / 24), 2);
      public decimal ConsKgObSthCpsppk => (ConsKgObStCpsppk == 0) ? 0 : Math.Round((ConsKgObStCpsppk / 24), 2);
      public decimal ConsKgObSthMk => (ConsKgObStMk == 0) ? 0 : Math.Round((ConsKgObStMk / 24), 2);

      public decimal SumConsKgCb5 { get; private set; } = 0;
      public decimal SumConsKgCb6 { get; private set; } = 0;
      public decimal SumConsKgCb7 { get; private set; } = 0;
      public decimal SumConsKgCb8 { get; private set; } = 0;
      public decimal SumConsKgSpo { get; private set; } = 0;
      public decimal SumConsKgPko { get; private set; } = 0;
      public decimal SumConsKgCpsppk { get; private set; } = 0;
      public decimal SumConsKgMk { get; private set; } = 0;

      //Товарный коксовый газ
      //Юг
      public decimal TradeKgSouthM { get; private set; } = 0; // (EdRepSum Sum_out_kg_cu1) - SPO_4000 //ст.м³ с начала месяца 
      public decimal TradeKgSouth4000 { get; private set; } = 0; // Out_kg_st_cu1 - SPO_4000 - GSUF_4000 //ст.м³ (4000кКал/м³)
      public decimal TradeKgSouthH { get; private set; } = 0; // Trade_kg_south_4000 / 24 // ст.м³/час //ст.м³ с начала месяца 
                                                              //Север
      public decimal TradeKgNorthM { get; private set; } = 0; // (EdRepSum Sum_out_kg_cu2) - Cb7_4000 - Cb8_4000
      public decimal TradeKgNorth4000 { get; private set; } = 0; // Out_kg_st_cu2 - Cb7_4000 - Cb8_4000 //ст.м³ (4000кКал/м³)
      public decimal TradeKgNorthH { get; private set; } = 0; // Trade_kg_north_4000 / 24 // ст.м³/час

      //ГСУФ-45
      public decimal GsufM { get; private set; } = 0; // (EdRepSum Sum_gsuf_4000) // ст.м³ с начала месяца
      public decimal Gsuf4000 { get; private set; } = 0; // ConsKG Gsuf_4000 // ст.м³ (4000кКал/м³)
      public decimal GsufH { get; private set; } = 0; // ConsKG Gsuf_4000 / 24 // ст.м³/час

      //Расход доменного газа на обогрев (Оценочный, приведение "М-К")
      public decimal ConsDgCb1M { get; private set; } = 0; // (EdRepSum Sum_Cb1_1000) // ст.м³ с начала месяца
      public decimal ConsDgCb11000 { get; private set; } = 0; // (ConsDG Cb1_1000) // ст.м³ (1000кКал/м³)
      public decimal ConsDgCb1H { get; private set; } = 0; // (ConsDG Cb1_1000 / 24) // ст.м³/час
      public decimal ConsDgCb1UdFv { get; private set; } = 0; // (ConsDgPg Ud_cons_kg_fv_Cb1) // Удельный, ст.м³/тн. шихты в ф.в.
      public decimal ConsDgCb2M { get; private set; } = 0; // (EdRepSum Sum_Cb2_1000) // ст.м³ с начала месяца
      public decimal ConsDgCb21000 { get; private set; } = 0; // (ConsDG Cb2_1000) // ст.м³ (1000кКал/м³)
      public decimal ConsDgCb2H { get; private set; } = 0; // (ConsDG Cb2_1000 / 24) // ст.м³/час
      public decimal ConsDgCb2UdFv { get; private set; } = 0; // (ConsDgPg Ud_cons_kg_fv_Cb2) // Удельный, ст.м³/тн. шихты в ф.в.
      public decimal ConsDgCb3M { get; private set; } = 0; // (EdRepSum Sum_Cb3_1000) // ст.м³ с начала месяца
      public decimal ConsDgCb31000 { get; private set; } = 0; // (ConsDG Cb3_1000) // ст.м³ (1000кКал/м³)
      public decimal ConsDgCb3H { get; private set; } = 0; // (ConsDG Cb3_1000 / 24) // ст.м³/час
      public decimal ConsDgCb3UdFv { get; private set; } = 0; // (ConsDgPg Ud_cons_kg_fv_Cb3) // Удельный, ст.м³/тн. шихты в ф.в.
      public decimal ConsDgCb4M { get; private set; } = 0; // (EdRepSum Sum_Cb4_1000) // ст.м³ с начала месяца
      public decimal ConsDgCb41000 { get; private set; } = 0; // (ConsDG Cb4_1000) // ст.м³ (1000кКал/м³)
      public decimal ConsDgCb4H { get; private set; } = 0; // (ConsDG Cb4_1000 / 24) // ст.м³/час
      public decimal ConsDgCb4UdFv { get; private set; } = 0; // (ConsDgPg Ud_cons_kg_fv_Cb4) // Удельный, ст.м³/тн. шихты в ф.в.

      //Расход природного газа на разогрев
      public decimal ConsPgGru1Stm { get; private set; } = 0; // (EdRepSum Sum_cons_pg_gru1) // ст.м³ с начала месяца
      public decimal ConsPgGru1St { get; private set; } = 0; // (ConsDgPg Cons_pg_gru1) // ст.м³ 
      public decimal ConsPgGru1Sth { get; private set; } = 0; // (ConsDgPg Cons_pg_gru1 / 24) // ст.м³/час
      public decimal ConsPgGru1UdFv { get; private set; } = 0; // (ConsDgPg Ud_cons_pg_gru1) // Удельный, ст.м³/тн. шихты в ф.в.
      public decimal ConsPgGru2Stm { get; private set; } = 0; // (EdRepSum Sum_cons_pg_gru2) // ст.м³ с начала месяца
      public decimal ConsPgGru2St { get; private set; } = 0; // (ConsDgPg Cons_pg_gru2) // ст.м³ 
      public decimal ConsPgGru2Sth { get; private set; } = 0; // (ConsDgPg Cons_pg_gru2 / 24) // ст.м³/час
      public decimal ConsPgGru2UdFv { get; private set; } = 0; // (ConsDgPg Ud_cons_pg_gru2) // Удельный, ст.м³/тн. шихты в ф.в.
   }
}
