using Business.DTO;
using Business.DTO.Characteristics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces.Calculations
{
   public interface ICalcConsumptionDgPg
   {
      IEnumerable<ConsumptionDgPgDTO> CalcEntities(IEnumerable<DensityDTO> wetGas, IEnumerable<DevicesKipDTO> kips, 
                                                   IEnumerable<ProductionDTO> prod, IEnumerable<CharacteristicsDgDTO> charDgs,
                                                   IEnumerable<PressureDTO> pressure, Dictionary<int, SteamCharacteristicsDTO> steam);
      ConsumptionDgPgDTO CalcEntity(DensityDTO wetGas, DevicesKipDTO kip, ProductionDTO prod, 
                                    CharacteristicsDgDTO charDg, PressureDTO pressure);
      decimal QcRc(decimal cons, decimal wetGas, decimal temp, decimal density);
      decimal Qn1000(decimal qcrc, decimal qn);
      decimal ConsPg(decimal cons, decimal PPa, decimal pressure, decimal temp);
      /// <summary>
      /// Расход природного газа по батареям
      /// </summary>
      /// <param name="consDg">Расход ДГ</param>
      /// <param name="consPgKc">Расход ПГ в КЦ</param>
      /// <param name="kcSum">Расход ДГ общий</param>
      /// <returns></returns>
      decimal ConsPgCb(decimal consDg, decimal consPgKc, decimal kcSum);
      /// <summary>
      /// Удельный расход дг УТ/тн шихты в ф.в.
      /// </summary>
      /// <param name="consDg">Расход ДГ</param>
      /// <param name="consPg">Расход ПГ</param>
      /// <param name="consFv">Расход в ФВ</param>
      /// <returns></returns>
      decimal UdConsDgFv(decimal consDg, decimal consPg, decimal consFv);
   }
}
