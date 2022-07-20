using Business.BusinessModels.DataForCalculations;
using Business.DTO;
using Business.DTO.Models.Characteristics.Gas;
using Business.Interfaces.BaseCalculations.Density;
using Business.Interfaces.Calculations;
using System.Collections.Generic;
using System.Linq;

namespace Business.BusinessModels.Calculations
{
   public class CalcWetGasDensity : ICalculations<DensityDTO>, ICalculation<DensityDTO>
   {
      private IWetDensity WetDensity;
      private IDryDensity DryDensity;
      public CalcWetGasDensity(IWetDensity wet, IDryDensity dry)
      {
         WetDensity = wet;
         DryDensity = dry;
      }
      private DensityDTO CalcDryGasDensity(PressureDTO pressure, CharacteristicsKG kg, CharacteristicsDG dg, DevicesKipDTO kip)
      {
         return new DensityDTO
         {
            Date = pressure.Date,
            Cu =
            {
               Cu1 = DryDensity.Calc(kg.Kc1.Density, pressure.ValuePa, kip.Cu.Cu1.Pressure, kip.Cu.Cu1.Temperature),
               Cu2 = DryDensity.Calc(kg.Kc2.Density, pressure.ValuePa, kip.Cu.Cu2.Pressure, kip.Cu.Cu2.Temperature),
            },
            Kc2 =
            {
               Cb1 = DryDensity.Calc(kg.Kc1.Density, pressure.ValuePa, kip.Kc2.Cb1.Pressure, kip.Kc2.Cb1.Temperature, kip.Kc2.Cb1.TempBeforeHeating),
               Cb2 = DryDensity.Calc(kg.Kc1.Density, pressure.ValuePa, kip.Kc2.Cb2.Pressure, kip.Kc2.Cb2.Temperature, kip.Kc2.Cb2.TempBeforeHeating),
               Cb3 = DryDensity.Calc(kg.Kc2.Density, pressure.ValuePa, kip.Kc2.Cb3.Pressure, kip.Kc2.Cb3.Temperature, kip.Kc2.Cb3.TempBeforeHeating),
               Cb4 = DryDensity.Calc(kg.Kc2.Density, pressure.ValuePa, kip.Kc2.Cb4.Pressure, kip.Kc2.Cb4.Temperature, kip.Kc2.Cb4.TempBeforeHeating),
            },
            CpsPpk =
            {
               Pko =
               {
                  Pkp = DryDensity.Calc(kg.Kc1.Density, pressure.ValuePa, kip.CpsPpk.Pko.Pkp.Pressure, kip.CpsPpk.Pko.Pkp.Temperature),
                  Uvtp = DryDensity.Calc(kg.Kc1.Density, pressure.ValuePa, kip.CpsPpk.Pko.Uvtp.Pressure, kip.CpsPpk.Pko.Uvtp.Temperature),
               },
               Spo = DryDensity.Calc(kg.Kc1.Density, pressure.ValuePa, kip.CpsPpk.Spo.Pressure, kip.CpsPpk.Spo.Temperature),
            },
            Gsuf = DryDensity.Calc(kg.Kc1.Density, pressure.ValuePa, kip.Gsuf45.Pressure, kip.Gsuf45.Temperature),
            Kc1 =
            {
               Cb1 = DryDensity.Calc(dg.AVG.Density, pressure.ValuePa, kip.Kc1.Cb1.Pressure, kip.Kc1.Cb1.Temperature),
               Cb2 = DryDensity.Calc(dg.AVG.Density, pressure.ValuePa, kip.Kc1.Cb2.Pressure, kip.Kc1.Cb2.Temperature),
               Cb3 = DryDensity.Calc(dg.AVG.Density, pressure.ValuePa, kip.Kc1.Cb3.Pressure, kip.Kc1.Cb3.Temperature),
               Cb4 = DryDensity.Calc(dg.AVG.Density, pressure.ValuePa, kip.Kc1.Cb4.Pressure, kip.Kc1.Cb4.Temperature),
            },
         };
      }
      public DensityDTO CalcEntity(Data data)
      {
         var dryGas = CalcDryGasDensity(data.Pressure, data.CharacteristicsKg, data.CharacteristicsDg, data.Kip);
         var kip = data.Kip;

         return new DensityDTO
         {
            Date = dryGas.Date,
            Cu =
            {
               Cu1 = WetDensity.Calc(dryGas.Cu.Cu1, kip.Cu.Cu1.Temperature),
               Cu2 = WetDensity.Calc(dryGas.Cu.Cu2, kip.Cu.Cu2.Temperature),
            },
            Kc2 =
            {
               Cb1 = WetDensity.Calc(dryGas.Kc2.Cb1, kip.Kc2.Cb1.Temperature),
               Cb2 = WetDensity.Calc(dryGas.Kc2.Cb2, kip.Kc2.Cb2.Temperature),
               Cb3 = WetDensity.Calc(dryGas.Kc2.Cb3, kip.Kc2.Cb3.Temperature),
               Cb4 = WetDensity.Calc(dryGas.Kc2.Cb4, kip.Kc2.Cb4.Temperature),
            },
            CpsPpk =
            {
               Pko =
               {
                  Pkp = WetDensity.Calc(dryGas.CpsPpk.Pko.Pkp, kip.CpsPpk.Pko.Pkp.Temperature),
                  Uvtp = WetDensity.Calc(dryGas.CpsPpk.Pko.Uvtp, kip.CpsPpk.Pko.Uvtp.Temperature),
               },
               Spo = WetDensity.Calc(dryGas.CpsPpk.Spo, kip.CpsPpk.Spo.Temperature),
            },
            Gsuf = WetDensity.Calc(dryGas.Gsuf, kip.Gsuf45.Temperature),
            Kc1 =
            {
               Cb1 = WetDensity.Calc(dryGas.Kc1.Cb1, kip.Kc1.Cb1.Temperature),
               Cb2 = WetDensity.Calc(dryGas.Kc1.Cb2, kip.Kc1.Cb2.Temperature),
               Cb3 = WetDensity.Calc(dryGas.Kc1.Cb3, kip.Kc1.Cb3.Temperature),
               Cb4 = WetDensity.Calc(dryGas.Kc1.Cb4, kip.Kc1.Cb4.Temperature),
            },
         };
      }

      public IEnumerable<DensityDTO> CalcEntities(EnumerableData data)
      {
         var d = from t1charKg in data.CharacteristicsKg
                 join t2charDg in data.CharacteristicsDg on new { t1charKg.Date } equals new { t2charDg.Date }
                 join t3kip in data.Kip on new { t2charDg.Date } equals new { t3kip.Date }
                 join t4pressure in data.Pressure on new { t3kip.Date } equals new { t4pressure.Date }
                 select new Data
                 {
                    CharacteristicsKg = t1charKg,
                    CharacteristicsDg = t2charDg,
                    Kip = t3kip,
                    Pressure = t4pressure,
                 };

         List<DensityDTO> densityWet = new List<DensityDTO>(d.Count());
         foreach (var item in d)
         {
            densityWet.Add(CalcEntity(item));
         }
         return densityWet;
      }
   }
}
