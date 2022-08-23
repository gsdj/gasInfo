namespace BLL.Interfaces.BaseCalculations
{
   public interface IAvgComponents<T,TResult>
   {
      TResult Calc(T obj);
   }
}
