using Business.DTO;
using Business.DTO.Characteristics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces.Calculations
{
   public interface ICalcConsumptionDg
   {
      IEnumerable<ConsumptionDgDTO> CalcEntities(IEnumerable<DensityDTO> wetGas, IEnumerable<DevicesKipDTO> kips, 
         IEnumerable<CharacteristicsDgDTO> charDgs, Dictionary<int, SteamCharacteristicsDTO> steam);
      ConsumptionDgDTO CalcEntity(DensityDTO wetGas, DevicesKipDTO kip, CharacteristicsDgDTO charDg);
      decimal QcRc(decimal cons, decimal wetGas, decimal temp, decimal density);
      decimal Qn1000(decimal qcrc, decimal qn);
   }
}
