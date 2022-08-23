using BLL.DTO.Input;

namespace BLL.Interfaces.Services.Input
{
   public interface IAsdueService : IMonthable<AsdueDTO>, IDatable<AsdueDTO>, IWritable<AsdueDTO>, IYearable<AsdueDTO>
   {
   }
}
