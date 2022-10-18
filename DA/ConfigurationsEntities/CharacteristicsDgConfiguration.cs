using DA.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace DA.ConfigurationsEntities
{
   public class CharacteristicsDgConfiguration : IEntityTypeConfiguration<CharacteristicsDgAll>
   {
      public CharacteristicsDgConfiguration() { }
      public CharacteristicsDgConfiguration(InitialDataSettings initialData)
      {
         InitialData = initialData;
      }
      private InitialDataSettings InitialData;
      public void Configure(EntityTypeBuilder<CharacteristicsDgAll> builder)
      {
         IEnumerable<CharacteristicsDgAll> data;

         using (StreamReader r = new StreamReader(InitialData.Path))
         {
            string json = r.ReadToEnd();
            data = JsonConvert.DeserializeObject<IEnumerable<CharacteristicsDgAll>>(json);
         }

         builder.ToTable("CharacteristicsDg");
         builder.HasKey(p => p.Id);
         builder.HasIndex(p => p.Date).IsUnique();
         builder.Property(p => p.Date).IsRequired().HasColumnType("Date");

         builder.OwnsOne(p => p.Kc1, a => 
         {
            a.Property(p => p.H2).HasColumnType("numeric").HasPrecision(8, 3);
            a.Property(p => p.N2).HasColumnType("numeric").HasPrecision(8, 3);
            a.Property(p => p.CO).HasColumnType("numeric").HasPrecision(8, 3);
            a.Property(p => p.CO2).HasColumnType("numeric").HasPrecision(8, 3);
         });

         builder.OwnsOne(p => p.Kc2, a =>
         {
            a.Property(p => p.H2).HasColumnType("numeric").HasPrecision(8, 3);
            a.Property(p => p.N2).HasColumnType("numeric").HasPrecision(8, 3);
            a.Property(p => p.CO).HasColumnType("numeric").HasPrecision(8, 3);
            a.Property(p => p.CO2).HasColumnType("numeric").HasPrecision(8, 3);
         });

         builder.HasData(data);
      }
   }
}
