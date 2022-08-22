using Business.DTO.Input;

namespace Business.Interfaces.Service.Input
{
   interface IAmmountCbService : IWritable<AmmountCbDTO>, IDatable<AmmountCbDTO>, IMonthable<AmmountCbDTO>, IYearable<AmmountCbDTO>
   {
   }
}
