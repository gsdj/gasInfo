using Business.DTO;
using Business.DTO.Models.Characteristics.Gas;
using Business.DTO.Models.Characteristics.Quality;
using Business.DTO.Models.QcRc;
using DataAccess.Entities;
using DataAccess.Entities.Characteristics;
using System;
using System.Collections.Generic;

namespace Tests
{
   //DataDb
   //CalculatedData
   //EnumDbData
   public class TestCalculatedDataHelper
   {
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
      public static AsdueDTO AsdueDTOData()
      {
         return new AsdueDTO
         {
            TecNorth = 1202109.25m,
            TecSouth = 623785.25m,
            Gps2Gss1 = 0.0m,
            Gps2Gss2 = 0.0m,
            NaturalGasQn = 0.0m,
            OutPkg = 10m,
            StmDay = 1825895m,
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
                  PPa = 5319.5637600m,
                  PKg = 0.0376m,
                  Rh = 1.0026595745m,
               }
            },
            {31, new SteamCharacteristicsDTO
               {
                  Temp = 31,
                  Pmm = 33.700m,
                  Pgm = 32.000m,
                  Ptopp = 32.100m,
                  Fkg = 0.0321m,
                  PPa = 4492.9648800m,
                  PKg = 0.032m,
                  Rh = 1.003125m,
               }
            },
            {26, new SteamCharacteristicsDTO
               {
                  Temp = 26,
                  Pmm = 25.210m,
                  Pgm = 24.300m,
                  Ptopp = 24.400m,
                  Fkg = 0.0244m,
                  PPa = 3361.0577040m,
                  PKg = 0.0243m,
                  Rh = 1.0041152263m,
               }
            },
            {61, new SteamCharacteristicsDTO
               {
                  Temp = 61,
                  Pmm = 156.500m,
                  Pgm = 135.200m,
                  Ptopp = 135.900m,
                  Fkg = 0.1359m,
                  PPa = 20864.9556000m,
                  PKg = 0.1352m,
                  Rh = 1.0051775148m,
               }
            },
            {65, new SteamCharacteristicsDTO
               {
                  Temp = 65,
                  Pmm = 187.500m,
                  Pgm = 160.100m,
                  Ptopp = 161.100m,
                  Fkg = 0.1611m,
                  PPa = 24997.9500000m,
                  PKg = 0.1601m,
                  Rh = 1.0062460962m,
               }
            },
            {62, new SteamCharacteristicsDTO
               {
                  Temp = 62,
                  Pmm = 163.800m,
                  Pgm = 141.100m,
                  Ptopp = 141.900m,
                  Fkg = 0.1419m,
                  PPa = 21838.2091200m,
                  PKg = 0.1411m,
                  Rh = 1.0056697378m,
               }
            },
            {57, new SteamCharacteristicsDTO
               {
                  Temp = 57,
                  Pmm = 129.800m,
                  Pgm = 113.700m,
                  Ptopp = 114.100m,
                  Fkg = 0.1141m,
                  PPa = 17305.2475200m,
                  PKg = 0.1137m,
                  Rh = 1.0035180299m,
               }
            },
            {30, new SteamCharacteristicsDTO
               {
                  Temp = 30,
                  Pmm = 31.820m,
                  Pgm = 30.400m,
                  Ptopp = 30.400m,
                  Fkg = 0.0304m,
                  PPa = 4242.3187680m,
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
                  PPa = 2197.1531520m,
                  PKg = 0.0163m,
                  Rh = 1.0061349693m,
               }
            },
            {36, new SteamCharacteristicsDTO
               {
                  Temp = 36,
                  Pmm = 44.560m,
                  Pgm = 41.700m,
                  Ptopp = 41.800m,
                  Fkg = 0.0418m,
                  PPa = 5940.8461440m,
                  PKg = 0.0417m,
                  Rh = 1.0023980815m,
               }
            },
            {28, new SteamCharacteristicsDTO
               {
                  Temp = 28,
                  Pmm = 28.350m,
                  Pgm = 27.200m,
                  Ptopp = 27.300m,
                  Fkg = 0.0273m,
                  PPa = 3779.6900400m,
                  PKg = 0.0272m,
                  Rh = 1.0036764706m,
               }
            },
            {22, new SteamCharacteristicsDTO
               {
                  Temp = 22,
                  Pmm = 19.830m,
                  Pgm = 19.400m,
                  Ptopp = 19.500m,
                  Fkg = 0.0195m,
                  PPa = 2643.7831920m,
                  PKg = 0.0194m,
                  Rh = 1.0051546392m,
               }
            },
            {-11, new SteamCharacteristicsDTO
               {
                  Temp = -11,
                  Pmm = 1.780m,
                  Pgm = 2.400m,
                  Ptopp = 1.900m,
                  Fkg = 0.0019m,
                  PPa = 237.3138720m,
                  PKg = 0.0024m,
                  Rh = 0.7916666667m,
               }
            },
            {-10, new SteamCharacteristicsDTO
               {
                  Temp = -10,
                  Pmm = 1.946m,
                  Pgm = 2.600m,
                  Ptopp = 2.000m,
                  Fkg = 0.002m,
                  PPa = 259.4453904m,
                  PKg = 0.0026m,
                  Rh = 0.7692307692m,
               }
            },
            {0, new SteamCharacteristicsDTO
               {
                  Temp = 0,
                  Pmm = 4.579m,
                  Pgm = 4.900m,
                  Ptopp = 4.900m,
                  Fkg = 0.0049m,
                  PPa = 610.4832696m,
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
      public static DensityDTO DensityDTOData()
      {
         return new DensityDTO
         {
            Date = new DateTime(2019, 1, 1),
            Cu =
            {
               Cu1 = 0.4857840419m,
               Cu2 = 0.4418307183m,
            },
            Kc2 =
            {
               Cb1 = 0.4591238375m,
               Cb2 = 0.4645476338m,
               Cb3 = 0.4403959960m,
               Cb4 = 0.4332943460m,
            },
            CpsPpk =
            {
               Pko =
               {
                  Pkp = 0.4889691785m,
                  Uvtp = 0.4893950244m,
               },
               Spo = 0.4789630264m,
            },
            Gsuf = 0.4811577412m,
            Kc1 =
            {
               Cb1 = 1.2019043517m,
               Cb2 = 1.2019043517m,
               Cb3 = 1.2914997647m,
               Cb4 = 1.2342532350m,
            },
         };
      }
      public static QcRcKc1 QcRcKc1Data()
      {
         return new QcRcKc1
         {
            Cb1 =
            {
               Value = 890814.5442797562m,
            },
            Cb2 =
            {
               Value = 1023709.6082483867m,
            },
            Cb3 =
            {
               Value = 0.0m,
            },
            Cb4 =
            {
               Value = 1037536.7819241509m,
            },
         };
      }
      public static QualityCharacteristics QualityData()
      {
         return new QualityCharacteristics
         {
            Date = new DateTime(2019, 1, 1),
            Kc1 =
            {
               Vc = 25.9233m,
               KgFv = 14.7391082356m,
               KgFh = 0.3282125859m,
               Density = 0.4490720m,
            },
            Kc2 =
            {
               Vc = 25.7114m,
               KgFv = 14.6787450558m,
               KgFh = 0.3477601798m,
               Density = 0.4220939m,
            },
         };
      }
   }
}
