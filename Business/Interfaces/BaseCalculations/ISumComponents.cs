namespace Business.Interfaces.BaseCalculations
{
   public interface ISumComponents
   {
      decimal Calc(params decimal[] components);
   }
   //public interface ISumComponentsObj
   //{
   //   decimal Calc(object obj);
   //}
}
