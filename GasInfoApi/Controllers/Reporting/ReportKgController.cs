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
   public class ReportKgController : ControllerBase
   {
      private readonly IReportKgService _service;
      public ReportKgController(IReportKgService service)
      {
         _service = service;
      }
      // GET api/<ReportKgController>/5
      [HttpGet("{date}")]
      public IEnumerable<string> Get(DateTime? date)
      {
         return new string[] { "value1", "value2" };
      }
   }
}
