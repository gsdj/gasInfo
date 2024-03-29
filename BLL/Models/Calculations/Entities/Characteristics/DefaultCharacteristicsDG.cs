﻿using BLL.Interfaces.BaseCalculations;
using BLL.Interfaces.BaseCalculations.Density;
using BLL.Interfaces.Calculations.Characteristics;
using BLL.Models.BaseModels.Characteristics.Gas;
using DA.Entities;
using DA.Entities.Characteristics;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Calculations.Entities.Characteristics
{
   public class DefaultCharacteristicsDG : ICalcCharacteristicsDg
   {
      private IQn<DG> Qn;
      private IDensity<DG> Density;
      private IQn<CharacteristicsDgAll> QnAvg;
      private IDensity<CharacteristicsDgAll> DensityAvg;
      public DefaultCharacteristicsDG(IQn<DG> qn, IDensity<DG> density, IQn<CharacteristicsDgAll> qnAvg, IDensity<CharacteristicsDgAll> denAvg)
      {
         Qn = qn;
         Density = density;
         QnAvg = qnAvg;
         DensityAvg = denAvg;
      }
      public IEnumerable<CharacteristicsDG> CalcEntities(IEnumerable<CharacteristicsDgAll> _Dgs)
      {
         List<CharacteristicsDG> DgDTOList = new List<CharacteristicsDG>(_Dgs.Count());
         foreach (var item in _Dgs)
         {
            DgDTOList.Add(CalcEntity(item));
         }
         return DgDTOList;
      }
      public CharacteristicsDG CalcEntity(CharacteristicsDgAll Dg)
      {
         return new CharacteristicsDG
         {
            Date = Dg.Date,
            Kc1 =
            {
               Qn = Qn.Calc(Dg.Kc1),
               Density = Density.Calc(Dg.Kc1),
            },
            Kc2 =
            {
               Qn = Qn.Calc(Dg.Kc2),
               Density = Density.Calc(Dg.Kc2),
            },
            AVG =
            {
               Qn = QnAvg.Calc(Dg),
               Density = DensityAvg.Calc(Dg),
            },
         };
      }

   }
}
