using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.BusinessModels.DataForCalculations
{
   public class DryGasDensityData
   {
      private string State;
      public DryGasDensityData(decimal density, decimal pressure, decimal deviceP, decimal temp, decimal tempDo)
      {
         GasDensity = density;
         Pressure = pressure;
         DevicePressure = deviceP;
         Temperature = temp;
         TemperatureBefore = tempDo;
         State = "WithTempBefore";
      }
      public string GetState ()
      {
         return State;
      }
      public decimal GasDensity { get; private set; }
      public decimal Pressure { get; private set; }
      public decimal DevicePressure { get; private set; }
      public decimal Temperature { get; private set; }
      public decimal TemperatureBefore { get; private set; }
   }
}
