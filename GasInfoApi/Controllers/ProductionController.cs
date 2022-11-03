using BLL.DTO;
using BLL.Interfaces.Services.Report;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GasInfoApi.Controllers
{
   [ApiController]
   [Route("[controller]")]
   public class ProductionController : ControllerBase
   {
      private readonly ILogger<ProductionController> _logger;
      private readonly IProductionService _service;

      public ProductionController(ILogger<ProductionController> logger, IProductionService service)
      {
         _logger = logger;
         _service = service;
      }

      [HttpGet]
      public IEnumerable<ProductionDTO> Get(DateTime? date)
      {
         var dt = new DateTime(2019, 01, 01);
         DateTime Date = date ?? dt;
         var result = _service.GetItemsByMonth(Date);
         return result;
      }

      [HttpGet("files")]
      public async Task<ActionResult> GetFile()
      {
         string fn = "SteamCharacteristics.json";
         byte[] fileContent = await System.IO.File.ReadAllBytesAsync($"wwwroot\\files\\{fn}");
         return File(fileContent, "application/octet-stream", fn);
      }
   }
}
