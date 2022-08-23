using BLL.Models.BaseModels.Characteristics.Quality;
using DA.Entities;
using System.Collections.Generic;

namespace BLL.Interfaces.Calculations
{
   public interface ICalcQuality
   {
      IEnumerable<QualityCharacteristics> CalcEntities(IEnumerable<QualityAll> qual, IEnumerable<CharacteristicsKgAll> kgs);
      QualityCharacteristics CalcEntity(QualityAll qual, CharacteristicsKgAll kg);
   }
}
