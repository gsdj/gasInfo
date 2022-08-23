using BLL.Models.BaseModels.Consumption;

namespace BLL.Models.BaseModels.Devices
{
   public class Device
   {
      public Device()
      {
         Consumption = new ConsumptionGas();
      }
      public ConsumptionGas Consumption { get; set; }
      public int Pressure { get; set; } = 0;
      public decimal Temperature { get; set; } = 0;
   }
}
