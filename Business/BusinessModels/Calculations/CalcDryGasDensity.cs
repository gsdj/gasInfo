using Business.DTO;
using Business.Interfaces.Calculations;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.BusinessModels.Calculations
{
   public class CalcDryGasDensity : ICalcDryGasDensity
   {
      public IEnumerable<DensityDTO> CalcEntities(IEnumerable<Pressure> pressure, IEnumerable<CharacteristicsKgDTO> kgs, 
                                                  IEnumerable<CharacteristicsDgDTO> dgs, IEnumerable<DevicesKip> kip)
      {
         var d =
             from t1p in pressure
             join t2kgs in kgs on new { t1p.Date } equals new { t2kgs.Date }
             join t3dgs in dgs on new { t2kgs.Date } equals new { t3dgs.Date }
             join t4kip in kip on new { t3dgs.Date } equals new { t4kip.Date }
             select new
             {
                Pressure = t1p,
                Kgs = t2kgs,
                Dgs = t3dgs,
                Kip = t4kip
             };

         List<DensityDTO> densityDry = new List<DensityDTO>(d.Count());
         foreach (var item in d)
         {
            densityDry.Add(CalcEntity(item.Pressure, item.Kgs, item.Dgs, item.Kip));
         }
         return densityDry;
      }

      public DensityDTO CalcEntity(Pressure pressure, CharacteristicsKgDTO kg, 
                                   CharacteristicsDgDTO dg, DevicesKip kip)
      {
         return new DensityDTO
         {
            Date = pressure.Date,
            Cu1 = (kip.Cu1.Pressure == 0) ? 0 : DryGas(kg.Kc1.Density, pressure.Value * 133.3224m, kip.Cu1.Pressure, kip.Cu1.Temperature),
            Cu2 = (kip.Cu2.Pressure == 0) ? 0 : DryGas(kg.Kc2.Density, pressure.Value * 133.3224m, kip.Cu2.Pressure, kip.Cu2.Temperature),
            Cb5 = (kip.Cb5.Pressure == 0) ? 0 : DryGas(kg.Kc1.Density, pressure.Value * 133.3224m, kip.Cb5.Pressure, kip.Cb5.Temperature, kip.Cb5.TempBeforeHeating),
            Cb6 = (kip.Cb6.Pressure == 0) ? 0 : DryGas(kg.Kc1.Density, pressure.Value * 133.3224m, kip.Cb6.Pressure, kip.Cb6.Temperature, kip.Cb6.TempBeforeHeating),
            Cb7 = (kip.Cb7.Pressure == 0) ? 0 : DryGas(kg.Kc2.Density, pressure.Value * 133.3224m, kip.Cb7.Pressure, kip.Cb7.Temperature, kip.Cb7.TempBeforeHeating),
            Cb8 = (kip.Cb7.Pressure == 0) ? 0 : DryGas(kg.Kc2.Density, pressure.Value * 133.3224m, kip.Cb8.Pressure, kip.Cb8.Temperature, kip.Cb8.TempBeforeHeating),
            Pkc = (kip.Pkc.Pressure == 0) ? 0 : DryGas(kg.Kc1.Density, pressure.Value * 133.3224m, kip.Pkc.Pressure, kip.Pkc.Temperature),
            Uvtp = (kip.Uvtp.Pressure == 0) ? 0 : DryGas(kg.Kc1.Density, pressure.Value * 133.3224m, kip.Uvtp.Pressure, kip.Uvtp.Temperature),
            Spo = (kip.Spo.Pressure == 0) ? 0 : DryGas(kg.Kc1.Density, pressure.Value * 133.3224m, kip.Spo.Pressure, kip.Spo.Temperature),
            Gsuf = (kip.Gsuf45.Pressure == 0) ? 0 : DryGas(kg.Kc1.Density, pressure.Value * 133.3224m, kip.Gsuf45.Pressure, kip.Gsuf45.Temperature),
            Cb1 = (dg.Denstity == 0 || kip.Cb1.Pressure == 0) ? 0 : DryGas(dg.Denstity, pressure.Value * 133.3224m, kip.Cb1.Pressure, kip.Cb1.Temperature),
            Cb2 = (dg.Denstity == 0 || kip.Cb2.Pressure == 0) ? 0 : DryGas(dg.Denstity, pressure.Value * 133.3224m, kip.Cb2.Pressure, kip.Cb2.Temperature),
            Cb3 = (dg.Denstity == 0 || kip.Cb3.Pressure == 0) ? 0 : DryGas(dg.Denstity, pressure.Value * 133.3224m, kip.Cb3.Pressure, kip.Cb3.Temperature),
            Cb4 = (dg.Denstity == 0 || kip.Cb4.Pressure == 0) ? 0 : DryGas(dg.Denstity, pressure.Value * 133.3224m, kip.Cb4.Pressure, kip.Cb4.Temperature),
         };
      }

      public decimal DryGas(decimal pkg, decimal PPa, decimal pOver, decimal temp)
      {
         throw new NotImplementedException();
      }

      public decimal DryGas(decimal pkg, decimal PPa, decimal pOver, decimal temp, decimal tempDo)
      {
         throw new NotImplementedException();
      }

      public decimal DryGas(decimal pkg, decimal PPa, decimal pOver, decimal temp, decimal rH, decimal pMax)
      {
         throw new NotImplementedException();
      }
   }
}
