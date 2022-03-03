using Business.DTO;
using Business.Interfaces.Services;
using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
   public class ReportKgService : IReportKgService
   {
      IUnitOfWork Db;
      IProductionService Production;
      public ReportKgService(IUnitOfWork uof, IProductionService prodServ)
      {
         Production = prodServ;
      }
      public IEnumerable<ReportKgDTO> GetItemsByMonth(DateTime Date)
      {
         throw new NotImplementedException();
      }

      public IEnumerable<ReportKgDTO> GetItemsByNowMonth()
      {
         throw new NotImplementedException();
      }
   }
}
