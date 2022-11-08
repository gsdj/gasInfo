using GasInfoApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace GasInfoApi.Controllers.Reporting
{
   [Route("api/[controller]")]
   [Produces("application/json")]
   [ApiController]
   public class ReportingController : ControllerBase
   {
      public ReportingController()
      {
      }
      // GET: api/<ReportingController>
      [HttpGet]
      public IEnumerable<ReportingValue> Get()
      {
         var res = new List<ReportingValue>
         {
            new ReportingValue { Name = "ConsumptionKg", Value = "api/Reporting/ConsumptionKg/GetByDateMonth" },
            new ReportingValue { Name = "ReportKg", Value = "api/Reporting/ReportKg/GetByDateMonth" },
            new ReportingValue { Name = "Production", Value = "api/Reporting/Production/GetByDateMonth" },
         };

         return res;
      }
   }
}
