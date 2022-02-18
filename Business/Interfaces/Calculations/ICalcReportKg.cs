using Business.DTO;
using Business.DTO.Characteristics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces.Calculations
{
   public interface ICalcReportKg
   {
      IEnumerable<ReportKgDTO> CalcEntities(IEnumerable<ProductionDTO> prod,IEnumerable<ConsumptionKgDTO> consKg,
                                             IEnumerable<DevicesKipDTO> kips, IEnumerable<CharacteristicsKgDTO> charKgs,
                                             IEnumerable<OutputKgDTO> outputKg, IEnumerable<TecDTO> tec);
      ReportKgDTO CalcEntity(ProductionDTO prod, ConsumptionKgDTO consKg, OutputKgDTO outputKg,
                              DevicesKipDTO kip, CharacteristicsKgDTO charKg, TecDTO tec);
      decimal UdConsKgFv(decimal consKg, decimal consKgFv);
   }
}
