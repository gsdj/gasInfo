using Business.BusinessModels;
using Business.BusinessModels.DataForCalculations;
using Business.DTO;
using Business.Interfaces;
using Business.Interfaces.Calculations;
using Business.Interfaces.Services;
using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Input
{
   public class QualityService : IQualityService
   {
      IUnitOfWork db;
      ICalculations<QualityDTO> _qual;
      ICalcCharacteristicsKg CalcKg;
      public QualityDTO GetItemByDate(DateTime Date)
      {
         throw new NotImplementedException();
      }

      public bool Upsert(QualityDTO entity)
      {
         throw new NotImplementedException();
      }
   }
}
