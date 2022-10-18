using DA.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace DA.ConfigurationsEntities
{
   public class PressureConfiguration : IEntityTypeConfiguration<Pressure>
   {
      public PressureConfiguration() { }
      public PressureConfiguration(InitialDataSettings initialData)
      {
         InitialData = initialData;
      }
      private InitialDataSettings InitialData;
      public void Configure(EntityTypeBuilder<Pressure> builder)
      {
         IEnumerable<Pressure> data;

         using (StreamReader r = new StreamReader(InitialData.Path))
         {
            string json = r.ReadToEnd();
            data = JsonConvert.DeserializeObject<IEnumerable<Pressure>>(json);
         }

         builder.ToTable("Pressure");
         builder.HasKey(p => p.Id);
         builder.HasIndex(p => p.Date).IsUnique();
         builder.Property(p => p.Date).IsRequired().HasColumnType("Date");
         builder.Property(p => p.Value).IsRequired().HasColumnType("numeric").HasPrecision(8, 3);

         builder.HasData(data);
      }
   }
}
