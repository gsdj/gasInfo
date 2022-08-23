using BLL.DTO.Input;

namespace BLL.Interfaces.Services.Input
{
   public interface IDevicesKipService : IWritable<DevicesKipDTO>, IDatable<DevicesKipDTO>, IMonthable<DevicesKipDTO>, IYearable<DevicesKipDTO>
   {
   }
}
