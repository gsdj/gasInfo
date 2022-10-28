using BLL.Interfaces.Services.Report;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GasInfoApi.Controllers.Reporting
{
   [Route("api/Reporting/[controller]")]
   [Produces("application/json")]
   [ApiController]
   public class ConsumptionKgController : ControllerBase
   {
      private readonly IConsumptionKgService _service;
      public ConsumptionKgController(IConsumptionKgService service)
      {
         _service = service;
      }
      // GET: api/<ConsumptionKgController>
      [HttpGet("{date}")]
      public IEnumerable<string> Get(DateTime? date)
      {
         return new string[] { "value1", "value2" };
      }
   }
}
