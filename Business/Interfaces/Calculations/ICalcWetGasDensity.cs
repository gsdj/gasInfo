using Business.DTO;
using Business.DTO.Characteristics;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces.Calculations
{
   public interface ICalcWetGasDensity
   {
      IEnumerable<DensityDTO> CalcEntities(IEnumerable<DensityDTO> dryGas, IEnumerable<DevicesKip> kip, Dictionary<int, SteamCharacteristicsDTO> steam);
      DensityDTO CalcEntity(DensityDTO dryGas, DevicesKip kip);
      decimal WetGas(decimal dryGas, decimal temp);
   }
}
