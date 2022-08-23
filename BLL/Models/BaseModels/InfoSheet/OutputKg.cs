namespace BLL.Models.BaseModels.InfoSheet
{
   public class OutputKg
   {
      //Выход коксового газа
      //ЦУ1 ст.м³ с начала месяца
      public decimal OutKgUdSvCu1 { get; set; } = 0; // Удельный, ст.м³/тн. шихты в с.в.
      public decimal OutKgStCu1 { get; set; } = 0; // ст.м³ (4000кКал/м³)
      public decimal OutKgSthCu1 { get; set; }// => (OutKgStCu1 == 0) ? 0 : Math.Round((OutKgStCu1 / 24), 2); // ст.м³/час
      public decimal SumOutKgCu1 { get; set; } = 0;

      //ЦУ2
      public decimal OutKgUdSvCu2 { get; set; } = 0; // Удельный, ст.м³/тн. шихты в с.в.
      public decimal OutKgStCu2 { get; set; } = 0; // ст.м³ (4000кКал/м³)
      public decimal OutKgSthCu2 { get; set; }//=> (OutKgStCu2 == 0) ? 0 : Math.Round((OutKgStCu2 / 24), 2); // ст.м³/час
      public decimal SumOutKgCu2 { get; set; } = 0;

      //МК
      public decimal OutKgUdSvMk { get; set; } = 0;
      public decimal OutKgStMk { get; set; }//=> Math.Round((OutKgStCu1 + OutKgStCu2), 2); // ст.м³ (4000кКал/м³)
      public decimal OutKgSthMk { get; set; }//=> (OutKgStMk == 0) ? 0 : Math.Round((OutKgStMk / 24), 2); // ст.м³/час
      public decimal SumOutKgMk { get; set; }//=> Math.Round((SumOutKgCu1 + SumOutKgCu2), 2);

      //Удельный выход коксового газа
      public decimal UdOutKgTradeChmk { get; set; } = 0; //по товарному КГ ЭБ "ЧМК" (ReportKg Ud_out_sh_mk)
      public decimal UdOutKgTradeAsdue { get; set; } = 0; //по товарному КГ АСДУЭ приведение кал. "М-К"
      public decimal UdOutKgTradeTheor { get; set; } = 0; //Теоретический
      public decimal UdOutKgOperMk { get; set; } = 0; //по оперативному учету МК
      public decimal PgQnm { get; set; } = 0; //Характеристики отопительных газов (Природный газ)
   }
}
