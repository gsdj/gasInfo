using BLL.DataHelpers;
using BLL.DTO;

namespace BLL.Interfaces.Calculations
{
   public interface ICalcInfoSheet
   {
      InfoSheetDTO CalcInfo(InfoSheetData data);
   }
}
