using DataAccess.Entities;
using DataAccess.Entities.Characteristics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
   public class TestDbDataHelper
   {
      public static CharacteristicsDgAll CharacteristicsDgAllData()
      {
         return new CharacteristicsDgAll
         {
            Id = Guid.NewGuid(),
            Date = new DateTime(2019, 1, 1),
            Kc1 =
            {
               H2 = 5.10m,
               CO = 21.20m,
               CO2 = 16.50m,
               N2 = 56.90m,
            },
            Kc2 =
            {
               H2 = 5.10m,
               CO = 21.20m,
               CO2 = 16.50m,
               N2 = 56.90m,
            },
         };
      }
      public static CharacteristicsKgAll CharacteristicsKgAllData()
      {
         return new CharacteristicsKgAll
         {
            Id = Guid.NewGuid(),
            Date = new DateTime(2019, 1, 1),
            Kc1 =
            {
               CO2 = 2.8m,
               O2 = 1.7m,
               CO = 7.6m,
               CnHm = 2.0m,
               CH4 = 21.2m,
               H2 = 58.6m,
               N2 = 6.1m,
            },
            Kc2 =
            {
               CO2 = 2.8m,
               O2 = 0.8m,
               CO = 7.6m,
               CnHm = 2.2m,
               CH4 = 22.9m,
               H2 = 60.4m,
               N2 = 3.5m,
            },
         };
      }
      public static QualityAll QualityAllData()
      {
         return new QualityAll
         {
            Date = new DateTime(2019, 1, 1),
            Kc1 =
            {
               W = 8.1m,
               A = 10.3m,
               V = 28.9m,
            },
            Kc2 =
            {
               W = 8.1m,
               A = 10.1m,
               V = 28.6m,
            },
         };
      }
      public static DgPgChmkEb DgPgChmkEbData()
      {
         return new DgPgChmkEb
         {
            Date = new DateTime(2019, 1, 10),
            ConsDgCb1 = 9914000,
            ConsDgCb2 = 10992000,
            ConsDgCb3 = 0,
            ConsDgCb4 = 11247000,
            ConsPgGru1 = 157000,
            ConsPgGru2 = 197000,
         };
      }
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
      public static AmmountCb AmmountCbData2020()
      {
         var om = new OutputMultipliers
         {
            Date = new DateTime(2019, 1, 1),
            Cb1 = 10.51m,
            Cb2 = 13.11m,
            Cb3 = 0m,
            Cb4 = 13.20m,
            Cb5 = 13.37m,
            Cb6 = 13.37m,
            Cb7 = 13.73m,
            Cb8 = 0m,
            PKP = 9.86m,
            Peka = 420m,
            Sv = 1.259m,
            Fv = 1.375m,
         };
         return new AmmountCb
         {
            Date = new DateTime(2019, 1, 1),
            Cb1 = 75,
            Cb2 = 79,
            Cb3 = 0,
            Cb4 = 79,
            Cb5 = 64,
            Cb6 = 64,
            Cb7 = 68,
            Cb8 = 0,
            PKP = 8,
            OutputMultipliers = om,
         };
      }
      public static KgChmkEb KgChmkEbData()
      {
         return new KgChmkEb
         {
            Date = new DateTime(2019, 01, 01),
            Consumption = 67531.7866247823m,
         };
      }

      public static List<SteamCharacteristics> SteamCharacteristicsData()
      {
         return new List<SteamCharacteristics>
         {
            new SteamCharacteristics
            {
               Temp = 34,
               Pmm = 39.900m,
               Pgm = 37.600m,
               Ptopp = 37.700m,
            },
            new SteamCharacteristics
            {
               Temp = 33,
               Pmm = 37.730m,
               Pgm = 35.700m,
               Ptopp = 35.700m,
            },
            new SteamCharacteristics
            {
               Temp = 31,
               Pmm = 33.700m,
               Pgm = 32.000m,
               Ptopp = 32.100m,
            },
            new SteamCharacteristics
            {
               Temp = 26,
               Pmm = 25.210m,
               Pgm = 24.300m,
               Ptopp = 24.400m,
            },
            new SteamCharacteristics
            {
               Temp = 61,
               Pmm = 156.500m,
               Pgm = 135.200m,
               Ptopp = 135.900m,
            },
            new SteamCharacteristics
            {
               Temp = 65,
               Pmm = 187.500m,
               Pgm = 160.100m,
               Ptopp = 161.100m,
            },
            new SteamCharacteristics
            {
               Temp = 62,
               Pmm = 163.800m,
               Pgm = 141.100m,
               Ptopp = 141.900m,
            },
            new SteamCharacteristics
            {
               Temp = 57,
               Pmm = 129.800m,
               Pgm = 113.700m,
               Ptopp = 114.100m,
            },
            new SteamCharacteristics
            {
               Temp = 30,
               Pmm = 31.820m,
               Pgm = 30.400m,
               Ptopp = 30.400m,
            },
            new SteamCharacteristics
            {
               Temp = 19,
               Pmm = 16.480m,
               Pgm = 16.300m,
               Ptopp = 16.400m,
            },
            new SteamCharacteristics
            {
               Temp = 36,
               Pmm = 44.560m,
               Pgm = 41.700m,
               Ptopp = 41.800m,
            },
            new SteamCharacteristics
            {
               Temp = 28,
               Pmm = 28.350m,
               Pgm = 27.200m,
               Ptopp = 27.300m,
            },
            new SteamCharacteristics
            {
               Temp = 22,
               Pmm = 19.830m,
               Pgm = 19.400m,
               Ptopp = 19.500m,
            },
            new SteamCharacteristics
            {
               Temp = -11,
               Pmm = 1.780m,
               Pgm = 2.400m,
               Ptopp = 1.900m,
            },
            new SteamCharacteristics
            {
               Temp = -10,
               Pmm = 1.946m,
               Pgm = 2.600m,
               Ptopp = 2.000m,
            },
            new SteamCharacteristics
            {
               Temp = 0,
               Pmm = 4.579m,
               Pgm = 4.900m,
               Ptopp = 4.900m,
            },
            new SteamCharacteristics
            {
                  Temp = -5,
                  Pmm = 3.008m,
                  Pgm = 3.600m,
                  Ptopp = 3.000m,
            },
            new SteamCharacteristics
            {
                  Temp = -2,
                  Pmm = 3.879m,
                  Pgm = 4.300m,
                  Ptopp = 3.900m,
            },
            new SteamCharacteristics
            {
                  Temp = 11,
                  Pmm = 9.840m,
                  Pgm = 10.000m,
                  Ptopp = 10.100m,
            },
            new SteamCharacteristics
            {
                  Temp = 32,
                  Pmm = 35.660m,
                  Pgm = 33.800m,
                  Ptopp = 33.900m,
            },
            new SteamCharacteristics
            {
                  Temp = 25,
                  Pmm = 23.760m,
                  Pgm = 23.000m,
                  Ptopp = 23.100m,
            },
            new SteamCharacteristics
            {
                  Temp = 37,
                  Pmm = 47.070m,
                  Pgm = 43.900m,
                  Ptopp = 44.800m,
            },
            new SteamCharacteristics
            {
                  Temp = 39,
                  Pmm = 52.440m,
                  Pgm = 48.600m,
                  Ptopp = 48.700m,
            },
            new SteamCharacteristics
            {
                  Temp = 66,
                  Pmm = 196.100m,
                  Pgm = 166.800m,
                  Ptopp = 168.100m,
            },
            new SteamCharacteristics
            {
                  Temp = 69,
                  Pmm = 223.700m,
                  Pgm = 188.600m,
                  Ptopp = 199.100m,
            },
         };
      }
      public static IEnumerable<AmmountCb> AmmountCbDataList()
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
         List<AmmountCb> lst = new List<AmmountCb>
         {
            new AmmountCb
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
            },
            new AmmountCb
            {
               Date = new DateTime(2019, 1, 2),
               Cb1 = 74,
               Cb2 = 79,
               Cb3 = 0,
               Cb4 = 83,
               Cb5 = 51,
               Cb6 = 52,
               Cb7 = 53,
               Cb8 = 53,
               PKP = 11,
               OutputMultipliers = om,
            },
            new AmmountCb
            {
               Date = new DateTime(2019, 1, 3),
               Cb1 = 72,
               Cb2 = 79,
               Cb3 = 0,
               Cb4 = 79,
               Cb5 = 51,
               Cb6 = 51,
               Cb7 = 56,
               Cb8 = 56,
               PKP = 11,
               OutputMultipliers = om,
            },
            new AmmountCb
            {
               Date = new DateTime(2019, 1, 4),
               Cb1 = 78,
               Cb2 = 84,
               Cb3 = 0,
               Cb4 = 82,
               Cb5 = 51,
               Cb6 = 51,
               Cb7 = 56,
               Cb8 = 56,
               PKP = 11,
               OutputMultipliers = om,
            },
            new AmmountCb
            {
               Date = new DateTime(2019, 1, 5),
               Cb1 = 75,
               Cb2 = 79,
               Cb3 = 0,
               Cb4 = 81,
               Cb5 = 52,
               Cb6 = 52,
               Cb7 = 56,
               Cb8 = 56,
               PKP = 10,
               OutputMultipliers = om,
            },
            new AmmountCb
            {
               Date = new DateTime(2019, 1, 6),
               Cb1 = 73,
               Cb2 = 79,
               Cb3 = 0,
               Cb4 = 79,
               Cb5 = 53,
               Cb6 = 52,
               Cb7 = 56,
               Cb8 = 56,
               PKP = 11,
               OutputMultipliers = om,
            },
            new AmmountCb
            {
               Date = new DateTime(2019, 1, 7),
               Cb1 = 77,
               Cb2 = 84,
               Cb3 = 0,
               Cb4 = 84,
               Cb5 = 52,
               Cb6 = 53,
               Cb7 = 55,
               Cb8 = 55,
               PKP = 10,
               OutputMultipliers = om,
            },
            new AmmountCb
            {
               Date = new DateTime(2019, 1, 8),
               Cb1 = 75,
               Cb2 = 79,
               Cb3 = 0,
               Cb4 = 79,
               Cb5 = 53,
               Cb6 = 52,
               Cb7 = 54,
               Cb8 = 54,
               PKP = 10,
               OutputMultipliers = om,
            },
            new AmmountCb
            {
               Date = new DateTime(2019, 1, 9),
               Cb1 = 75,
               Cb2 = 80,
               Cb3 = 0,
               Cb4 = 83,
               Cb5 = 53,
               Cb6 = 53,
               Cb7 = 54,
               Cb8 = 54,
               PKP = 11,
               OutputMultipliers = om,
            },
            new AmmountCb
            {
               Date = new DateTime(2019, 1, 10),
               Cb1 = 74,
               Cb2 = 81,
               Cb3 = 0,
               Cb4 = 77,
               Cb5 = 50,
               Cb6 = 51,
               Cb7 = 54,
               Cb8 = 53,
               PKP = 10,
               OutputMultipliers = om,
            },
            //new AmmountCb
            //{
            //   Date = new DateTime(2019, 1, 11),
            //   Cb1 = 71,
            //   Cb2 = 76,
            //   Cb3 = 0,
            //   Cb4 = 78,
            //   Cb5 = 50,
            //   Cb6 = 50,
            //   Cb7 = 51,
            //   Cb8 = 51,
            //   PKP = 9,
            //   OutputMultipliers = om,
            //},
            //new AmmountCb
            //{
            //   Date = new DateTime(2019, 1, 12),
            //   Cb1 = 74,
            //   Cb2 = 79,
            //   Cb3 = 0,
            //   Cb4 = 78,
            //   Cb5 = 52,
            //   Cb6 = 51,
            //   Cb7 = 52,
            //   Cb8 = 53,
            //   PKP = 8,
            //   OutputMultipliers = om,
            //},
            //new AmmountCb
            //{
            //   Date = new DateTime(2019, 1, 13),
            //   Cb1 = 74,
            //   Cb2 = 80,
            //   Cb3 = 0,
            //   Cb4 = 85,
            //   Cb5 = 50,
            //   Cb6 = 51,
            //   Cb7 = 56,
            //   Cb8 = 57,
            //   PKP = 10,
            //   OutputMultipliers = om,
            //},
            //new AmmountCb
            //{
            //   Date = new DateTime(2019, 1, 14),
            //   Cb1 = 76,
            //   Cb2 = 82,
            //   Cb3 = 0,
            //   Cb4 = 82,
            //   Cb5 = 52,
            //   Cb6 = 51,
            //   Cb7 = 57,
            //   Cb8 = 57,
            //   PKP = 8,
            //   OutputMultipliers = om,
            //},
            //new AmmountCb
            //{
            //   Date = new DateTime(2019, 1, 15),
            //   Cb1 = 77,
            //   Cb2 = 86,
            //   Cb3 = 0,
            //   Cb4 = 82,
            //   Cb5 = 54,
            //   Cb6 = 54,
            //   Cb7 = 54,
            //   Cb8 = 54,
            //   PKP = 9,
            //   OutputMultipliers = om,
            //},
         };
         return lst;
      }
   }
}
