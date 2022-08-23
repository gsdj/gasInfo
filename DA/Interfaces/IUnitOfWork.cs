using DA.Entities;

namespace DA.Interfaces
{
   public interface IUnitOfWork
   {
      IGenericRepository<User> Users { get; }
      IGenericRepository<Role> Roles { get; }
      IGasGenericRepository<Pressure> Pressure { get; }
      IGasGenericRepository<AmmountCb> AmmountCb { get; }
      IGasGenericRepository<Asdue> Asdue { get; }
      IGasGenericRepository<CharacteristicsDgAll> CharacteristicsDg { get; }
      IGasGenericRepository<CharacteristicsKgAll> CharacteristicsKg { get; }
      IGasGenericRepository<DevicesKip> DevicesKip { get; }
      IGasGenericRepository<DgPgChmkEb> DgPgChmkEb { get; }
      IGasGenericRepository<KgChmkEb> KgChmkEb { get; }
      IGasGenericRepository<OutputMultipliers> Multipliers { get; }
      IGasGenericRepository<QualityAll> Quality { get; }
      IGasGenericRepository<Tec> Tec { get; }
      ISteamRepository SteamCharacteristics { get; }
      void Save();
   }
}
