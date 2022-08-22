using Business.DTO.Input;

namespace Business.Interfaces.Services.Input
{
   public interface IPressureService : IWritable<PressureDTO>, IDatable<PressureDTO>, IMonthable<PressureDTO>, IYearable<PressureDTO>
   {
   }
}
