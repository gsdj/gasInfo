using DA.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DA.ConfigurationsEntities
{
   public class CharacteristicsDgConfiguration : IEntityTypeConfiguration<CharacteristicsDgAll>
   {
      public void Configure(EntityTypeBuilder<CharacteristicsDgAll> builder)
      {
         builder.ToTable("CharacteristicsDg");
         builder.HasKey(p => p.Id);
         builder.HasIndex(p => p.Date).IsUnique();
         builder.Property(p => p.Date).IsRequired().HasColumnType("Date");
         builder.Property(p => p.Kc1.H2).HasColumnType("numeric").HasPrecision(8, 3);
         builder.Property(p => p.Kc1.N2).HasColumnType("numeric").HasPrecision(8, 3);
         builder.Property(p => p.Kc1.CO).HasColumnType("numeric").HasPrecision(8, 3);
         builder.Property(p => p.Kc1.CO2).HasColumnType("numeric").HasPrecision(8, 3);

         builder.Property(p => p.Kc2.H2).HasColumnType("numeric").HasPrecision(8, 3);
         builder.Property(p => p.Kc2.N2).HasColumnType("numeric").HasPrecision(8, 3);
         builder.Property(p => p.Kc2.CO).HasColumnType("numeric").HasPrecision(8, 3);
         builder.Property(p => p.Kc2.CO2).HasColumnType("numeric").HasPrecision(8, 3);
      }
   }
}
