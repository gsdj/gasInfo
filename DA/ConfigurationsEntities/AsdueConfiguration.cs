using DA.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace DA.ConfigurationsEntities
{
   public class AsdueConfiguration : IEntityTypeConfiguration<Asdue>
   {
      public AsdueConfiguration() { }
      public AsdueConfiguration(InitialDataSettings initialData)
      {
         InitialData = initialData;
      }
      private InitialDataSettings InitialData;
      public void Configure(EntityTypeBuilder<Asdue> builder)
      {
         IEnumerable<Asdue> data;

         using (StreamReader r = new StreamReader(InitialData.Path))
         {
            string json = r.ReadToEnd();
            data = JsonConvert.DeserializeObject<IEnumerable<Asdue>>(json);
         }

         builder.ToTable("Asdue");
         builder.HasKey(p => p.Id);
         builder.HasIndex(p => p.Date).IsUnique();
         builder.Property(p => p.Date).IsRequired().HasColumnType("Date");
         builder.Property(p => p.TecNorth).HasColumnType("numeric").HasPrecision(16, 6);
         builder.Property(p => p.TecSouth).HasColumnType("numeric").HasPrecision(16, 6);
         builder.Property(p => p.Gps2Gss1).HasColumnType("numeric").HasPrecision(16, 6);
         builder.Property(p => p.Gps2Gss2).HasColumnType("numeric").HasPrecision(16, 6);
         builder.Property(p => p.NaturalGasQn).HasColumnType("numeric").HasPrecision(8, 3);
         builder.Property(p => p.OutPkg).HasColumnType("numeric").HasPrecision(8, 3);

         builder.HasData(data);
      }
   }
}
