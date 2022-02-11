using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities.Characteristics
{
   public class SteamCharacteristics
   {
      public int Id { get; set; }
      public int Temp { get; set; }
      public decimal Pmm { get; set; }
      public decimal Pgm { get; set; }
      public decimal Ptopp { get; set; }
   }
}
