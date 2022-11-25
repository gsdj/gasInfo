using BLL.DTO.Consumption;
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
   public class ConsumptionKgController : ControllerBase
   {
      private readonly IConsumptionKgService _service;
      private readonly ILogger<ConsumptionKgController> _logger; 
      public ConsumptionKgController(IConsumptionKgService service, ILogger<ConsumptionKgController> l)
      {
         _logger = l;
         try
         {
            _service = service;
         }
         catch (Exception ex)
         {
            _logger.LogError($"Error DI {ex.Message}{Environment.NewLine}{ex.StackTrace}");
            throw;
         }
      }
      // GET: api/Reporting/<ConsumptionKgController>/GetByDateMonth/{date}
      [HttpGet("GetByDateMonth/{date}")]
      public IEnumerable<ConsumptionKgDTO> Get(DateTime? date)
      {
         _logger.LogInformation($"Request path {Request.Path}");
         #if DEBUG
            var dt = new DateTime(2019, 01, 01);
         #else
            var dt = DateTime.Now;
         #endif

         DateTime Date = date ?? dt;
         var result = _service.GetItemsByMonth(Date);
         return result;
      }

      //[HttpGet("ReportExcel/{date}")]
      //public async Task<ActionResult> GetFile()
      //{
      //   _logger.LogInformation($"Request path {Request.Path}");
      //   string fn = "SteamCharacteristics.json";
      //   byte[] fileContent = await System.IO.File.ReadAllBytesAsync($"wwwroot\\files\\{fn}");
      //   return File(fileContent, "application/octet-stream", fn);
      //}
   }
}
