using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
   public class Constants
   {
      /// <summary>
      /// коэффициент избыточного давления KipDevices.press * 9.80665
      /// </summary>
      public decimal PexcC { get; set; }
      /// <summary>
      /// давление при стандартных условиях, = 760 мм.рт.ст.
      /// </summary>
      public decimal Pc { get; set; }
      /// <summary>
      /// температура газа в газопроводе, при рабочих условиях 273.15 + KipDevices.temp
      /// </summary>
      public decimal TpC { get; set; }
      /// <summary>
      /// температура стандартных условий 293,15К
      /// </summary>
      public decimal Tc { get; set; }
      /// <summary>
      /// коэффициент сжимаемости газа принимается равным - 1,0
      /// </summary>
      public decimal K { get; set; }
      /// <summary>
      /// коэффициент расчета Пр-ва кокса сух.
      /// </summary>
      public decimal Kb18C { get; set; }
      /// <summary>
      /// коэффициент расчета СПО,переработка КУС
      /// </summary>
      public decimal SpoC { get; set; }
      /// <summary>
      /// коэффициент удельного расхода ДГ
      /// </summary>
      public decimal UdDgC { get; set; }
      /// <summary>
      /// коэффициент удельного расхода ПГ
      /// </summary>
      public decimal UdPgC { get; set; }
      /// <summary>
      /// Коэфициент пропорциональности(3-3,3)
      /// </summary>
      public decimal PropC { get; set; }
      /// <summary>
      /// Коэффициент расчета удельного расхода кгУТ/тн шихты в ф.в. (на тн.КУС)
      /// </summary>
      public decimal ConsFvC { get; set; }
   }
}
