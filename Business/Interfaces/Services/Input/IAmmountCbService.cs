using Business.DTO;

namespace Business.Interfaces.Service.Input
{
   interface IAmmountCbService : IWritable<AmmountCbDTO>, IDatable<AmmountCbDTO>, IMonthable<AmmountCbDTO>, IYearable<AmmountCbDTO>
   {
   }
}
