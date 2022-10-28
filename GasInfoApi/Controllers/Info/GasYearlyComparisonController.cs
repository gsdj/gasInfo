using BLL.Interfaces.Services.Info;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GasInfoApi.Controllers.Info
{
   [Route("api/Info/[controller]")]
   [ApiController]
   public class GasYearlyComparisonController : ControllerBase
   {
      private readonly IChartService _service;
      public GasYearlyComparisonController(IChartService service)
      {
         _service = service;
      }
      // GET: api/<GasYearlyComparisonController>
      [HttpGet("{date}")]
      public IEnumerable<string> Get(DateTime date)
      {
         return new string[] { "value12", "value22" };
      }
   }
}
