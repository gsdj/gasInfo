using BLL.Calculations.Base;
using BLL.Calculations.Base.Consumption;
using BLL.Calculations.Base.Density;
using BLL.Calculations.Base.Qn;
using BLL.Calculations.Entities;
using BLL.Calculations.Entities.ConsGasQn;
using BLL.Calculations.Entities.QcRc;
using BLL.DataHelpers;
using BLL.DTO;
using BLL.Interfaces.BaseCalculations;
using BLL.Interfaces.BaseCalculations.Consumption;
using BLL.Interfaces.Calculations;
using BLL.Interfaces.Calculations.ConsGasQn;
using BLL.Interfaces.Services;
using BLL.Models.BaseModels.Characteristics.Gas;
using BLL.Models.BaseModels.QcRc;
using Business.Interfaces.BaseCalculations.Density;
using Moq;

namespace Tests
{
   public static class SetupHelper
   {
      public static Mock<ISteamCharacteristicsService> SteamSetup()
      {
         var MockSteam = new Mock<ISteamCharacteristicsService>();
         MockSteam.Setup(p => p.GetCharacteristics()).Returns(TestCalculatedDataHelper.SteamCharacteristicsData());
         return MockSteam;
      }
      public static Mock<IDryCokeProduction<DefaultDryCokeProduction>> DefaultDryCokeSetup()
      {
         Mock<IDryCokeProduction<DefaultDryCokeProduction>> MockDryCoke = new Mock<IDryCokeProduction<DefaultDryCokeProduction>>();
         var defaultDryCoke = new DefaultDryCokeProduction();

         MockDryCoke.Setup(p => p.Calc(It.IsAny<int>(), It.IsAny<decimal>()))
            .Returns((int cb, decimal cbCoef) => defaultDryCoke.Calc(cb, cbCoef));

         return MockDryCoke;
      }
      public static Mock<IChargeConsFV<DefaultChargeConsFV>> DefaultChargeConsFvSetup()
      {
         Mock<IChargeConsFV<DefaultChargeConsFV>> MockChargeConsFV = new Mock<IChargeConsFV<DefaultChargeConsFV>>();

         var chargeConsFV = new DefaultChargeConsFV(DefaultDryCokeSetup().Object);

         MockChargeConsFV.Setup(p => p.Calc(It.IsAny<int>(), It.IsAny<decimal>(), It.IsAny<decimal>()))
            .Returns((int cb, decimal cbCoef, decimal fvCoef) => chargeConsFV.Calc(cb, cbCoef, fvCoef));

         return MockChargeConsFV;
      }
      public static Mock<IQcRc> DefaultQcRcSetup()
      {
         var steam = SteamSetup().Object;
         var MockQcRc = new Mock<IQcRc>();
         MockQcRc.SetupProperty(p => p.SteamCharacteristicsService, steam);

         var defQcRc = new DefaultQcRc(steam);

         MockQcRc.Setup(p => p.Calc(It.IsAny<decimal>(), It.IsAny<decimal>(), It.IsAny<decimal>(), It.IsAny<decimal>(), It.Is<bool>(p => p)))
            .Returns((decimal cons, decimal wetGas, decimal temp, decimal density, bool perHour) =>
            defQcRc.Calc(cons, wetGas, temp, density, true));

         MockQcRc.Setup(p => p.Calc(It.IsAny<decimal>(), It.IsAny<decimal>(), It.IsAny<decimal>(), It.IsAny<decimal>(), It.Is<bool>(p => !p)))
            .Returns((decimal cons, decimal wetGas, decimal temp, decimal density, bool perHour) =>
            defQcRc.Calc(cons, wetGas, temp, density, false));

         return MockQcRc;
      }
      public static Mock<IConsGasQn<ConsGasQn1000>> Qn1000Setup()
      {
         var MockConsGasQn1000 = new Mock<IConsGasQn<ConsGasQn1000>>();

         var consGas1000 = new ConsGasQn1000();

         MockConsGasQn1000.Setup(p => p.Calc(It.IsAny<decimal>(), It.IsAny<decimal>()))
            .Returns((decimal qcrc, decimal qn) => consGas1000.Calc(qcrc, qn));

         return MockConsGasQn1000;
      }
      public static Mock<IConsGasQn<ConsGasQn4000>> Qn4000Setup()
      {
         var MockConsGasQn4000 = new Mock<IConsGasQn<ConsGasQn4000>>();

         var consGas4000 = new ConsGasQn4000();

         MockConsGasQn4000.Setup(p => p.Calc(It.IsAny<decimal>(), It.IsAny<decimal>()))
            .Returns((decimal qcrc, decimal qn) => consGas4000.Calc(qcrc, qn));

         return MockConsGasQn4000;
      }
      public static Mock<ICalcQcRc<QcRcKc1>> QcRcKc1DefaultSetup()
      {
         Mock<ICalcQcRc<QcRcKc1>> MockQcRcKc1 = new Mock<ICalcQcRc<QcRcKc1>>();
         ICalcQcRc<QcRcKc1> QcRcKc1Default = new CalcQcRcKc1(DefaultQcRcSetup().Object);

         MockQcRcKc1.Setup(p => p.Calc(It.IsAny<QcRcData>()))
         .Returns((QcRcData data) => QcRcKc1Default.Calc(data));

         MockQcRcKc1.Setup(p => p.QcRc).Returns(DefaultQcRcSetup().Object);

         return MockQcRcKc1;
      }
      public static Mock<ICalcQcRc<QcRcKc2>> QcRcKc2DefaultSetup()
      {
         Mock<ICalcQcRc<QcRcKc2>> MockQcRcKc2 = new Mock<ICalcQcRc<QcRcKc2>>();
         ICalcQcRc<QcRcKc2> QcRcKc2Default = new CalcQcRcKc2(DefaultQcRcSetup().Object);

         MockQcRcKc2.Setup(p => p.Calc(It.IsAny<QcRcData>()))
         .Returns((QcRcData data) => QcRcKc2Default.Calc(data));

         MockQcRcKc2.Setup(p => p.QcRc).Returns(DefaultQcRcSetup().Object);
          
         return MockQcRcKc2;
      }
      public static Mock<ICalcConsGasQnKc1> ConsQnKc1DefaultSetup()
      {
         Mock<ICalcQcRc<QcRcKc1>> MockQcRcKc1 = QcRcKc1DefaultSetup();
         Mock<IConsGasQn<ConsGasQn1000>> MockQn1000 = Qn1000Setup();

         Mock<ICalcConsGasQnKc1> MockConsGasQnKc1 = new Mock<ICalcConsGasQnKc1>();

         MockConsGasQnKc1.Setup(p => p.CalcQcRcKc1).Returns(MockQcRcKc1.Object);
         MockConsGasQnKc1.Setup(p => p.ConsGasQn).Returns(MockQn1000.Object);

         ICalcConsGasQnKc1 consqnKc1 = new CalcConsQnKc1(MockQcRcKc1.Object, MockQn1000.Object);

         MockConsGasQnKc1.Setup(p => p.Calc(It.IsAny<QcRcData>()))
            .Returns((QcRcData data) => consqnKc1.Calc(data));

         MockConsGasQnKc1.Setup(p => p.Calc(It.IsAny<QcRcKc1>(), It.IsAny<CharacteristicsDG>()))
            .Returns((QcRcKc1 kc1, CharacteristicsDG dGas) => consqnKc1.Calc(kc1, dGas));

         return MockConsGasQnKc1;
      }
      public static Mock<ICalcConsGasQnKc2> ConsQnKc2DefaultSetup()
      {
         Mock<ICalcQcRc<QcRcKc2>> MockQcRcKc2 = QcRcKc2DefaultSetup();
         Mock<IConsGasQn<ConsGasQn4000>> MockQn4000 = Qn4000Setup();

         Mock<ICalcConsGasQnKc2> MockConsGasQnKc2 = new Mock<ICalcConsGasQnKc2>();

         MockConsGasQnKc2.Setup(p => p.CalcQcRcKc2).Returns(MockQcRcKc2.Object);
         MockConsGasQnKc2.Setup(p => p.ConsGasQn).Returns(MockQn4000.Object);

         ICalcConsGasQnKc2 consqnKc2 = new CalcConsQnKc2(MockQcRcKc2.Object, MockQn4000.Object);

         MockConsGasQnKc2.Setup(p => p.Calc(It.IsAny<QcRcData>()))
            .Returns((QcRcData data) => consqnKc2.Calc(data));

         MockConsGasQnKc2.Setup(p => p.Calc(It.IsAny<QcRcKc2>(), It.IsAny<CharacteristicsKG>()))
            .Returns((QcRcKc2 kc2, CharacteristicsKG kGas) => consqnKc2.Calc(kc2, kGas));

         return MockConsGasQnKc2;
      }
      public static Mock<ICalcQcRc<CpsPpkQcRc>> QcRcCpsPpkDefaultSetup()
      {
         Mock<ICalcQcRc<CpsPpkQcRc>> MockQcRcCpsPpk = new Mock<ICalcQcRc<CpsPpkQcRc>>();
         ICalcQcRc<CpsPpkQcRc> QcRcCpsPpkDefault = new CalcQcRcCpsPpk(DefaultQcRcSetup().Object);

         MockQcRcCpsPpk.Setup(p => p.Calc(It.IsAny<QcRcData>()))
         .Returns((QcRcData data) => QcRcCpsPpkDefault.Calc(data));

         MockQcRcCpsPpk.Setup(p => p.QcRc).Returns(DefaultQcRcSetup().Object);

         return MockQcRcCpsPpk;
      }
      public static Mock<ICalcConsGasQnCpsPpk> ConsQnCpsPpkDefaultSetup()
      {
         Mock<ICalcConsGasQnCpsPpk> MockConsGasQnCpsPpk = new Mock<ICalcConsGasQnCpsPpk>();
         Mock<ICalcQcRc<CpsPpkQcRc>> MockQcRcCpsPpk = QcRcCpsPpkDefaultSetup();
         Mock<IConsGasQn<ConsGasQn4000>> MockQn4000 = Qn4000Setup();

         MockConsGasQnCpsPpk.Setup(p => p.CalcQcRcCpsPpk).Returns(MockQcRcCpsPpk.Object);
         MockConsGasQnCpsPpk.Setup(p => p.ConsGasQn).Returns(MockQn4000.Object);

         ICalcConsGasQnCpsPpk consqnCpsPpk = new CalcConsQnCpsPpk(MockQcRcCpsPpk.Object, MockQn4000.Object);

         MockConsGasQnCpsPpk.Setup(p => p.Calc(It.IsAny<QcRcData>()))
            .Returns((QcRcData data) => consqnCpsPpk.Calc(data));

         MockConsGasQnCpsPpk.Setup(p => p.Calc(It.IsAny<CpsPpkQcRc>(), It.IsAny<CharacteristicsKG>()))
            .Returns((CpsPpkQcRc qcrc, CharacteristicsKG kGas) => consqnCpsPpk.Calc(qcrc, kGas));

         return MockConsGasQnCpsPpk;
      }
      public static Mock<ICalculation<DensityDTO>> WetGasDensityDefaultSetup()
      {
         Mock<ISteamCharacteristicsService> MockSteam = SteamSetup();
         Mock<IDryDensity> MockDryDensity = new Mock<IDryDensity>();
         Mock<IWetDensity> MockWetDensity = new Mock<IWetDensity>();

         Mock<ICalculation<DensityDTO>> MockCalcWetGas = new Mock<ICalculation<DensityDTO>>();

         var DryDensity1 = new DryDensity(MockSteam.Object);

         MockDryDensity.Setup(p => p.Calc(It.IsAny<decimal>(), It.IsAny<decimal>(), It.IsAny<decimal>(), It.IsAny<decimal>()))
            .Returns((decimal pkg, decimal PPa, decimal pOver, decimal temp) =>
            DryDensity1.Calc(pkg, PPa, pOver, temp));

         MockDryDensity.Setup(p => p.Calc(It.IsAny<decimal>(), It.IsAny<decimal>(), It.IsAny<decimal>(), It.IsAny<decimal>(), It.IsAny<decimal>()))
            .Returns((decimal pkg, decimal PPa, decimal pOver, decimal temp, decimal tempDo) =>
            DryDensity1.Calc(pkg, PPa, pOver, temp, tempDo));

         var WetDensity1 = new WetDensity(MockSteam.Object);

         MockWetDensity.Setup(p => p.Calc(It.IsAny<decimal>(), It.IsAny<decimal>()))
            .Returns((decimal dryGas, decimal temp) =>
            WetDensity1.Calc(dryGas, temp));

         var CalcWetGas = new DefaultWetGasDensity(MockWetDensity.Object, MockDryDensity.Object);

         MockCalcWetGas.Setup(p => p.CalcEntity(It.IsAny<Data>()))
            .Returns((Data data) => CalcWetGas.CalcEntity(data));

         return MockCalcWetGas;
      }
   }
}
