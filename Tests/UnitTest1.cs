using Business.BusinessModels.BaseCalculations;
using DataAccess.Entities;
using Newtonsoft.Json;
using System;
using Xunit;

namespace Tests
{
   public class UnitTest1
   {
      [Fact]
      public void Test1()
      {
         var expected = "1,842";
         var target = new TestAppSettings().Test();
         Assert.Equal(expected, target);
         //var guid = Guid.NewGuid();
         //var dt = DateTime.Now;
         //Pressure p1 = new Pressure
         //{
         //   Id = guid,
         //   Date = dt,
         //   Value = 10,
         //};
         //Pressure p2 = new Pressure
         //{
         //   Id = guid,
         //   Date = dt,
         //   Value = 101,
         //};
         //var obj1 = JsonConvert.SerializeObject(p1);
         //var obj2 = JsonConvert.SerializeObject(p2);
         //Assert.Equal(obj1, obj2);
      }
   }
}
