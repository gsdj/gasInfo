using DA.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace DA.ConfigurationsEntities
{
   public class TecConfiguration : IEntityTypeConfiguration<Tec>
   {
      public TecConfiguration() { }
      public TecConfiguration(InitialDataSettings initialData)
      {
         InitialData = initialData;
      }
      private InitialDataSettings InitialData;
      public void Configure(EntityTypeBuilder<Tec> builder)
      {
         IEnumerable<Tec> data;

         using (StreamReader r = new StreamReader(InitialData.Path))
         {
            string json = r.ReadToEnd();
            data = JsonConvert.DeserializeObject<IEnumerable<Tec>>(json);
         }

         builder.ToTable("Tec");
         builder.HasKey(p => p.Id);
         builder.HasIndex(p => p.Date).IsUnique();
         builder.Property(p => p.Date).IsRequired().HasColumnType("Date");
         builder.Property(p => p.TecNorth).HasColumnType("numeric").HasPrecision(16, 10);
         builder.Property(p => p.TecSouth).HasColumnType("numeric").HasPrecision(16, 10);
         builder.Property(p => p.Chmk).HasColumnType("numeric").HasPrecision(16, 10);

         builder.HasData(data);
      }
   }
}
