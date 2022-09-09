using BLL.DTO.Components;
using BLL.Interfaces.Services.Input;
using DA.Entities;
using DA.Interfaces;
using System;

namespace BLL.Services.Input
{
   public class QualityService : IQualityService
   {
      private IGasGenericRepository<QualityAll> QualityRep;
      public QualityService(IGasGenericRepository<QualityAll> rep)
      {
         QualityRep = rep;
      }

      public QualityComponentsDTO GetItemByDate(DateTime Date)
      {
         var qual = QualityRep.GetByDate(Date);
         return ToDTO(qual);
      }

      public bool InsertOrUpdate(QualityComponentsDTO entity)
      {
         QualityAll qc = QualityRep.GetByDate(entity.Date) ?? new QualityAll();
         try
         {
            qc.Date = entity.Date;
            qc.Kc1.W = entity.Kc1.W;
            qc.Kc1.A = entity.Kc1.A;
            qc.Kc1.V = entity.Kc1.V;
            qc.Kc2.W = entity.Kc2.W;
            qc.Kc2.A = entity.Kc2.A;
            qc.Kc2.V = entity.Kc2.V;

            if (qc.Id > 0)
            {
               QualityRep.Update(qc);
            }
            else
            {
               QualityRep.Create(qc);
            }
            return true;
         }
         catch (Exception ex)
         {
            return false;
         }
      }

      private QualityComponentsDTO ToDTO(QualityAll qc)
      {
         return new QualityComponentsDTO
         {
            Date = qc.Date,
            Kc1 =
            {
               W = qc.Kc1.W,
               A = qc.Kc1.A,
               V = qc.Kc1.V,
            },
            Kc2 =
            {
               W = qc.Kc2.W,
               A = qc.Kc2.A,
               V = qc.Kc2.V,
            }
         };
      }
   }
}
