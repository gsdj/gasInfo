using Business.DTO;

namespace Business.Interfaces.Services
{
   public interface IPressureService : IWritable<PressureDTO>, IDatable<PressureDTO>, IMonthable<PressureDTO>, IYearable<PressureDTO>
   {
   }
}
