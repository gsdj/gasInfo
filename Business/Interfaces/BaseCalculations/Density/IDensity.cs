namespace Business.Interfaces.BaseCalculations.Density
{
   public interface IDensity<T>
   {
      /// <summary>
      /// Плотность газа
      /// </summary>
      /// <param name="obj"></param>
      /// <returns></returns>
      decimal Calc(T obj);
   }
}
