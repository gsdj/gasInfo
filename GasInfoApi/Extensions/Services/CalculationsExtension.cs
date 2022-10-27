using BLL.Calculations.Base;
using BLL.Calculations.Base.Consumption;
using BLL.Calculations.Base.Density;
using BLL.Calculations.Base.Qn;
using BLL.Calculations.Entities;
using BLL.Calculations.Entities.Characteristics;
using BLL.Calculations.Entities.Charts;
using BLL.Calculations.Entities.ConsGasQn;
using BLL.Calculations.Entities.Consumption;
using BLL.Calculations.Entities.Production;
using BLL.Calculations.Entities.QcRc;
using BLL.DTO;
using BLL.DTO.Charts;
using BLL.DTO.Consumption;
using BLL.Interfaces;
using BLL.Interfaces.BaseCalculations;
using BLL.Interfaces.BaseCalculations.Consumption;
using BLL.Interfaces.BaseCalculations.Density;
using BLL.Interfaces.Calculations;
using BLL.Interfaces.Calculations.Characteristics;
using BLL.Interfaces.Calculations.ConsGasQn;
using BLL.Interfaces.Calculations.Production;
using BLL.Interfaces.Services;
using BLL.Models;
using BLL.Models.BaseModels.Components;
using BLL.Models.BaseModels.QcRc;
using BLL.Services;
using Business.Interfaces.BaseCalculations.Density;
using DA.Entities;
using DA.Entities.Characteristics;
using Microsoft.Extensions.DependencyInjection;

namespace GasInfoApi.Extensions.Services
{
   public static class CalculationsExtension
   {
      public static IServiceCollection AddBaseCalculations(this IServiceCollection services)
      {
         services.AddScoped<IAvgComponents<CharacteristicsDgAll, GasComponents>, AvgDgComponents>();
         services.AddScoped<IDryCokeProduction<DefaultDryCokeProduction>, DefaultDryCokeProduction>();
         services.AddScoped<IChargeConsFV<DefaultChargeConsFV>, DefaultChargeConsFV>();
         services.AddScoped<IConsPg, DefaultConsPg>();
         services.AddScoped<IConsPgCb, DefaultConsPgCb>();
         services.AddScoped<ISpecificConsDgFv, DefaultSpecificConsDgFv>();
         services.AddScoped<ISpecificConsKgFv, DefaultSpecificConsKgFv>();
         services.AddScoped<ISpoPerKus<DefaultSpoPerKus>, DefaultSpoPerKus>();
         #region CharacteristicsDG
         services.AddScoped<IQn<DG>, DefaultQnDg>();
         services.AddScoped<IDensity<DG>, DefaultDensityDg>();
         services.AddScoped<IQn<CharacteristicsDgAll>, AVGQnDg>();
         services.AddScoped<IDensity<CharacteristicsDgAll>, AVGDensityDg>();
         #endregion
         #region CharacteristicsKG
         services.AddScoped<IQn<KG>, DefaultQnKg>();
         services.AddScoped<IDensity<KG>, DefaultDensityKg>();
         #endregion
         return services;
      }
      public static IServiceCollection AddProductionCalculations(this IServiceCollection services)
      {
         services.AddScoped<ICokeCbConsumptionFvCalc, CokeCbConsumptionFvCalc>();
         services.AddScoped<ICokeCbConsumptionDryCalc, CokeCbConsumptionDryCalc>();
         services.AddScoped<ICokeCbDryCalc, CokeCbDryCalc>();
         services.AddScoped<ICokeCbGrossCalc, CokeCbGrossCalc>();
         return services;
      }
      public static IServiceCollection AddConsQnCalculations(this IServiceCollection services)
      {
         services.AddScoped<ICalcCharacteristicsSteam, DefaultCharacteristicsSteam>();
         services.AddScoped<ISteamCharacteristicsService, SteamCharacteristicsService>();
         services.AddScoped<IQcRc, DefaultQcRc>();
         services.AddScoped<IWetDensity, WetDensity>();
         services.AddScoped<IDryDensity, DryDensity>();
         
         #region ConsQnCpsPpk
         services.AddScoped<ICalcQcRc<CpsPpkQcRc>, CalcQcRcCpsPpk>();
         services.AddScoped<IConsGasQn<ConsGasQn4000>, ConsGasQn4000>();
         services.AddScoped<ICalcConsGasQnCpsPpk, CalcConsQnCpsPpk>();
         #endregion
         #region ConsQnKc1
         services.AddScoped<ICalcQcRc<QcRcKc1>, CalcQcRcKc1>();
         services.AddScoped<IConsGasQn<ConsGasQn1000>, ConsGasQn1000>();
         services.AddScoped<ICalcConsGasQnKc1, CalcConsQnKc1>();
         #endregion
         #region ConsQnKc2
         services.AddScoped<ICalcQcRc<QcRcKc2>, CalcQcRcKc2>();
         services.AddScoped<ICalcConsGasQnKc2, CalcConsQnKc2>();
         #endregion
         return services;
      }
      public static IServiceCollection AddEntitiesCalculation(this IServiceCollection services)
      {
         services.AddScoped<ICalculations<DensityDTO>, DefaultWetGasDensity>();
         services.AddScoped<ICalcCharacteristicsDg, DefaultCharacteristicsDG>();
         services.AddScoped<ICalcCharacteristicsKg, DefaultCharacteristicsKG>();
         services.AddScoped<ICalcTec, CalcTec>();
         services.AddScoped<ICalcEbChmk, DefaultEbChmk>();
         services.AddScoped<ICalcQuality, DefaultQualities>();
         services.AddScoped<ICalcInfoSheet, CalcInfoSheet>();
         services.AddScoped<ICalcProduction, DefaultProduction>();

         services.AddScoped<ICalculations<ChartMonthDTO>, DefaultChartMonth>();
         services.AddScoped<ICalculations<ChartYearDTO>, DefaultChartYear>();
         services.AddScoped<ICalculations<ConsumptionDgDTO>, DefaultConsumptionDg>();
         services.AddScoped<ICalculations<ConsumptionDgPgDTO>, DefaultConsumptionDgPg>();
         services.AddScoped<ICalculations<ConsumptionKgDTO>, DefaultConsumptionKg>();
         services.AddScoped<ICalculations<OutputKgDTO>, DefaultOutputKG>();
         services.AddScoped<ICalculations<ReportKgDTO>, DefaultReportKg>();

         services.AddScoped<IUnitOfCalc, UnitOfCalc>();
         return services;
      }
   }
}
