using Business.DTO;
using Business.DTO.Characteristics.CharacteristicsGas;
using Business.Interfaces.BaseCalculations;
using Business.Interfaces.BaseCalculations.Density;
using Business.Interfaces.Calculations;
using DataAccess.Entities;
using DataAccess.Entities.Characteristics;
using System.Collections.Generic;
using System.Linq;

namespace Business.BusinessModels.Calculations
{
   public class CalcCharacteristicsDG : ICalcCharacteristicsDg
   {
      private IQn<DG> Qn;
      private IDensity<DG> Density;
      private ISumComponents SumComponents;
      private IQn<CharacteristicsDgAll> QnAvg;
      private IDensity<CharacteristicsDgAll> DensityAvg;
      private IAvgComponents<CharacteristicsDgAll, GasComponents> AvgComponents;
      public CalcCharacteristicsDG(IQn<DG> qn, IDensity<DG> density, ISumComponents sum, 
                                    IQn<CharacteristicsDgAll> qnAvg, IDensity<CharacteristicsDgAll> denAvg, 
                                    IAvgComponents<CharacteristicsDgAll, GasComponents> avgC)
      {
         Qn = qn;
         Density = density;
         SumComponents = sum;
         QnAvg = qnAvg;
         DensityAvg = denAvg;
         AvgComponents = avgC;
      }
      public IEnumerable<CharacteristicsDgDTO> CalcEntities(IEnumerable<CharacteristicsDgAll> _Dgs)
      {
         List<CharacteristicsDgDTO> DgDTOList = new List<CharacteristicsDgDTO>(_Dgs.Count());
         foreach (var item in _Dgs)
         {
            DgDTOList.Add(CalcEntity(item));
         }
         return DgDTOList;
      }
      public CharacteristicsDgDTO CalcEntity(CharacteristicsDgAll Dg)
      {
         return new CharacteristicsDgDTO
         {
            Date = Dg.Date,
            Kc1 =
            {
               Components = 
               {
                  CO = Dg.Kc1.CO,
                  CO2 = Dg.Kc1.CO2,
                  H2 = Dg.Kc1.H2,
                  N2 = Dg.Kc1.N2,
               },
               SumComponents = SumComponents.Calc(Dg.Kc1.CO, Dg.Kc1.CO2, Dg.Kc1.H2, Dg.Kc1.N2),
               Characteristics = 
               {
                  Qn = Qn.Calc(Dg.Kc1),
                  Density = Density.Calc(Dg.Kc1),
               },
            },
            Kc2 =
            {
               Components = 
               {
                  CO = Dg.Kc2.CO,
                  CO2 = Dg.Kc2.CO2,
                  H2 = Dg.Kc2.H2,
                  N2 = Dg.Kc2.N2
               },
               SumComponents = SumComponents.Calc(Dg.Kc2.CO, Dg.Kc2.CO2, Dg.Kc2.H2, Dg.Kc2.N2),
               Characteristics =
               {
                  Qn = Qn.Calc(Dg.Kc2),
                  Density = Density.Calc(Dg.Kc2),
               },

            },
            ComponentsAVG = AvgComponents.Calc(Dg),
            CharacteristicsAVG =
            {
               Qn = QnAvg.Calc(Dg),
               Density = DensityAvg.Calc(Dg),
            },
         };
      }

   }
}
