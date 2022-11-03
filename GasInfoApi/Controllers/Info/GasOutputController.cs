using BLL.DTO.Charts;
using BLL.Interfaces.Services.Info;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace GasInfoApi.Controllers.Info
{
   [Route("api/Info/[controller]")]
   [Produces("application/json")]
   [ApiController]
   public class GasOutputController : ControllerBase
   {
      private readonly IChartService _service;
      public GasOutputController(IChartService service)
      {
         _service = service;
      }
      // GET: api/<GasOutputController>
      [HttpGet("{date}")]
      public IEnumerable<ChartMonthDTO> Get(DateTime? date)
      {
         #if DEBUG
            var dt = new DateTime(2019, 01, 01);
         #else
            var dt = DateTime.Now;
         #endif

         DateTime Date = date ?? dt;
         var result = _service.GasOutputPerMonth(Date);
         return result;
      }
   }
}
