using GasInfoApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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

      [HttpGet("Test")]
      public TestViewModel GetTest()
      {
         List<Test> t = new List<Test>
         {
            new Test { Id = 1, Date = DateTime.Now, Cb1 = 12.4m, Cb2 = 13.4m, Cb3 = 14.4m, Cb4 = 15.4m, },
            new Test { Id = 2, Date = DateTime.Now, Cb1 = 41.4m, Cb2 = 12.4m, Cb3 = 13.4m, Cb4 = 14.4m, }
         };

         List<HeaderTh> h1 = new List<HeaderTh>
         {
            new HeaderTh { RowSpan = 1, ColSpan = 1, Name = "Дата" },
            new HeaderTh { RowSpan = 1, ColSpan = 2, Name = "Кц1" },
            new HeaderTh { RowSpan = 1, ColSpan = 2, Name = "Кц2" },
         };

         List<HeaderTh> h2 = new List<HeaderTh>
         {
            new HeaderTh { RowSpan = 1, ColSpan = 1, Name = "Кб1" },
            new HeaderTh { RowSpan = 1, ColSpan = 1, Name = "Кб2" },
            new HeaderTh { RowSpan = 1, ColSpan = 1, Name = "Кб3" },
            new HeaderTh { RowSpan = 1, ColSpan = 1, Name = "Кб4" },
         };


         TestViewModel tvm = new TestViewModel
         {
            Names = new List<IEnumerable<HeaderTh>> { h1, h2 },
            TestList = t,
         };

         return tvm;
      }
   }

   public class Test
   {
      public int Id { get; set; }
      public DateTime Date { get; set; }
      public decimal Cb1 { get; set; }
      public decimal Cb2 { get; set; }
      public decimal Cb3 { get; set; }
      public decimal Cb4 { get; set; }
   }

   public class HeaderTh
   {
      public int RowSpan { get; set; }
      public int ColSpan { get; set; }
      public string Name { get; set; }

   }

   public class TestViewModel
   {
      public IEnumerable<IEnumerable<HeaderTh>> Names { get; set; }
      public IEnumerable<Test> TestList { get; set; }
   }

}
