using Business.BusinessModels.DataForCalculations;
using Business.DTO;

namespace Business.Interfaces.Calculations
{
   public interface ICalcInfoSheet
   {
      InfoSheetDTO CalcInfo(InfoSheetData data);
   }
}
