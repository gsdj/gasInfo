using Business.DTO.Models.Consumption;

namespace Business.DTO.Models.Devices
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
