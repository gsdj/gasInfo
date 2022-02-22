using Business.BusinessModels;
using Business.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces.Calculations
{
   public interface ICalcInfoSheet
   {
      InfoSheetDTO CalcInfo(InfoSheetData data);
   }
}
