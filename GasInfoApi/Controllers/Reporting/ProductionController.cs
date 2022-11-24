using BLL.DTO;
using BLL.Interfaces.Services.Report;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GasInfoApi.Controllers.Reporting
{
   [Route("api/Reporting/[controller]")]
   [Produces("application/json")]
   [ApiController]
   public class ProductionController : ControllerBase
   {
      private readonly IProductionService _service;
      private readonly ILogger<ProductionController> _logger; 
      public ProductionController(IProductionService service, ILogger<ProductionController> l)
      {
         _logger = l;
         _service = service;
         _logger.LogInformation($"ctor production {Request.Path}");
      }
      // GET: api/<ProductionController>
      [HttpGet("GetByDateMonth/{date}")]
      public IEnumerable<ProductionDTO> Get(DateTime? date)
      {
         _logger.LogInformation($"Production {Request.Path}");

         #if DEBUG
            var dt = new DateTime(2019, 01, 01);
         #else
            var dt = DateTime.Now;
         #endif

         DateTime Date = date ?? dt;
         var result = _service.GetItemsByMonth(Date);
         return result;
      }
      [HttpGet("GetString")]
      public string GetString()
      {
         return "GetString";
      }

      [HttpGet("ReportExcel/{date}")]
      public async Task<ActionResult> GetFile()
      {
         string fn = "SteamCharacteristics.json";
         byte[] fileContent = await System.IO.File.ReadAllBytesAsync($"wwwroot\\files\\{fn}");
         return File(fileContent, "application/octet-stream", fn);
      }
   }
}
