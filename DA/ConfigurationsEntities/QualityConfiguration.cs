using DA.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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
         #region InitData
         var baseData = data.Select(x => new QualityAll
         {
            Id = x.Id,
            Date = x.Date,
         });

         var kc1Data = data.Select(x => new
         {
            QualityAllId = x.Id,
            x.Kc1.A,
            x.Kc1.W,
            x.Kc1.V,
         });

         var kc2Data = data.Select(x => new
         {
            QualityAllId = x.Id,
            x.Kc2.A,
            x.Kc2.W,
            x.Kc2.V,
         });
         #endregion
         #region Configuration
         builder.ToTable("Quality");
         builder.HasKey(p => p.Id);
         builder.HasIndex(p => p.Date).IsUnique();
         builder.Property(p => p.Date).IsRequired().HasColumnType("Date");

         builder.HasData(baseData);

         builder.OwnsOne(p => p.Kc1, a => 
         {
            a.Property(p => p.W).HasColumnType("numeric").HasPrecision(8, 3);
            a.Property(p => p.A).HasColumnType("numeric").HasPrecision(8, 3);
            a.Property(p => p.V).HasColumnType("numeric").HasPrecision(8, 3);
            a.HasData(kc1Data);
         });

         builder.OwnsOne(p => p.Kc2, a =>
         {
            a.Property(p => p.W).HasColumnType("numeric").HasPrecision(8, 3);
            a.Property(p => p.A).HasColumnType("numeric").HasPrecision(8, 3);
            a.Property(p => p.V).HasColumnType("numeric").HasPrecision(8, 3);
            a.HasData(kc2Data);
         });
         #endregion
      }
   }
}
