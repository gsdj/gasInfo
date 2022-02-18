using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTO
{
   public class ProductionDTO
   {
      //Коэффициенты/выхода
      public decimal SvC { get; set; }
      public decimal FvC { get; set; }
      public decimal KpeC { get; set; }

      public DateTime Date { get; set; }
      public int Cb1 { get; set; }
      public int Cb2 { get; set; }
      public int Cb3 { get; set; }
      public int Cb4 { get; set; }
      public int Cb5 { get; set; }
      public int Cb6 { get; set; }
      public int Cb7 { get; set; }
      public int Cb8 { get; set; }
      public int PKP { get; set; }

      public int Cb1Cb2 { get; set; }// => (Cb1 + Cb2);
      public int Cb3Cb4 { get; set; }// => (Cb3 + Cb4);
      public int Cb5Cb6 { get; set; }// => (Cb5 + Cb6);
      public int Cb7Cb8 { get; set; }// => (Cb7 + Cb8);
      public int Cb1Cb6 { get; set; }// => (Cb1Cb2 + Cb3Cb4 + Cb5Cb6);
      public int MK { get; set; }// => (Cb1Cb6 + Cb7Cb8);

      //Про-во кокса вал.
      public decimal Cb16Val { get; set; }
      public decimal Cb78Val { get; set; }
      public decimal CbTnVal { get; set; }// => Cb16Val + Cb78Val;

      //Про-во кокса сух.
      public decimal Cb16Dry { get; set; }// => Math.Round((Cb16Val * Cb18C), 4);
      public decimal Cb78Dry { get; set; }// => Math.Round((Cb78Val * Cb18C), 4);
      public decimal TnDry { get; set; }// => (Cb16Dry + Cb78Dry);
      public decimal KpeDry { get; set; }

      //Расход шихты сух.
      public decimal Cb16ConsDry { get; set; } //=> Math.Round((Cb16Suh * Sv_k), 7);
      public decimal Cb78ConsDry { get; set; } //=> Math.Round((Cb78Suh * Sv_k), 7);
      public decimal TnConsDry { get; set; }// => (Cb16ConsDry + Cb78ConsDry);

      //Расход шихты в ф.в.
      public decimal Cb1ConsFv { get; set; }
      public decimal Cb2ConsFv { get; set; }
      public decimal Cb3ConsFv { get; set; }
      public decimal Cb4ConsFv { get; set; }
      public decimal Cb5ConsFv { get; set; }
      public decimal Cb6ConsFv { get; set; }
      public decimal Cb7ConsFv { get; set; }
      public decimal Cb8ConsFv { get; set; }

      //Расход шихты в с.в.
      public decimal Cb16Sv { get; set; }// => Cb16ConsDry;
      public decimal Cb78Sv { get; set; }// => Cb78ConsDry;

      //СПО, переработка КУС
      public decimal PkoKpe { get; set; }
      public decimal SpoPerKus { get; set; } //=> (PkoKpe == 0 || KpeSuh == 0) ? 0 : ((KpeSuh * SpoC) / PkoKpe);
   }
}
