using Business.DTO;

namespace Business.Interfaces.Services
{
   public interface IDevicesKipService : IWritable<DevicesKipDTO>, IDatable<DevicesKipDTO>, IMonthable<DevicesKipDTO>, IYearable<DevicesKipDTO>
   {
   }
}
