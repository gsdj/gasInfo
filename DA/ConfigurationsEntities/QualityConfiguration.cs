using DA.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace DA.ConfigurationsEntities
{
   public class QualityConfiguration : IEntityTypeConfiguration<QualityAll>
   {
      public QualityConfiguration() { }
      public QualityConfiguration(InitialDataSettings initialData)
      {
         InitialData = initialData;
      }
      private InitialDataSettings InitialData;
      public void Configure(EntityTypeBuilder<QualityAll> builder)
      {
         IEnumerable<QualityAll> data;

         using (StreamReader r = new StreamReader(InitialData.Path))
         {
            string json = r.ReadToEnd();
            data = JsonConvert.DeserializeObject<IEnumerable<QualityAll>>(json);
         }

         builder.ToTable("Quality");
         builder.HasKey(p => p.Id);
         builder.HasIndex(p => p.Date).IsUnique();
         builder.Property(p => p.Date).IsRequired().HasColumnType("Date");

         builder.OwnsOne(p => p.Kc1, a => 
         {
            a.Property(p => p.W).HasColumnType("numeric").HasPrecision(8, 3);
            a.Property(p => p.A).HasColumnType("numeric").HasPrecision(8, 3);
            a.Property(p => p.V).HasColumnType("numeric").HasPrecision(8, 3);
         });

         builder.OwnsOne(p => p.Kc2, a =>
         {
            a.Property(p => p.W).HasColumnType("numeric").HasPrecision(8, 3);
            a.Property(p => p.A).HasColumnType("numeric").HasPrecision(8, 3);
            a.Property(p => p.V).HasColumnType("numeric").HasPrecision(8, 3);
         });

         builder.HasData(data);
      }
   }
}
