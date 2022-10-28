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
   public class GasOutputController : ControllerBase
   {
      private readonly IChartService _service;
      public GasOutputController(IChartService service)
      {
         _service = service;
      }
      // GET: api/<GasOutputController>
      [HttpGet("{date}")]
      public IEnumerable<string> Get(DateTime date)
      {
         return new string[] { "value1", "value2" };
      }
   }
}
