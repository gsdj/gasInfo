using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTO
{
   public class OutputKgDTO
   {
      public DateTime Date { get; set; }
      public decimal QcRcCu1 { get; set; }
      public decimal Cu14000 { get; set; }
      public decimal Cu1Cb16 { get; set; }
      public decimal QcRcCu2 { get; set; }
      public decimal Cu24000 { get; set; }
      public decimal Cu2Cb78 { get; set; }
      public decimal PrMk { get; set; } //=> Math.Round((QcRcCu1 + QcRcCu2), 10);
      public decimal PrMk4000 { get; set; } //=> Math.Round((Cu14000 + Cu24000), 10);
      public decimal OutCgSh { get; set; } //=> Math.Round((PrMk4000 == 0 || ConsMkSh == 0) ? 0 : (PrMk4000 / ConsMkSh), 10);
   }
}
