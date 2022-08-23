using BLL.Interfaces.Services;

namespace BLL.Interfaces.BaseCalculations
{
   public interface IQcRc
   {
      ISteamCharacteristicsService SteamCharacteristicsService { get; set; }
      decimal Calc(decimal cons, decimal wetGas, decimal temp, decimal density, bool perHour = false);
   }
}
