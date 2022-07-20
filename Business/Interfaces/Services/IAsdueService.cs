using Business.DTO;

namespace Business.Interfaces.Services
{
   public interface IAsdueService : IMonthable<AsdueDTO>, IDatable<AsdueDTO>, IWritable<AsdueDTO>, IYearable<AsdueDTO>
   {
   }
}
