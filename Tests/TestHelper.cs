using Business.DTO;
using Business.DTO.Models.Characteristics.Gas;
using DataAccess.Entities;
using System;
using System.Collections.Generic;

namespace Tests
{
   public class TestHelper
   {
      public static AmmountCb AmmountCbData()
      {
         var om = new OutputMultipliers
         {
            Date = new DateTime(2019, 1, 1),
            Cb1 = 10.44m,
            Cb2 = 12.78m,
            Cb3 = 0m,
            Cb4 = 12.81m,
            Cb5 = 13.33m,
            Cb6 = 13.33m,
            Cb7 = 13.33m,
            Cb8 = 13.28m,
            PKP = 6.94m,
            Peka = 420m,
            Sv = 1.274m,
            Fv = 1.375m,
         };
         return new AmmountCb
         {
            Date = new DateTime(2019, 1, 1),
            Cb1 = 78,
            Cb2 = 84,
            Cb3 = 0,
            Cb4 = 80,
            Cb5 = 48,
            Cb6 = 48,
            Cb7 = 47,
            Cb8 = 53,
            PKP = 12,
            OutputMultipliers = om,
         };
      }
      public static PressureDTO PressureData()
      {
         return new PressureDTO
         {
            Date = new DateTime(2019, 1, 1),
            Value = 752,
            ValuePa = 100258,
         };
      }
      public static CharacteristicsKG CharacteristicsKgData()
      {
         return new CharacteristicsKG
         {
            Date = new DateTime(2019, 1, 1),
            Kc1 =
            {
               Qn = 3600,
               Density = 0.449m,
            },
            Kc2 =
            {
               Qn = 3808,
               Density = 0.418m,
            },
         };
      }
      public static CharacteristicsDG CharacteristicsDgData()
      {
         return new CharacteristicsDG
         {
            Date = new DateTime(2019, 1, 1),
            Kc1 =
            {
               Qn = 718.1m,
               Density = 1.219m,
            },
            Kc2 =
            {
               Qn = 718.1m,
               Density = 1.219m,
            },
            AVG =
            {
               Qn = 742.03m,
               Density = 1.219m,
            },
         };
      }
      public static Dictionary<int, SteamCharacteristicsDTO> SteamCharacteristicsData()
      {
         return new Dictionary<int, SteamCharacteristicsDTO>
         {
            {34, new SteamCharacteristicsDTO
               {
                  Temp = 34,
                  Pmm = 39.900m,
                  Pgm = 37.600m,
                  Ptopp = 37.700m,
                  Fkg = 0.0377m,
                  PPa = 5319.5478m,
                  PKg = 0.0376m,
                  Rh = 1.0027m,
               }
            },
            {31, new SteamCharacteristicsDTO
               {
                  Temp = 31,
                  Pmm = 33.700m,
                  Pgm = 32.000m,
                  Ptopp = 32.100m,
                  Fkg = 0.0321m,
                  PPa = 4492.9648m,
                  PKg = 0.032m,
                  Rh = 1.0031m,
               }
            },
            {26, new SteamCharacteristicsDTO
               {
                  Temp = 26,
                  Pmm = 25.210m,
                  Pgm = 24.300m,
                  Ptopp = 24.400m,
                  Fkg = 0.0244m,
                  PPa = 3361.0476m,
                  PKg = 0.0243m,
                  Rh = 1.0041m,
               }
            },
            {61, new SteamCharacteristicsDTO
               {
                  Temp = 61,
                  Pmm = 156.500m,
                  Pgm = 135.200m,
                  Ptopp = 135.900m,
                  Fkg = 0.1359m,
                  PPa = 20864.9556m,
                  PKg = 0.1352m,
                  Rh = 1.0052m,
               }
            },
            {65, new SteamCharacteristicsDTO
               {
                  Temp = 65,
                  Pmm = 187.500m,
                  Pgm = 160.100m,
                  Ptopp = 161.100m,
                  Fkg = 0.1611m,
                  PPa = 24997.95m,
                  PKg = 0.1601m,
                  Rh = 1.0062m,
               }
            },
            {62, new SteamCharacteristicsDTO
               {
                  Temp = 62,
                  Pmm = 163.800m,
                  Pgm = 141.100m,
                  Ptopp = 141.900m,
                  Fkg = 0.1419m,
                  PPa = 21838.2091m,
                  PKg = 0.1411m,
                  Rh = 1.0056m,
               }
            },
            {57, new SteamCharacteristicsDTO
               {
                  Temp = 57,
                  Pmm = 129.800m,
                  Pgm = 113.700m,
                  Ptopp = 114.100m,
                  Fkg = 0.1141m,
                  PPa = 17305.2475m,
                  PKg = 0.1137m,
                  Rh = 1.0035m,
               }
            },
            {30, new SteamCharacteristicsDTO
               {
                  Temp = 30,
                  Pmm = 31.820m,
                  Pgm = 30.400m,
                  Ptopp = 30.400m,
                  Fkg = 0.0304m,
                  PPa = 4242.3187m,
                  PKg = 0.0304m,
                  Rh = 1,
               }
            },
            {19, new SteamCharacteristicsDTO
               {
                  Temp = 19,
                  Pmm = 16.480m,
                  Pgm = 16.300m,
                  Ptopp = 16.400m,
                  Fkg = 0.0164m,
                  PPa = 2197.1531m,
                  PKg = 0.0163m,
                  Rh = 1.0061m,
               }
            },
            {36, new SteamCharacteristicsDTO
               {
                  Temp = 36,
                  Pmm = 44.560m,
                  Pgm = 41.700m,
                  Ptopp = 41.800m,
                  Fkg = 0.0418m,
                  PPa = 5940.8461m,
                  PKg = 0.0417m,
                  Rh = 1.0023m,
               }
            },
            {28, new SteamCharacteristicsDTO
               {
                  Temp = 28,
                  Pmm = 28.350m,
                  Pgm = 27.200m,
                  Ptopp = 27.300m,
                  Fkg = 0.0273m,
                  PPa = 3779.6900m,
                  PKg = 0.0272m,
                  Rh = 1.0036m,
               }
            },
            {22, new SteamCharacteristicsDTO
               {
                  Temp = 22,
                  Pmm = 19.830m,
                  Pgm = 19.400m,
                  Ptopp = 19.500m,
                  Fkg = 0.0195m,
                  PPa = 2643.7831m,
                  PKg = 0.0194m,
                  Rh = 1.0051m,
               }
            },
            {-11, new SteamCharacteristicsDTO
               {
                  Temp = -11,
                  Pmm = 1.780m,
                  Pgm = 2.400m,
                  Ptopp = 1.900m,
                  Fkg = 0.0019m,
                  PPa = 237.3738m,
                  PKg = 0.0024m,
                  Rh = 0.7916m,
               }
            },
            {-10, new SteamCharacteristicsDTO
               {
                  Temp = -10,
                  Pmm = 1.946m,
                  Pgm = 2.600m,
                  Ptopp = 2.000m,
                  Fkg = 0.0002m,
                  PPa = 259.4453m,
                  PKg = 0.0026m,
                  Rh = 0.0769m,
               }
            },
            {0, new SteamCharacteristicsDTO
               {
                  Temp = 0,
                  Pmm = 4.579m,
                  Pgm = 4.900m,
                  Ptopp = 4.900m,
                  Fkg = 0.0049m,
                  PPa = 610.4832m,
                  PKg = 0.0049m,
                  Rh = 1,
               }
            },

         };
      }
      public static DevicesKipDTO DevicesKipData()
      {
         return new DevicesKipDTO
         {
            Date = new DateTime(2019, 1, 1),
            Cu =
            {
               Cu1 =
               {
                  Consumption = { Value = 1664569 },
                  Pressure = 1124,
                  Temperature = 34,
               },
               Cu2 =
               {
                  Consumption = { Value = 709345 },
                  Pressure = 744,
                  Temperature = 31,
               },
            },
            Kc2 =
            {
               Cb1 =
               {
                  Consumption = { Value = 7435 },
                  Pressure = 391,
                  Temperature = 61,
                  TempBeforeHeating = 26,
               },
               Cb2 =
               {
                  Consumption = { Value = 7218 },
                  Pressure = 391,
                  Temperature = 65,
                  TempBeforeHeating = 26,
               },
               Cb3 =
               {
                  Consumption = { Ms = 2542, Ks = 2539 },
                  Pressure = 446,
                  Temperature = 62,
                  TempBeforeHeating = 31,
               },
               Cb4 =
               {
                  Consumption = { Ms = 2570, Ks = 3013 },
                  Pressure = 427,
                  Temperature = 57,
                  TempBeforeHeating = 30,
               },
            },
            CpsPpk =
            {
               Pko =
               {
                  Pkp =
                  {
                     Consumption = { Ms = 12576, Ks = 11665 },
                     Pressure = 1030,
                     Temperature = 26,
                  },
                  Uvtp =
                  {
                     Consumption = { Value = 18516 },
                     Pressure = 1040,
                     Temperature = 26,
                  },
               },
               Spo =
               {
                  Consumption = { Value = 29001 },
                  Pressure = 610,
                  Temperature = 19,
               },
            },
            Gsuf45 =
            {
               Consumption = { Value = 5609 },
               Pressure = 1046,
               Temperature = 36,
            },
            Kc1 =
            {
               Cb1 =
               {
                  Consumption = { Value = 924484 },
                  Pressure = 391,
                  Temperature = 28,
               },
               Cb2 =
               {
                  Consumption = { Value = 1062402 },
                  Pressure = 391,
                  Temperature = 28,
               },
               Cb3 =
               {
                  Consumption = { Value = 0 },
                  Pressure = 0,
                  Temperature = 0,
               },
               Cb4 =
               {
                  Consumption = { Value = 1041164 },
                  Pressure = 414,
                  Temperature = 22,
               },
            },
            Gru =
            {
               Gru1 =
               {
                  Consumption = { Value = 16584 },
                  Pressure = 627,
                  Temperature = -11,
               },
               Gru2 =
               {
                  Consumption = { Value = 14976 },
                  Pressure = 425,
                  Temperature = -10.4m,
               },
            },
            Grp4 =
            {
               Consumption = { Value = 0 },
               Pressure = 0,
               Temperature = 0,
            },
         };
      }
   }
}
