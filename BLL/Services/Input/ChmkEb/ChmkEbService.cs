using BLL.DTO.Input;
using BLL.Interfaces.Service.Input;
using DA.Entities;
using DA.Interfaces;
using System;

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
