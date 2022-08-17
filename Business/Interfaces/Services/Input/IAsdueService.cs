using Business.DTO;

namespace Business.Interfaces.Services.Input
{
   public interface IAsdueService : IMonthable<AsdueDTO>, IDatable<AsdueDTO>, IWritable<AsdueDTO>, IYearable<AsdueDTO>
   {
   }
}
