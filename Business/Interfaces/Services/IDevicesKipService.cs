﻿using Business.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces.Services
{
   public interface IDevicesKipService : IWritable<DevicesKipDTO>, IDatable<DevicesKipDTO>, IMonthable<DevicesKipDTO>
   {
   }
}
