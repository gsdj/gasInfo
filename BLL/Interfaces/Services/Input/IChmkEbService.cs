using BLL.DTO.Input;

namespace BLL.Interfaces.Service.Input
{
   public interface IChmkEbService 
   {
      public IDgPgChmkEb DgPgChmkEb { get; }
      public IKgChmkEb KgChmkEb { get; }
   }
   public interface IDgPgChmkEb : IWritable<DgPgChmkEbDTO>, IDatable<DgPgChmkEbDTO> { }
   public interface IKgChmkEb : IWritable<KgChmkEbDTO>, IDatable<KgChmkEbDTO> { }
}
