using DA.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace DA.ConfigurationsEntities
{
   public class KgChmkEbConfiguration : IEntityTypeConfiguration<KgChmkEb>
   {
      public KgChmkEbConfiguration() { }
      public KgChmkEbConfiguration(InitialDataSettings initialData)
      {
         InitialData = initialData;
      }
      private InitialDataSettings InitialData;
      public void Configure(EntityTypeBuilder<KgChmkEb> builder)
      {
         IEnumerable<KgChmkEb> data;

         using (StreamReader r = new StreamReader(InitialData.Path))
         {
            string json = r.ReadToEnd();
            data = JsonConvert.DeserializeObject<IEnumerable<KgChmkEb>>(json);
         }

         builder.ToTable("KgChmkEb");
         builder.HasKey(p => p.Id);
         builder.HasIndex(p => p.Date).IsUnique();
         builder.Property(p => p.Date).IsRequired().HasColumnType("Date");
         builder.Property(p => p.Consumption).HasColumnType("numeric").HasPrecision(20, 10);

         builder.HasData(data);
      }
   }
}
