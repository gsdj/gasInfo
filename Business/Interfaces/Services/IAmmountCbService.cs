using Business.DTO;

namespace Business.Interfaces.Services
{
   interface IAmmountCbService : IWritable<AmmountCbDTO>, IDatable<AmmountCbDTO>, IMonthable<AmmountCbDTO>, IYearable<AmmountCbDTO>
   {
   }
}
