namespace BLL.Constants
{
   public static class GasConstants
   {
      /// <summary>
      /// коэффициент избыточного давления KipDevices.press * 9.80665
      /// </summary>
      public const decimal PexcC = 9.80665m;
      /// <summary>
      /// давление при стандартных условиях, = 760 мм.рт.ст.
      /// </summary>
      public const decimal Pc = 101324.72m;
      /// <summary>
      /// температура газа в газопроводе, при рабочих условиях 273.15 + KipDevices.temp
      /// </summary>
      public const decimal TpC = 273.15m;
      /// <summary>
      /// температура стандартных условий 293,15К
      /// </summary>
      public const decimal Tc = 293.15m;
      /// <summary>
      /// коэффициент сжимаемости газа принимается равным - 1,0
      /// </summary>
      public const decimal K = 1m;
      /// <summary>
      /// коэффициент расчета Пр-ва кокса сух.
      /// </summary>
      public const decimal Kb18C = 0.94m;
      /// <summary>
      /// коэффициент расчета СПО,переработка КУС
      /// </summary>
      public const decimal SpoC = 1.228m;
      /// <summary>
      /// коэффициент удельного расхода ДГ
      /// </summary>
      public const decimal UdDgC = 0.143m;
      /// <summary>
      /// коэффициент удельного расхода ПГ
      /// </summary>
      public const decimal UdPgC = 1.143m;
      /// <summary>
      /// Коэфициент пропорциональности(3-3,3)
      /// </summary>
      public const decimal PropC = 3.15m;
      /// <summary>
      /// Коэффициент расчета удельного расхода кгУТ/тн шихты в ф.в. (на тн.КУС)
      /// </summary>
      public const decimal ConsFvC = 0.57m;
   }
}
