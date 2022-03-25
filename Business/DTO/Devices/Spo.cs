﻿using DataAccess.Entities.Characteristics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTO.Devices
{
   public class Spo : Device
   {
      public int Consumption { get; set; } = 0;
   }
}