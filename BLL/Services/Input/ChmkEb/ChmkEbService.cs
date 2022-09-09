using BLL.Interfaces.Service.Input;

namespace BLL.Services.Input.ChmkEb
{
   public class ChmkEbService : IChmkEbService
   {
      public ChmkEbService(IDgPgChmkEb dgpg, IKgChmkEb kg)
      {
         DgPgChmkEb = dgpg;
         KgChmkEb = kg;
      }

      public IDgPgChmkEb DgPgChmkEb { get; private set; }

      public IKgChmkEb KgChmkEb { get; private set; }
   }
}
