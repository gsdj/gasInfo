using Business.DTO.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTO.Models.Production
{
   public class CokeCbGross : CbAll
   {
      public decimal Cb1_6 => Kc1.Cb1 + Kc1.Cb2 + Kc1.Cb3 + Kc1.Cb4 + Kc2.Cb1 + Kc2.Cb2;
      public decimal Cb7_8 => Kc2.Cb3 + Kc2.Cb4;
      public decimal Tn => Cb1_6 + Cb7_8;
   }
}
