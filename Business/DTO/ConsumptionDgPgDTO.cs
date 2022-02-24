﻿using Business.DTO.Consumption;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTO
{
   public class ConsumptionDgPgDTO
   {
      public DateTime Date { get; set; }
      public ConsumptionKc1<decimal> ConsumtionDg { get; set; }
      public decimal ConsumtionDgKc1 { get; set; }
      public ConsumptionKc1<decimal> ConsumtionPg { get; set; }
      public decimal ConsumtionPgKc1 { get; set; }
      public ConsumptionGru<decimal> ConsumptionPgGru { get; set; }
      public ConsumptionGru<decimal> UdConsumptionPgGru { get; set; }
      public ConsumptionKc1<decimal> UdConsumtionKgFv { get; set; }
      public decimal UdConsumtionKgFvKc1 { get; set; }
   }
}
