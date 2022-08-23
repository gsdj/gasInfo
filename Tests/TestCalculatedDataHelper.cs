using BLL.DTO;
using BLL.DTO.Input;
using BLL.Models.BaseModels.Characteristics.Gas;
using BLL.Models.BaseModels.Characteristics.Quality;
using BLL.Models.BaseModels.QcRc;
using System;
using System.Collections.Generic;

namespace Tests
{
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
      public static PressureDTO PressureData2020()
      {
         return new PressureDTO
         {
            Date = new DateTime(2019, 1, 1),
            Value = 731.50m,
            ValuePa = 97525.3356m,
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
      public static CharacteristicsKG CharacteristicsKgData2020()
      {
         return new CharacteristicsKG
         {
            Date = new DateTime(2019, 1, 1),
            Kc1 =
            {
               Qn = 3604.69m,
               Density = 0.4333697m,
            },
            Kc2 =
            {
               Qn = 3704.55m,
               Density = 0.4393895m,
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
      public static CharacteristicsDG CharacteristicsDgData2020()
      {
         return new CharacteristicsDG
         {
            Date = new DateTime(2019, 1, 1),
            Kc1 =
            {
               Qn = 921.66m,
               Density = 1.1707572m,
            },
            Kc2 =
            {
               Qn = 921.66m,
               Density = 1.1707572m,
            },
            AVG =
            {
               Qn = 953.54m,
               Density = 1.171092m,
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
            {33, new SteamCharacteristicsDTO
               {
                  Temp = 33,
                  Pmm = 37.730m,
                  Pgm = 35.700m,
                  Ptopp = 35.700m,
                  Fkg = 0.0357m,
                  PPa = 5030.2541520m,
                  PKg = 0.0357m,
                  Rh = 1m,
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
            {-5, new SteamCharacteristicsDTO
               {
                  Temp = -5,
                  Pmm = 3.008m,
                  Pgm = 3.600m,
                  Ptopp = 3.000m,
                  Fkg = 0.003m,
                  PPa = 401.0337792m,
                  PKg = 0.0036m,
                  Rh = 0.8333333333m,
               }
            },   
            {-2, new SteamCharacteristicsDTO
               {
                  Temp = -2,
                  Pmm = 3.879m,
                  Pgm = 4.300m,
                  Ptopp = 3.900m,
                  Fkg = 0.0039m,
                  PPa = 517.1575896m,
                  PKg = 0.0043m,
                  Rh = 0.9069767442m,
               }
            },            
            {11, new SteamCharacteristicsDTO
               {
                  Temp = 11,
                  Pmm = 9.840m,
                  Pgm = 10.000m,
                  Ptopp = 10.100m,
                  Fkg = 0.0101m,
                  PPa = 1311.8924160m,
                  PKg = 0.010m,
                  Rh = 1.01m,
               }
            },      
            {32, new SteamCharacteristicsDTO
               {
                  Temp = 32,
                  Pmm = 35.660m,
                  Pgm = 33.800m,
                  Ptopp = 33.900m,
                  Fkg = 0.0339m,
                  PPa = 4754.2767840m,
                  PKg = 0.0338m,
                  Rh = 1.0029585799m,
               }
            },            
            {25, new SteamCharacteristicsDTO
               {
                  Temp = 25,
                  Pmm = 23.760m,
                  Pgm = 23.000m,
                  Ptopp = 23.100m,
                  Fkg = 0.0231m,
                  PPa = 3167.7402240m,
                  PKg = 0.023m,
                  Rh = 1.0043478261m,
               }
            },
            {37, new SteamCharacteristicsDTO
               {
                  Temp = 37,
                  Pmm = 47.070m,
                  Pgm = 43.900m,
                  Ptopp = 44.800m,
                  Fkg = 0.0448m,
                  PPa = 6275.4853680m,
                  PKg = 0.0439m,
                  Rh = 1.0205011390m,
               }
            },
            {39, new SteamCharacteristicsDTO
               {
                  Temp = 39,
                  Pmm = 52.440m,
                  Pgm = 48.600m,
                  Ptopp = 48.700m,
                  Fkg = 0.0487m,
                  PPa = 6991.4266560m,
                  PKg = 0.0486m,
                  Rh = 1.0020576132m,
               }
            },
            {66, new SteamCharacteristicsDTO
               {
                  Temp = 66,
                  Pmm = 196.100m,
                  Pgm = 166.800m,
                  Ptopp = 168.100m,
                  Fkg = 0.1681m,
                  PPa = 26144.5226400m,
                  PKg = 0.1668m,
                  Rh = 1.0077937650m,
               }
            },
            {69, new SteamCharacteristicsDTO
               {
                  Temp = 69,
                  Pmm = 223.700m,
                  Pgm = 188.600m,
                  Ptopp = 199.100m,
                  Fkg = 0.1991m,
                  PPa = 29824.2208800m,
                  PKg = 0.1886m,
                  Rh = 1.0556733828m,
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
      public static DevicesKipDTO DevicesKipData2020()
      {
         return new DevicesKipDTO
         {
            Date = new DateTime(2019, 1, 1),
            Cu =
            {
               Cu1 =
               {
                  Consumption = { Value = 2512611.66666667m },
                  Pressure = 1131,
                  Temperature = 39,
               },
               Cu2 =
               {
                  Consumption = { Value = 463892 },
                  Pressure = 859,
                  Temperature = 31,
               },
            },
            Kc2 =
            {
               Cb1 =
               {
                  Consumption = { Value = 9143 },
                  Pressure = 387,
                  Temperature = 65.6m,
                  TempBeforeHeating = 33,
               },
               Cb2 =
               {
                  Consumption = { Value = 8539 },
                  Pressure = 379,
                  Temperature = 69,
                  TempBeforeHeating = 33,
               },
               Cb3 =
               {
                  Consumption = { Ms = 3464, Ks = 3724 },
                  Pressure = 361,
                  Temperature = 62,
                  TempBeforeHeating = 32,
               },
               Cb4 =
               {
                  Consumption = { Ms = 941, Ks = 975 },
                  Pressure = 639,
                  Temperature = 61,
                  TempBeforeHeating = 30,
               },
            },
            CpsPpk =
            {
               Pko =
               {
                  Pkp =
                  {
                     Consumption = { Ms = 0, Ks = 19137 },
                     Pressure = 1280,
                     Temperature = 37,
                  },
                  Uvtp =
                  {
                     Consumption = { Value = 22925 },
                     Pressure = 1120,
                     Temperature = 37,
                  },
               },
               Spo =
               {
                  Consumption = { Value = 20302 },
                  Pressure = 1108,
                  Temperature = 11,
               },
            },
            Gsuf45 =
            {
               Consumption = { Value = 2497 },
               Pressure = 1124,
               Temperature = 25,
            },
            Kc1 =
            {
               Cb1 =
               {
                  Consumption = { Value = 918356 },
                  Pressure = 462,
                  Temperature = 31,
               },
               Cb2 =
               {
                  Consumption = { Value = 1049124 },
                  Pressure = 462,
                  Temperature = 31,
               },
               Cb3 =
               {
                  Consumption = { Value = 0 },
                  Pressure = 0,
                  Temperature = 0,
               },
               Cb4 =
               {
                  Consumption = { Value = 989663 },
                  Pressure = 470,
                  Temperature = 26,
               },
            },
            Gru =
            {
               Gru1 =
               {
                  Consumption = { Value = 16560 },
                  Pressure = 540,
                  Temperature = -5,
               },
               Gru2 =
               {
                  Consumption = { Value = 16272 },
                  Pressure = 481,
                  Temperature = -2,
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
      public static QualityCharacteristics QualityData2020()
      {
         return new QualityCharacteristics
         {
            Date = new DateTime(2019, 1, 1),
            Kc1 =
            {
               Vc = 25.9233m,
               KgFv = 14.7391082356m,
               KgFh = 0.34038038751405m,
               Density = 0.4333697m,
            },
            Kc2 =
            {
               Vc = 25.7114m,
               KgFv = 14.6787450558m,
               KgFh = 0.334460739249813m,
               Density = 0.4393895m,
            },
         };
      }
   }
}
