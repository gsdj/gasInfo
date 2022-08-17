using Business.DTO.Components;

namespace Business.Interfaces.Services.Input
{
   public interface IQualityService : IWritable<QualityComponentsDTO>, IDatable<QualityComponentsDTO>
   {
   }
}
