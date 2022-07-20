using Business.DTO.Models.General;
using Business.DTO.Models.Production;

namespace Business.DTO
{
   public class ProductionDTO : Entity
   {
      public ProductionDTO()
      {
         AmmountCb = new AmmountCb<int>();
         CokeCbConsumptionFv = new CbAll();
         CokeCbGross = new CokeCbGross();
         CokeCbDry = new CokeCbDry();
         CokeCbConsumptionDry = new CokeCbConsumptionDry();
      }
      //Коэффициенты/выхода
      public decimal SvC { get; set; }
      public decimal FvC { get; set; }
      public decimal KpeC { get; set; }

      public AmmountCb<int> AmmountCb { get; set; }
      //public int Cb1Cb2 { get; set; }
      //public int Cb3Cb4 { get; set; }
      //public int Cb5Cb6 { get; set; }
      //public int Cb7Cb8 { get; set; }
      //public int Cb1Cb6 { get; set; }
      //public int MK { get; set; }

      //Про-во кокса вал.
      //public decimal Cb16Val { get; set; }
      //public decimal Cb78Val { get; set; }
      //public decimal CbTnVal { get; set; }
      public CokeCbGross CokeCbGross { get; set; }

      //Про-во кокса сух.
      //public decimal Cb16Dry { get; set; }
      //public decimal Cb78Dry { get; set; }
      //public decimal TnDry { get; set; }
      //public decimal KpeDry { get; set; }
      public CokeCbDry CokeCbDry { get; set; }

      //Расход шихты сух.
      //public decimal Cb16ConsDry { get; set; }
      //public decimal Cb78ConsDry { get; set; }
      //public decimal TnConsDry { get; set; }
      public CokeCbConsumptionDry CokeCbConsumptionDry { get; set; }

      //Расход шихты в ф.в.
      public CbAll CokeCbConsumptionFv { get; set; }

      //Расход шихты в с.в.
      //public decimal Cb16Sv { get; set; }
      //public decimal Cb78Sv { get; set; }

      //СПО, переработка КУС
      public decimal PkoKpe { get; set; }
      public decimal SpoPerKus { get; set; }
   }
}
