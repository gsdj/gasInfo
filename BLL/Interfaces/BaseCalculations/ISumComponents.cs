namespace BLL.Interfaces.BaseCalculations
{
   public interface ISumComponents
   {
      decimal Calc(params decimal[] components);
   }
}
