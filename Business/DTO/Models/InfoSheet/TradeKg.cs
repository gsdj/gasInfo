namespace Business.DTO.Models.InfoSheet
{
   public class TradeKg
   {
      //Товарный коксовый газ
      //Юг
      public decimal TradeKgSouthM { get; set; } = 0; // (EdRepSum Sum_out_kg_cu1) - SPO_4000 //ст.м³ с начала месяца 
      public decimal TradeKgSouth4000 { get; set; } = 0; // Out_kg_st_cu1 - SPO_4000 - GSUF_4000 //ст.м³ (4000кКал/м³)
      public decimal TradeKgSouthH { get; set; } = 0; // Trade_kg_south_4000 / 24 // ст.м³/час //ст.м³ с начала месяца 
                                                      //Север
      public decimal TradeKgNorthM { get; set; } = 0; // (EdRepSum Sum_out_kg_cu2) - Cb7_4000 - Cb8_4000
      public decimal TradeKgNorth4000 { get; set; } = 0; // Out_kg_st_cu2 - Cb7_4000 - Cb8_4000 //ст.м³ (4000кКал/м³)
      public decimal TradeKgNorthH { get; set; } = 0; // Trade_kg_north_4000 / 24 // ст.м³/час

      //ГСУФ-45
      public decimal GsufM { get; set; } = 0; // (EdRepSum Sum_gsuf_4000) // ст.м³ с начала месяца
      public decimal Gsuf4000 { get; set; } = 0; // ConsKG Gsuf_4000 // ст.м³ (4000кКал/м³)
      public decimal GsufH { get; set; } = 0; // ConsKG Gsuf_4000 / 24 // ст.м³/час
   }
}
