using BLL.Calculations.Entities.Characteristics;
using BLL.Calculations.Entities.Consumption;
using BLL.DTO.Consumption;
using BLL.Interfaces.Calculations;
using BLL.Interfaces.Calculations.Characteristics;
using DA;
using DA.Interfaces;
using DA.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.IO;

namespace GasInfo
{
   public class Startup
   {
      IWebHostEnvironment _env;
      public Startup(IConfiguration configuration, IWebHostEnvironment env)
      {
         Configuration = configuration;
         _env = env;
      }

      public IConfiguration Configuration { get; }

      // This method gets called by the runtime. Use this method to add services to the container.
      public void ConfigureServices(IServiceCollection services)
      {
         string path = Path.Combine(_env.WebRootPath, "files", "SteamCharacteristics.json");
         services.AddControllersWithViews();
         services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {
               options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Account/Login");
               options.AccessDeniedPath = new Microsoft.AspNetCore.Http.PathString("/Account/Login");
            });
         services.AddDbContext<GasInfoDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("GasInfoMSSql")));
         services.AddScoped<IUnitOfWork, UnitOfWork>();
         services.AddScoped(x => new SteamJsonReader(path));
         services.AddScoped<ICalculations<ConsumptionKgDTO>, DefaultConsumptionKg>();

         services.AddScoped(typeof(IGenericRepository<>), typeof(EFGenericRepository<>));
         services.AddScoped(typeof(IGasGenericRepository<>), typeof(GasGenericRepository<>));
         services.AddCalculations();
      }

      // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
      public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
      {
         if (env.IsDevelopment())
         {
            app.UseDeveloperExceptionPage();
         }
         else
         {
            app.UseExceptionHandler("/Home/Error");
         }
         app.UseStaticFiles();

         app.UseRouting();

         app.UseAuthentication();
         app.UseAuthorization();

         app.UseEndpoints(endpoints =>
         {
            endpoints.MapControllerRoute(
                   name: "default",
                   pattern: "{controller=Home}/{action=Index}/{id?}");
         });
      }
   }
   public static class IServiceCollectionExtensions
   {
      public static IServiceCollection AddCalculations(this IServiceCollection services)
      {
         services.AddScoped<ICalcCharacteristicsKg, DefaultCharacteristicsKG>();
         return services;
      }
   }
}
