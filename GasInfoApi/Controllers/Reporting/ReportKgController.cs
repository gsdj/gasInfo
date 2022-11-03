using BLL.DTO;
using BLL.Interfaces.Services.Report;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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
      [HttpGet("GetByDateMonth")]
      public IEnumerable<ReportKgDTO> Get(DateTime? date)
      {
         #if DEBUG
            var dt = new DateTime(2019, 01, 01);
         #else
            var dt = DateTime.Now;
         #endif

         DateTime Date = date ?? dt;
         var result = _service.GetItemsByMonth(Date);
         return result;
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
