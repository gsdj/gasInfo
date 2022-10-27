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
      public IEnumerable<ProductionDTO> Get()
      {
         var result = _service.GetItemsByMonth(new DateTime(2019, 01, 01));
         return result;
      }
   }
}
