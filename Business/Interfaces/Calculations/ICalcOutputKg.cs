using Business.DTO;
using Business.DTO.Characteristics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces.Calculations
{
   public interface ICalcOutputKg
   {
      IEnumerable<OutputKgDTO> CalcEntities(IEnumerable<DensityDTO> wetGas, IEnumerable<ProductionDTO> prod,
                                             IEnumerable<DevicesKipDTO> kips, IEnumerable<CharacteristicsKgDTO> charKgs, 
                                             Dictionary<int, SteamCharacteristicsDTO> steam);
      OutputKgDTO CalcEntity(DensityDTO wetGas, ProductionDTO prod,
                              DevicesKipDTO kip, CharacteristicsKgDTO charKg);
      decimal QcRc(decimal cons, decimal wetGas, decimal temp, decimal density);
      decimal Qn4000(decimal qcrc, decimal qn);
      //decimal Qn4000WithCoeff(decimal qcrc, decimal qn,decimal coeff);
   }
}
