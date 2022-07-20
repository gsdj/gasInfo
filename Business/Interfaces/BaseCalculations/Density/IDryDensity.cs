namespace Business.Interfaces.BaseCalculations.Density
{
   public interface IDryDensity
   {
      ISteamCharacteristicsService SteamCharacteristicsService { get; set; }
      decimal Calc(decimal pkg, decimal PPa, decimal pOver, decimal temp);
      decimal Calc(decimal pkg, decimal PPa, decimal pOver, decimal temp, decimal tempDo);
      decimal Calc(decimal pkg, decimal PPa, decimal pOver, decimal temp, decimal rH, decimal pMax);
   }
}
