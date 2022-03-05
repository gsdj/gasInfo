using Business.DTO;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.BusinessModels.DataForCalculations
{
   public abstract class Data
   {
   }
   public class QualityData : Data
   {
      public QualityAll Qualities;
      public CharacteristicsKgDTO Kg;
   }
}
