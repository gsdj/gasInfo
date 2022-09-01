using DA.ConfigurationsEntities;
using DA.Entities;
using DA.Entities.Characteristics;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace DA
{
   public class GasInfoDbContext : DbContext
   {
      //SteamJsonReader _steamJson;
      public GasInfoDbContext() { }
      public GasInfoDbContext(DbContextOptions<GasInfoDbContext> options/*, SteamJsonReader steamJson*/) : base(options) 
      {
         //_steamJson = steamJson;
      }
      public DbSet<Pressure> Pressure { get; set; }
      public DbSet<SteamCharacteristics> SteamCharacteristics { get; set; }
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
      //public GasInfoDbContext()
      //{
      //   Database.EnsureCreated();
      //}
      //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
      //{
      //   optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=GasInfoDb;Trusted_Connection=True;");
      //}
      protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }
      protected override void OnModelCreating(ModelBuilder modelBuilder)
      {
         modelBuilder.ApplyConfiguration(new PressureConfiguration());
         modelBuilder.ApplyConfiguration(new AmmountCbConfiguration());
         modelBuilder.ApplyConfiguration(new CharacteristicsDgConfiguration());
         modelBuilder.ApplyConfiguration(new CharacteristicsKgConfiguration());
         modelBuilder.ApplyConfiguration(new DevicesKipConfiguration());
         modelBuilder.ApplyConfiguration(new OutputMultipliersConfiguration());
         modelBuilder.ApplyConfiguration(new QualityConfiguration());
         modelBuilder.ApplyConfiguration(new AsdueConfiguration());
         modelBuilder.ApplyConfiguration(new DgPgChmkEbConfiguration());
         modelBuilder.ApplyConfiguration(new KgChmkEbConfiguration());
         modelBuilder.ApplyConfiguration(new TecConfiguration());
         modelBuilder.ApplyConfiguration(new UsersConfiguration());
         modelBuilder.ApplyConfiguration(new RolesConfiguration());
         //modelBuilder.ApplyConfiguration(new SteamCharacteristicsConfiguration());

         string adminRoleName = "Admin";
         string userRoleName = "User";

         string adminLogin = "AsupAdmin";
         string adminPassword = "55914";

         Role adminRole = new Role { Id = 1, Name = adminRoleName };
         Role userRole = new Role { Id = 2, Name = userRoleName };

         User adminUser = new User { Id = 1, Login = adminLogin, Password = adminPassword, RoleId = adminRole.Id };

         modelBuilder.Entity<Role>().HasData(new Role[] { adminRole, userRole });
         modelBuilder.Entity<User>().HasData(new User[] { adminUser });
         //modelBuilder.Entity<SteamCharacteristics>().HasData(_steamJson.GetAllSteamCharacteristics());
      }
   }

   public class GasInfoContextFactory : IDesignTimeDbContextFactory<GasInfoDbContext>
   {
      public GasInfoDbContext CreateDbContext(string[] args)
      {
         var optionsBuilder = new DbContextOptionsBuilder<GasInfoDbContext>();

         // получаем конфигурацию из файла appsettings.json
         ConfigurationBuilder builder = new ConfigurationBuilder();
         builder.SetBasePath(Directory.GetCurrentDirectory());
         builder.AddJsonFile("appsettings.json");
         IConfigurationRoot config = builder.Build();

         // получаем строку подключения из файла appsettings.json
         string connectionString = config.GetConnectionString("GasInfoMSSql");
         optionsBuilder.UseSqlServer(connectionString, opts => opts.CommandTimeout((int)TimeSpan.FromMinutes(10).TotalSeconds));
         return new GasInfoDbContext(optionsBuilder.Options);
      }
   }
}
