using DA;
using GasInfoApi.Extensions.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GasInfoApi
{
   public class Startup
   {
      public Startup(IConfiguration configuration, IWebHostEnvironment env)
      {
         //Configuration = configuration;
         _env = env;
         
         var builder = new ConfigurationBuilder()
            .AddJsonFile($"appsettings.{_env.EnvironmentName}.json") //� ����� ���� appsettings.Production.json
            .AddJsonFile("InitialDataSettings.json");

         Configuration = builder.Build();
      }

      public IConfiguration Configuration { get; }
      IWebHostEnvironment _env;

      // This method gets called by the runtime. Use this method to add services to the container.
      public void ConfigureServices(IServiceCollection services)
      {
         var ids = Configuration.GetSection("TestData")
            .Get<List<InitialDataSettings>>();

         var currentDirectory = Directory.GetCurrentDirectory();

         ids.ForEach(x => x.Path = $"{currentDirectory}{x.Path}");

         var idsD = ids.ToDictionary(x => x.FileName);

         string path = Path.Combine(_env.WebRootPath, "files", "SteamCharacteristics.json");

         services.AddControllers();
         services.AddSwaggerGen(c =>
         {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "GasInfoApi", Version = "v1" });
         });

         services.AddSingleton(new InitialData(Configuration));

         services.AddDbContext<GasInfoDbContext>(options =>
         {
            options.UseSqlServer(Configuration.GetConnectionString("GasInfoMSSql"));
            options.UseLazyLoadingProxies();
         });

         services.AddRepositories(path);
         services.AddBaseCalculations();
         services.AddProductionCalculations();
         services.AddConsQnCalculations();
         services.AddEntitiesCalculation();
         services.AddBLLServices();
      }

      // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
      public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
      {
         if (env.IsDevelopment())
         {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "GasInfoApi v1"));
         }

         app.UseDefaultFiles();
         app.UseStaticFiles();
         app.UseRouting();

         app.UseAuthorization();

         app.UseEndpoints(endpoints =>
         {
            endpoints.MapControllers();
         });
      }
   }
}
