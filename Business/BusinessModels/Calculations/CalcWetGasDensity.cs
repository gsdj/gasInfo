using Business.BusinessModels.DataForCalculations;
using Business.DTO;
using Business.Interfaces.BaseCalculations;
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
      private DensityDTO CalcDryGasDensity(PressureDTO pressure, CharacteristicsKgDTO kg, CharacteristicsDgDTO dg, DevicesKipDTO kip)
      {
         return new DensityDTO
         {
            Date = pressure.Date,
            Cu1 = DryDensity.Calc(kg.Kc1.Characteristics.Density, pressure.ValuePa, kip.Cu1.Pressure, kip.Cu1.Temperature),
            Cu2 = DryDensity.Calc(kg.Kc2.Characteristics.Density, pressure.ValuePa, kip.Cu2.Pressure, kip.Cu2.Temperature),
            Cb5 = DryDensity.Calc(kg.Kc1.Characteristics.Density, pressure.ValuePa, kip.Cb5.Pressure, kip.Cb5.Temperature, kip.Cb5.TempBeforeHeating),
            Cb6 = DryDensity.Calc(kg.Kc1.Characteristics.Density, pressure.ValuePa, kip.Cb6.Pressure, kip.Cb6.Temperature, kip.Cb6.TempBeforeHeating),
            Cb7 = DryDensity.Calc(kg.Kc2.Characteristics.Density, pressure.ValuePa, kip.Cb7.Pressure, kip.Cb7.Temperature, kip.Cb7.TempBeforeHeating),
            Cb8 = DryDensity.Calc(kg.Kc2.Characteristics.Density, pressure.ValuePa, kip.Cb8.Pressure, kip.Cb8.Temperature, kip.Cb8.TempBeforeHeating),
            Pkc = DryDensity.Calc(kg.Kc1.Characteristics.Density, pressure.ValuePa, kip.Pkc.Pressure, kip.Pkc.Temperature),
            Uvtp = DryDensity.Calc(kg.Kc1.Characteristics.Density, pressure.ValuePa, kip.Uvtp.Pressure, kip.Uvtp.Temperature),
            Spo = DryDensity.Calc(kg.Kc1.Characteristics.Density, pressure.ValuePa, kip.Spo.Pressure, kip.Spo.Temperature),
            Gsuf = DryDensity.Calc(kg.Kc1.Characteristics.Density, pressure.ValuePa, kip.Gsuf45.Pressure, kip.Gsuf45.Temperature),
            Cb1 = DryDensity.Calc(dg.CharacteristicsAVG.Density, pressure.ValuePa, kip.Cb1.Pressure, kip.Cb1.Temperature),
            Cb2 = DryDensity.Calc(dg.CharacteristicsAVG.Density, pressure.ValuePa, kip.Cb2.Pressure, kip.Cb2.Temperature),
            Cb3 = DryDensity.Calc(dg.CharacteristicsAVG.Density, pressure.ValuePa, kip.Cb3.Pressure, kip.Cb3.Temperature),
            Cb4 = DryDensity.Calc(dg.CharacteristicsAVG.Density, pressure.ValuePa, kip.Cb4.Pressure, kip.Cb4.Temperature),
         };
      }
      public DensityDTO CalcEntity(Data data)
      {
         GasDensityData Data = data as GasDensityData;

         var dryGas = CalcDryGasDensity(Data.Pressure, Data.CharacteristicsKg, Data.CharacteristicsDg, Data.Kip);
         var kip = Data.Kip;

         return new DensityDTO
         {
            Date = dryGas.Date,
            Cu1 = WetDensity.Calc(dryGas.Cu1, kip.Cu1.Temperature),
            Cu2 = WetDensity.Calc(dryGas.Cu2, kip.Cu2.Temperature),
            Cb5 = WetDensity.Calc(dryGas.Cb5, kip.Cb5.Temperature),
            Cb6 = WetDensity.Calc(dryGas.Cb6, kip.Cb6.Temperature),
            Cb7 = WetDensity.Calc(dryGas.Cb7, kip.Cb7.Temperature),
            Cb8 = WetDensity.Calc(dryGas.Cb8, kip.Cb8.Temperature),
            Pkc = WetDensity.Calc(dryGas.Pkc, kip.Pkc.Temperature),
            Uvtp = WetDensity.Calc(dryGas.Uvtp, kip.Uvtp.Temperature),
            Spo = WetDensity.Calc(dryGas.Spo, kip.Spo.Temperature),
            Gsuf = WetDensity.Calc(dryGas.Gsuf, kip.Gsuf45.Temperature),
            Cb1 = WetDensity.Calc(dryGas.Cb1, kip.Cb1.Temperature),
            Cb2 = WetDensity.Calc(dryGas.Cb2, kip.Cb2.Temperature),
            Cb3 = WetDensity.Calc(dryGas.Cb3, kip.Cb3.Temperature),
            Cb4 = WetDensity.Calc(dryGas.Cb4, kip.Cb4.Temperature),
         };
      }

      public IEnumerable<DensityDTO> CalcEntities(EnumerableData data)
      {
         var Data = data as GasDensityEnumData;

         var kip = Data.Kip;
         var charKg = Data.CharacteristicsKg;
         var charDg = Data.CharacteristicsDg;
         var pressure = Data.Pressure;

         var d = from t1charKg in charKg
                 join t2charDg in charDg on new { t1charKg.Date } equals new { t2charDg.Date }
                 join t3kip in kip on new { t2charDg.Date } equals new { t3kip.Date }
                 join t4pressure in pressure on new { t3kip.Date } equals new { t4pressure.Date }
                 select new GasDensityData
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
