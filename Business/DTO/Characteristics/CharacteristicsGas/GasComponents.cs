using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTO.Characteristics.CharacteristicsGas
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
