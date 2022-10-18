using DA.ConfigurationsEntities;
using DA.Entities;
using DA.Entities.Characteristics;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DA
{
   public class GasInfoDbContext : DbContext
   {
      public GasInfoDbContext() { }
      public GasInfoDbContext(DbContextOptions<GasInfoDbContext> options) : base(options) { }
      public GasInfoDbContext(DbContextOptions<GasInfoDbContext> options, Dictionary<string, InitialDataSettings> dataSettings) : base(options) 
      {
         DataSettings = dataSettings;
      }

      private Dictionary<string, InitialDataSettings> DataSettings;

      public DbSet<Pressure> Pressure { get; set; }
      public DbSet<DevicesKip> DevicesKip { get; set; }
      public DbSet<CharacteristicsDgAll> CharacteristicsDg { get; set; }
      public DbSet<CharacteristicsKgAll> CharacteristicsKg { get; set; }
      public DbSet<AmmountCb> AmmountCbs { get; set; }
      public DbSet<QualityAll> Quality { get; set; }
      public DbSet<Tec> Tec { get; set; }
      public DbSet<KgChmkEb> KgChmkEb { get; set; }
      public DbSet<OutputMultipliers> Multipliers { get; set; }
      public DbSet<Asdue> Asdue { get; set; }
      public DbSet<DgPgChmkEb> DgPgChmkEb { get; set; }
      public DbSet<User> Users { get; set; }
      public DbSet<Role> Roles { get; set; }
      protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }
      protected override void OnModelCreating(ModelBuilder modelBuilder)
      {
         modelBuilder.ApplyConfiguration(new PressureConfiguration(DataSettings["Pressure"]));
         modelBuilder.ApplyConfiguration(new AmmountCbConfiguration(DataSettings["AmmountCb"]));
         modelBuilder.ApplyConfiguration(new CharacteristicsDgConfiguration(DataSettings["CharacteristicsDg"]));
         modelBuilder.ApplyConfiguration(new CharacteristicsKgConfiguration(DataSettings["CharacteristicsKg"]));
         modelBuilder.ApplyConfiguration(new DevicesKipConfiguration(DataSettings["DevicesKip"]));
         modelBuilder.ApplyConfiguration(new OutputMultipliersConfiguration(DataSettings["OutputMultipliers"]));
         modelBuilder.ApplyConfiguration(new QualityConfiguration(DataSettings["Quality"]));
         modelBuilder.ApplyConfiguration(new AsdueConfiguration(DataSettings["Asdue"]));
         modelBuilder.ApplyConfiguration(new DgPgChmkEbConfiguration(DataSettings["DgPgChmkEb"]));
         modelBuilder.ApplyConfiguration(new KgChmkEbConfiguration(DataSettings["KgChmkEb"]));
         modelBuilder.ApplyConfiguration(new TecConfiguration(DataSettings["Tec"]));
         modelBuilder.ApplyConfiguration(new RolesConfiguration());
         modelBuilder.ApplyConfiguration(new UsersConfiguration());
      }
   }

   public class GasInfoContextFactory : IDesignTimeDbContextFactory<GasInfoDbContext>
   {
      public GasInfoDbContext CreateDbContext(string[] args)
      {
         var currentDirectory = Directory.GetCurrentDirectory();
         var optionsBuilder = new DbContextOptionsBuilder<GasInfoDbContext>();

         ConfigurationBuilder builder = new ConfigurationBuilder();
         builder.SetBasePath(currentDirectory);

         builder
            .AddJsonFile("appsettings.json")
            .AddJsonFile("InitialDataSettings.json");

         IConfiguration config = builder.Build();
         
         var ids = config.GetSection("TestData")
            .Get<List<InitialDataSettings>>();

         ids.ForEach(x => x.Path = $"{currentDirectory}{x.Path}");

         var idsD = ids.ToDictionary(x => x.FileName);

         string connectionString = config.GetConnectionString("GasInfoMSSql");
         optionsBuilder.UseSqlServer(connectionString, opts => opts.CommandTimeout((int)TimeSpan.FromMinutes(10).TotalSeconds));

         return new GasInfoDbContext(optionsBuilder.Options, idsD);
      }
   }

   public class InitialDataSettings
   {
      public string FileName { get; set; }
      public string Path { get; set; }
   }
}
