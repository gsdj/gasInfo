using Business.BusinessModels.DataForCalculations;

namespace Business.Interfaces.Calculations
{
   public interface ICalculation<T>
   {
      T CalcEntity(Data data);
   }
}
