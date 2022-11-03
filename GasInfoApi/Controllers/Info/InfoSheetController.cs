using BLL.DTO;
using BLL.Interfaces.Services.Info;
using Microsoft.AspNetCore.Mvc;
using System;

namespace GasInfoApi.Controllers.Info
{
   [Route("api/Info/[controller]")]
   [Produces("application/json")]
   [ApiController]
   public class InfoSheetController : ControllerBase
   {
      private readonly IInfoSheetService _service;
      public InfoSheetController(IInfoSheetService service)
      {
         _service = service;
      }

      // GET api/<InfoSheetController>/2022-01-01
      [HttpGet("{date}")]
      public InfoSheetDTO Get(DateTime? date)
      {
         #if DEBUG
            var dt = new DateTime(2019, 01, 01);
         #else
            var dt = DateTime.Now;
         #endif

         DateTime Date = date ?? dt;
         var result = _service.GetItemByDate(Date);
         return result;
      }
   }
}
