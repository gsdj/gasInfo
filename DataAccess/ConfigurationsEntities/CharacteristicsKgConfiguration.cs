using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.ConfigurationsEntities
{
   public class CharacteristicsKgConfiguration : IEntityTypeConfiguration<CharacteristicsKgAll>
   {
      public void Configure(EntityTypeBuilder<CharacteristicsKgAll> builder)
      {
         builder.ToTable("CharacteristicsKg");
         builder.HasKey(p => p.Id);
         builder.HasIndex(p => p.Date).IsUnique();
         builder.Property(p => p.Date).IsRequired().HasColumnType("Date");
         builder.Property(p => p.Kc1.H2).HasColumnType("numeric").HasPrecision(8, 3);
         builder.Property(p => p.Kc1.N2).HasColumnType("numeric").HasPrecision(8, 3);
         builder.Property(p => p.Kc1.CO).HasColumnType("numeric").HasPrecision(8, 3);
         builder.Property(p => p.Kc1.CO2).HasColumnType("numeric").HasPrecision(8, 3);
         builder.Property(p => p.Kc1.CH4).HasColumnType("numeric").HasPrecision(8, 3);
         builder.Property(p => p.Kc1.CnHm).HasColumnType("numeric").HasPrecision(8, 3);
         builder.Property(p => p.Kc1.O2).HasColumnType("numeric").HasPrecision(8, 3);

         builder.Property(p => p.Kc2.H2).HasColumnType("numeric").HasPrecision(8, 3);
         builder.Property(p => p.Kc2.N2).HasColumnType("numeric").HasPrecision(8, 3);
         builder.Property(p => p.Kc2.CO).HasColumnType("numeric").HasPrecision(8, 3);
         builder.Property(p => p.Kc2.CO2).HasColumnType("numeric").HasPrecision(8, 3);
         builder.Property(p => p.Kc2.CH4).HasColumnType("numeric").HasPrecision(8, 3);
         builder.Property(p => p.Kc2.CnHm).HasColumnType("numeric").HasPrecision(8, 3);
         builder.Property(p => p.Kc2.O2).HasColumnType("numeric").HasPrecision(8, 3);
      }
   }
}
