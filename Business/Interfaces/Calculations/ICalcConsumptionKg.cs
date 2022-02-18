using Business.DTO;
using Business.DTO.Characteristics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces.Calculations
{
   public interface ICalcConsumptionKg
   {
      IEnumerable<ConsumptionKgDTO> CalcEntities(IEnumerable<DensityDTO> wetGas, IEnumerable<DevicesKipDTO> kips, 
         IEnumerable<CharacteristicsKgDTO> charKgs, Dictionary<int, SteamCharacteristicsDTO> steam);
      ConsumptionKgDTO CalcEntity(DensityDTO wetGas, DevicesKipDTO kip, CharacteristicsKgDTO charKg);
      decimal QcRc(decimal cons, decimal wetGas, decimal temp, decimal density, bool perHour = false);
      decimal Qn4000(decimal qcrc, decimal qn);
   }
}
