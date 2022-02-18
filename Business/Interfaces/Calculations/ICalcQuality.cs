using Business.DTO;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces.Calculations
{
   public interface ICalcQuality
   {
      IEnumerable<QualityDTO> CalcEntities(IEnumerable<QualityAll> qualityAll, IEnumerable<CharacteristicsKgDTO> charKgs);
      QualityDTO CalcEntity(QualityAll quality, CharacteristicsKgDTO charKg);
      decimal Vc(decimal V, decimal A);
      decimal KgFv(decimal V, decimal A, decimal W);
      decimal KgFh(decimal V, decimal A, decimal W, decimal density);
   }
}
