using DataAccess.Entities;
using DataAccess.Interfaces;
using System;

namespace DataAccess
{
   public class UnitOfWork : IUnitOfWork, IDisposable
   {
      private GasInfoDbContext db;
      public UnitOfWork(GasInfoDbContext context, IGenericRepository<User> repUser, IGenericRepository<Role> repRole,
                        IGasGenericRepository<Pressure> repPressure, IGasGenericRepository<AmmountCb> repAmmount,
                        IGasGenericRepository<Asdue> repAsdue, IGasGenericRepository<CharacteristicsDgAll> repChDg,
                        IGasGenericRepository<CharacteristicsKgAll> repChKg, IGasGenericRepository<DevicesKip> repKip,
                        IGasGenericRepository<DgPgChmkEb> repDgPgChmk, IGasGenericRepository<KgChmkEb> repKgChmk,
                        IGasGenericRepository<OutputMultipliers> repMultipliers, IGasGenericRepository<QualityAll> repQ,
                        IGasGenericRepository<Tec> repTec)
      {
         db = context;
         Users = repUser;
         Roles = repRole;
         Pressure = repPressure;
         AmmountCb = repAmmount;
         Asdue = repAsdue;
         CharacteristicsDg = repChDg;
         CharacteristicsKg = repChKg;
         DevicesKip = repKip;
         DgPgChmkEb = repDgPgChmk;
         KgChmkEb = repKgChmk;
         Multipliers = repMultipliers;
         Quality = repQ;
         Tec = repTec;
      }

      public IGenericRepository<User> Users { get; private set; }

      public IGenericRepository<Role> Roles { get; private set; }

      public IGasGenericRepository<Pressure> Pressure { get; private set; }

      public IGasGenericRepository<AmmountCb> AmmountCb { get; private set; }

      public IGasGenericRepository<Asdue> Asdue { get; private set; }

      public IGasGenericRepository<CharacteristicsDgAll> CharacteristicsDg { get; private set; }

      public IGasGenericRepository<CharacteristicsKgAll> CharacteristicsKg { get; private set; }

      public IGasGenericRepository<DevicesKip> DevicesKip { get; private set; }

      public IGasGenericRepository<DgPgChmkEb> DgPgChmkEb { get; private set; }

      public IGasGenericRepository<KgChmkEb> KgChmkEb { get; private set; }

      public IGasGenericRepository<OutputMultipliers> Multipliers { get; private set; }

      public IGasGenericRepository<QualityAll> Quality { get; private set; }

      public IGasGenericRepository<Tec> Tec { get; private set; }

      public void Save()
      {
         db.SaveChanges();
      }

      private bool disposed = false;
      public virtual void Dispose(bool disposing)
      {
         if (!this.disposed)
         {
            if (disposing)
            {
               db.Dispose();
            }
            this.disposed = true;
         }
      }
      public void Dispose()
      {
         Dispose(true);
         GC.SuppressFinalize(this);
      }
   }
}
