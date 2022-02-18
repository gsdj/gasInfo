using Business.DTO;
using Business.DTO.Characteristics;
using Business.Interfaces.Calculations;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.BusinessModels.Calculations
{
   public class CalcWetGasDensity : ICalcWetGasDensity
   {
      private Dictionary<int, SteamCharacteristicsDTO> _steam;
      public IEnumerable<DensityDTO> CalcEntities(IEnumerable<DensityDTO> dryGas, IEnumerable<DevicesKip> kip, Dictionary<int, SteamCharacteristicsDTO> steam)
      {
         _steam = steam;
         var d =
             from t1dry in dryGas
             join t2kip in kip on new { t1dry.Date } equals new { t2kip.Date }
             select new
             {
                DryGas = t1dry,
                Kip = t2kip
             };

         List<DensityDTO> densityWet = new List<DensityDTO>(d.Count());
         foreach (var item in d)
         {
            densityWet.Add(CalcEntity(item.DryGas, item.Kip));
         }
         return densityWet;
      }

      public DensityDTO CalcEntity(DensityDTO dryGas, DevicesKip kip)
      {
         return new DensityDTO
         {
            Date = dryGas.Date,
            Cu1 = WetGas(dryGas.Cu1, kip.Cu1.Temperature),
            Cu2 = WetGas(dryGas.Cu2, kip.Cu2.Temperature),
            Cb5 = WetGas(dryGas.Cb5, kip.Cb5.Temperature),
            Cb6 = WetGas(dryGas.Cb6, kip.Cb6.Temperature),
            Cb7 = WetGas(dryGas.Cb7, kip.Cb7.Temperature),
            Cb8 = WetGas(dryGas.Cb8, kip.Cb8.Temperature),
            Pkc = WetGas(dryGas.Pkc, kip.Pkc.Temperature),
            Uvtp = WetGas(dryGas.Uvtp, kip.Uvtp.Temperature),
            Spo = WetGas(dryGas.Spo, kip.Spo.Temperature),
            Gsuf = WetGas(dryGas.Gsuf, kip.Gsuf45.Temperature),
            Cb1 = WetGas(dryGas.Cb1, kip.Cb1.Temperature),
            Cb2 = WetGas(dryGas.Cb2, kip.Cb2.Temperature),
            Cb3 = WetGas(dryGas.Cb3, kip.Cb3.Temperature),
            Cb4 = WetGas(dryGas.Cb4, kip.Cb4.Temperature),
         };
      }

      public decimal WetGas(decimal dryGas, decimal temp)
      {
         int tempRounded = Convert.ToInt32(Math.Round(temp, MidpointRounding.ToEven));
         var steam = _steam[tempRounded];
         decimal rH = steam.Rh;
         decimal pMax = steam.PKg;

         decimal result = dryGas + rH * pMax;
         return Math.Round(result, 15);
      }
   }
}
