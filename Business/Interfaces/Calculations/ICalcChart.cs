using Business.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces.Calculations
{
   public interface ICalcChart<T>
   {
      IEnumerable<T> CalcEntities(IEnumerable<ProductionDTO> prod, IEnumerable<CharacteristicsKgDTO> charKg, 
                                    IEnumerable<QualityDTO> quality, IEnumerable<OutputKgDTO> outputKg, 
                                    IEnumerable<ConsumptionKgDTO> consKg, IEnumerable<AsdueDTO> asdue, IEnumerable<KgChmkEbDTO> kgChmk);
      T CalcEntity(ProductionDTO prod, CharacteristicsKgDTO charKg, QualityDTO quality, 
                     OutputKgDTO outputKg,ConsumptionKgDTO consKg, AsdueDTO asdue, KgChmkEbDTO kgChmk);
   }
}
