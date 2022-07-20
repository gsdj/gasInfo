namespace Business.DTO.Models.Components
{
   public class GasComponents
   {
      public decimal CO2 { get; set; }
      public decimal CO { get; set; }
      public decimal N2 { get; set; }
      public decimal H2 { get; set; }
   }
   public class KGasComponents : GasComponents
   {
      public decimal O2 { get; set; }
      public decimal CnHm { get; set; }
      public decimal CH4 { get; set; }
   }
}
