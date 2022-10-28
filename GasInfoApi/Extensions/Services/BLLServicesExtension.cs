using BLL.DTO.Components;
using BLL.Interfaces.Service.Input;
using BLL.Interfaces.Services;
using BLL.Interfaces.Services.Account;
using BLL.Interfaces.Services.Info;
using BLL.Interfaces.Services.Input;
using BLL.Interfaces.Services.Report;
using BLL.Services;
using BLL.Services.Account;
using BLL.Services.Info;
using BLL.Services.Input;
using BLL.Services.Input.ChmkEb;
using BLL.Services.Reporting;
using Microsoft.Extensions.DependencyInjection;

namespace GasInfoApi.Extensions.Services
{
   public static class BLLServicesExtension
   {
      public static IServiceCollection AddBLLServices(this IServiceCollection services)
      {
         #region Account
         services.AddScoped<IRoleService, RoleService>();
         services.AddScoped<IUserService, UserService>();
         #endregion
         #region Input
         services.AddScoped<IAmmountCbService, AmmountCbService>();
         services.AddScoped<IAsdueService, AsdueService>();
         services.AddScoped<IGasComponentsService<ComponentsDgDTO>, ComponentsDgService>();
         services.AddScoped<IGasComponentsService<ComponentsKgDTO>, ComponentsKgService>();
         services.AddScoped<IDevicesKipService, DevicesKipService>();
         services.AddScoped<IMultipliersService, MultipliersService>();
         services.AddScoped<IPressureService, PressureService>();
         services.AddScoped<IQualityService, QualityService>();
         services.AddScoped<ITecService, TecService>();
         services.AddScoped<IDgPgChmkEb, DgPgChmkEbService>();
         services.AddScoped<IKgChmkEb, KgChmkEbService>();
         services.AddScoped<IChmkEbService, ChmkEbService>();
         #endregion
         #region Info
         services.AddScoped<IChartService, ChartService>();
         services.AddScoped<IInfoSheetService, InfoSheetService>();
         #endregion
         #region Reporting
         services.AddScoped<IConsumptionKgService, ConsumptionKgService>();
         services.AddScoped<IProductionService, ProductionService>();
         services.AddScoped<IReportKgService, ReportKgService>();
         #endregion
         return services;
      }
   }
}
