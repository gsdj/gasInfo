namespace Business.Interfaces.BaseCalculations
{
   public interface ISumComponents
   {
      decimal Calc(params decimal[] components);
   }
}
