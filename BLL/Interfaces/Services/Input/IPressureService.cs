using BLL.DTO.Input;

namespace BLL.Interfaces.Services.Input
{
   public interface IPressureService : IWritable<PressureDTO>, IDatable<PressureDTO>, IMonthable<PressureDTO>, IYearable<PressureDTO>
   {
   }
}
