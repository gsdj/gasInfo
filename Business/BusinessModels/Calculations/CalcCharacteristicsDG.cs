using Business.DTO;
using Business.DTO.Characteristics.CharacteristicsGas;
using Business.Interfaces.BaseCalculations;
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
            //{
            //   H2 = AvgC(Dg.Kc1.H2, Dg.Kc2.H2),
            //   CO = AvgC(Dg.Kc1.CO, Dg.Kc2.CO),
            //   CO2 = AvgC(Dg.Kc1.CO2, Dg.Kc2.CO2),
            //   N2 = AvgC(Dg.Kc1.N2, Dg.Kc2.N2),
            //},
            CharacteristicsAVG =
            {
               Qn = QnAvg.Calc(Dg),// AvgQn(AvgC(Dg.Kc1.H2, Dg.Kc2.H2), AvgC(Dg.Kc1.CO, Dg.Kc2.CO), AvgC(Dg.Kc1.CO2, Dg.Kc2.CO2), AvgC(Dg.Kc1.N2, Dg.Kc2.N2)),
               Density = DensityAvg.Calc(Dg),// AvgDensity(AvgC(Dg.Kc1.H2, Dg.Kc2.H2), AvgC(Dg.Kc1.CO, Dg.Kc2.CO), AvgC(Dg.Kc1.CO2, Dg.Kc2.CO2), AvgC(Dg.Kc1.N2, Dg.Kc2.N2)),
            },
         };
      }
      ///// <summary>
      ///// Плотность коксового газа
      ///// </summary>
      ///// <param name="CO2"></param>
      ///// <param name="O2"></param>
      ///// <param name="CO"></param>
      ///// <param name="CnHm"></param>
      ///// <param name="CH4"></param>
      ///// <param name="H2"></param>
      ///// <param name="N2"></param>
      ///// <returns></returns>
      //public decimal Density(decimal CO2, decimal CO, decimal H2, decimal N2)
      //{
      //   return (0.01m * (H2 * 0.0837m + CO * 1.165m + CO2 * 1.842m + N2 * 1.166m));
      //}
      ///// <summary>
      ///// Калорийность коксового газа
      ///// </summary>
      ///// <param name="CO"></param>
      ///// <param name="CnHm"></param>
      ///// <param name="CH4"></param>
      ///// <param name="H2"></param>
      ///// <returns></returns>
      //public decimal Qn(decimal CO, decimal H2)
      //{
      //   return (0.01m * (H2 * 2400 + CO * 2810));
      //}
      ///// <summary>
      ///// Сумма компонентов состава
      ///// </summary>
      ///// <param name="components"></param>
      ///// <returns></returns>
      //public decimal SumComponents(params decimal[] components)
      //{
      //   decimal result = 0;
      //   foreach (var item in components)
      //   {
      //      result += item;
      //   }
      //   return result;
      //}
      ///// <summary>
      ///// Среднее значение компонента газа
      ///// </summary>
      ///// <param name="componentA"></param>
      ///// <param name="componentB"></param>
      ///// <returns></returns>
      //public decimal AvgC(decimal componentA, decimal componentB)
      //{
      //   return (componentA + componentB) / 2;
      //}
      ///// <summary>
      ///// Средняя калорийность газа
      ///// </summary>
      ///// <param name="H2"></param>
      ///// <param name="CO"></param>
      ///// <param name="CO2"></param>
      ///// <param name="N2"></param>
      ///// <returns></returns>
      //public decimal AvgQn(decimal H2, decimal CO, decimal CO2, decimal N2)
      //{
      //   return (H2 * 2400 + CO * 2810 + ((100 - H2 - CO - CO2 - N2) * 7970)) * 0.01m;
      //}
      ///// <summary>
      ///// Средняя плотность газа
      ///// </summary>
      ///// <param name="H2"></param>
      ///// <param name="CO"></param>
      ///// <param name="CO2"></param>
      ///// <param name="N2"></param>
      ///// <returns></returns>
      //public decimal AvgDensity(decimal H2, decimal CO, decimal CO2, decimal N2)
      //{
      //   return 0.01m * (H2 * 0.0837m + CO * 1.165m + CO2 * 1.842m + N2 * 1.166m + (100 - H2 - CO - CO2 - N2) * 0.0837m);
      //}

   }
}
