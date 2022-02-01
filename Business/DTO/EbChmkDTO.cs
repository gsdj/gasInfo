using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTO
{
   public class EbChmkDTO
   {
      public DateTime Date { get; set; }
      public decimal ConsDgKb1 { get; set; }
      public decimal ConsDgKb2 { get; set; }
      public decimal ConsDgKb3 { get; set; }
      public decimal ConsDgKb4 { get; set; }
      public decimal ConsDgKc1 { get; set; }
      public int UdConsKb1 { get; set; }
      public int UdConsKb2 { get; set; }
      public int UdConsKb3 { get; set; }
      public int UdConsKb4 { get; set; }
      public int UdConsKc1 { get; set; }
      public decimal ConsPgGru1 { get; set; }
      public decimal ConsPgGru2 { get; set; }
      public decimal ConsPgUpc { get; set; }
      public decimal UdConsGru1 { get; set; }
      public decimal UdConsGru2 { get; set; }
   }
}
