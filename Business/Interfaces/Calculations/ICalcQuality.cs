using Business.DTO;
using DataAccess.Entities;
using System.Collections.Generic;

namespace Business.Interfaces.Calculations
{
   public interface ICalcQuality
   {
      IEnumerable<QualityDTO> CalcEntities(IEnumerable<QualityAll> qual, IEnumerable<CharacteristicsKgAll> kgs);
      QualityDTO CalcEntity(QualityAll qual, CharacteristicsKgAll kg);
   }
}
