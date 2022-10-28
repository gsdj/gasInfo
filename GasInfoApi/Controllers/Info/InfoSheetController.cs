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
   public class InfoSheetController : ControllerBase
   {
      private readonly IInfoSheetService _service;
      public InfoSheetController(IInfoSheetService service)
      {
         _service = service;
      }

      // GET api/<InfoSheetController>/2022-01-01
      [HttpGet("{date}")]
      public string Get(DateTime? date)
      {
         return date.ToString();
      }
   }
}
