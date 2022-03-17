using Business.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces.Services
{
   public interface IAsdueService : IMonthable<AsdueDTO>, IDatable<AsdueDTO>, IWritable<AsdueDTO>, IYearable<AsdueDTO>
   {
   }
}
