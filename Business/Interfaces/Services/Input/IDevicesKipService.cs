using Business.DTO;

namespace Business.Interfaces.Services.Input
{
   public interface IDevicesKipService : IWritable<DevicesKipDTO>, IDatable<DevicesKipDTO>, IMonthable<DevicesKipDTO>, IYearable<DevicesKipDTO>
   {
   }
}
