using BLL.DTO.Components;

namespace BLL.Interfaces.Services.Input
{
   public interface IQualityService : IWritable<QualityComponentsDTO>, IDatable<QualityComponentsDTO>
   {
   }
}
