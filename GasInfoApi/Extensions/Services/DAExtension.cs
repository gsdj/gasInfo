using DA;
using DA.Entities.Characteristics;
using DA.Interfaces;
using DA.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace GasInfoApi.Extensions.Services
{
   public static class DAExtension
   {
      public static IServiceCollection AddRepositories(this IServiceCollection services, string path)
      {
         services.AddScoped<IUnitOfWork, UnitOfWork>();

         services.AddScoped<IJsonFileReader<SteamCharacteristics>>(x => new SteamJsonReader(path));


         services.AddScoped(typeof(IGenericRepository<>), typeof(EFGenericRepository<>));
         services.AddScoped(typeof(IGasGenericRepository<>), typeof(GasGenericRepository<>));
         services.AddScoped<ISteamRepository, SteamRepository>();
         return services;
      }
   }
}
