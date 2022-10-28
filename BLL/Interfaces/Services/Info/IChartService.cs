using BLL.DTO.Charts;
using System;
using System.Collections.Generic;

namespace BLL.Interfaces.Services.Info
{
   public interface IChartService : IChartMonth<ChartMonthDTO>, IChartYear<ChartYearDTO> { }
   public interface IChartMonth<T>
   {
      IEnumerable<T> GasOutputPerMonth(DateTime Date);
   }
   public interface IChartYear<T>
   {
      IEnumerable<T> GasYearlyComparison(DateTime Date);
   }

}
