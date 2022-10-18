using DA.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace DA.ConfigurationsEntities
{
   public class OutputMultipliersConfiguration : IEntityTypeConfiguration<OutputMultipliers>
   {
      public OutputMultipliersConfiguration() { }
      public OutputMultipliersConfiguration(InitialDataSettings initialData)
      {
         InitialData = initialData;
      }
      private InitialDataSettings InitialData;
      public void Configure(EntityTypeBuilder<OutputMultipliers> builder)
      {
         IEnumerable<OutputMultipliers> data;

         using (StreamReader r = new StreamReader(InitialData.Path))
         {
            string json = r.ReadToEnd();
            data = JsonConvert.DeserializeObject<IEnumerable<OutputMultipliers>>(json);
         }

         builder.ToTable("OutputMultipliers");
         builder.HasKey(p => p.Id);
         builder.HasIndex(p => p.Date).IsUnique();
         builder.Property(p => p.Date).IsRequired().HasColumnType("Date");
         builder.Property(p => p.Cb1).HasColumnType("numeric").HasPrecision(14, 10);
         builder.Property(p => p.Cb2).HasColumnType("numeric").HasPrecision(14, 10);
         builder.Property(p => p.Cb3).HasColumnType("numeric").HasPrecision(14, 10);
         builder.Property(p => p.Cb4).HasColumnType("numeric").HasPrecision(14, 10);
         builder.Property(p => p.Cb5).HasColumnType("numeric").HasPrecision(14, 10);
         builder.Property(p => p.Cb6).HasColumnType("numeric").HasPrecision(14, 10);
         builder.Property(p => p.Cb7).HasColumnType("numeric").HasPrecision(14, 10);
         builder.Property(p => p.Cb8).HasColumnType("numeric").HasPrecision(14, 10);
         builder.Property(p => p.PKP).HasColumnType("numeric").HasPrecision(14, 10);
         builder.Property(p => p.Sv).HasColumnType("numeric").HasPrecision(14, 10);
         builder.Property(p => p.Fv).HasColumnType("numeric").HasPrecision(14, 10);
         builder.Property(p => p.Peka).HasColumnType("numeric").HasPrecision(14, 10);

         builder.HasData(data);
      }
   }
}
