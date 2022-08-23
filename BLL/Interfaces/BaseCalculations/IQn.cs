namespace BLL.Interfaces.BaseCalculations
{
   public interface IQn<T>
   {
      /// <summary>
      /// Калорийность газа
      /// </summary>
      /// <param name="obj"></param>
      /// <returns></returns>
      decimal Calc(T obj);
   }
}
