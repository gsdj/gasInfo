using Business.DTO;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces.Calculations
{
   public interface ICalcDryGasDensity
   {
      IEnumerable<DensityDTO> CalcEntities(IEnumerable<PressureDTO> pressure, IEnumerable<CharacteristicsKgDTO> kgs, 
                                           IEnumerable<CharacteristicsDgDTO> dgs,IEnumerable<DevicesKip> kip);
      DensityDTO CalcEntity(PressureDTO pressure, CharacteristicsKgDTO kg, 
                            CharacteristicsDgDTO dg, DevicesKip kip);
      decimal DryGas(decimal pkg, decimal PPa, decimal pOver, decimal temp);
      decimal DryGas(decimal pkg, decimal PPa, decimal pOver, decimal temp, decimal tempDo);
      decimal DryGas(decimal pkg, decimal PPa, decimal pOver, decimal temp, decimal rH, decimal pMax);
   }
}
