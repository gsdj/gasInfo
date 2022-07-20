using Business.DTO.Models.Characteristics.Quality;
using DataAccess.Entities;
using System.Collections.Generic;

namespace Business.Interfaces.Calculations
{
   public interface ICalcQuality
   {
      IEnumerable<QualityCharacteristics> CalcEntities(IEnumerable<QualityAll> qual, IEnumerable<CharacteristicsKgAll> kgs);
      QualityCharacteristics CalcEntity(QualityAll qual, CharacteristicsKgAll kg);
   }
}
