namespace Business.DTO.Characteristics.CharacteristicsGas
{
   public class CharacteristicsKG 
   {
      public CharacteristicsKG()
      {
         Components = new KGasComponents();
         Characteristics = new CharacteristicsGas();
      }
      public KGasComponents Components { get; set; }
      public decimal SumComponents { get; set; }
      public CharacteristicsGas Characteristics { get; set; }
   }
}
