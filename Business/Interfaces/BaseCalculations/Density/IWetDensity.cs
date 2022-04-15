
namespace Business.Interfaces.BaseCalculations.Density
{
   public interface IWetDensity
   {
      ISteamCharacteristicsService SteamCharacteristicsService { get; set; }
      decimal Calc(decimal dryGas, decimal temp);
   }
}
