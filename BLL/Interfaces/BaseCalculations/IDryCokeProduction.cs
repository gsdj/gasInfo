﻿namespace BLL.Interfaces.BaseCalculations
{
   public interface IDryCokeProduction<T>
   {
      decimal Calc(int cbAmmount, decimal cbCoef);
   }
}
