using Business.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces.Services
{
   public interface IPressureService : IGasService<PressureDTO>
   {
      void Insert(PressureDTO entity);
      void Upsert(PressureDTO entity);
   }
}
