using BLL.DataHelpers;

namespace BLL.Interfaces.Calculations
{
   public interface ICalculation<T>
   {
      T CalcEntity(Data data);
   }
}
