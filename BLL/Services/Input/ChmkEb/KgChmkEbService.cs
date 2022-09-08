using BLL.DTO.Input;
using BLL.Interfaces.Service.Input;
using DA.Entities;
using DA.Interfaces;
using System;

namespace BLL.Services.Input.ChmkEb
{
   public class KgChmkEbService : IKgChmkEb
   {
      private IGasGenericRepository<KgChmkEb> Rep;
      public KgChmkEbService(IGasGenericRepository<KgChmkEb> rep)
      {
         Rep = rep;
      }
      public KgChmkEbDTO GetItemByDate(DateTime Date)
      {
         var kg = ToDTO(Rep.GetByDate(Date));
         return kg;
      }

      public bool InsertOrUpdate(KgChmkEbDTO entity)
      {
         KgChmkEb kg = Rep.GetByDate(entity.Date) ?? new KgChmkEb();
         try
         {
            kg.Date = entity.Date;
            kg.Consumption = entity.Consumption;

            if (kg.Id > 0)
            {
               Rep.Update(kg);
            }
            else
            {
               Rep.Create(kg);
            }
            return true;
         }
         catch (Exception ex)
         {
            return false;
         }
      }

      private KgChmkEbDTO ToDTO(KgChmkEb kgeb)
      {
         return new KgChmkEbDTO
         {
            Date = kgeb.Date,
            Consumption = kgeb.Consumption,
         };
      }
   }
}
