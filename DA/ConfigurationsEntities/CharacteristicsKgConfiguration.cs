using DA.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DA.ConfigurationsEntities
{
   public class CharacteristicsKgConfiguration : IEntityTypeConfiguration<CharacteristicsKgAll>
   {
      public void Configure(EntityTypeBuilder<CharacteristicsKgAll> builder)
      {
         builder.ToTable("CharacteristicsKg");
         builder.HasKey(p => p.Id);
         builder.HasIndex(p => p.Date).IsUnique();
         builder.Property(p => p.Date).IsRequired().HasColumnType("Date");

         builder.OwnsOne(p => p.Kc1, a => 
         {
            a.Property(p => p.H2).HasColumnType("numeric").HasPrecision(8, 3);
            a.Property(p => p.N2).HasColumnType("numeric").HasPrecision(8, 3);
            a.Property(p => p.CO).HasColumnType("numeric").HasPrecision(8, 3);
            a.Property(p => p.CO2).HasColumnType("numeric").HasPrecision(8, 3);
            a.Property(p => p.CH4).HasColumnType("numeric").HasPrecision(8, 3);
            a.Property(p => p.CnHm).HasColumnType("numeric").HasPrecision(8, 3);
            a.Property(p => p.O2).HasColumnType("numeric").HasPrecision(8, 3);
         });

         builder.OwnsOne(p => p.Kc2, a =>
         {
            a.Property(p => p.H2).HasColumnType("numeric").HasPrecision(8, 3);
            a.Property(p => p.N2).HasColumnType("numeric").HasPrecision(8, 3);
            a.Property(p => p.CO).HasColumnType("numeric").HasPrecision(8, 3);
            a.Property(p => p.CO2).HasColumnType("numeric").HasPrecision(8, 3);
            a.Property(p => p.CH4).HasColumnType("numeric").HasPrecision(8, 3);
            a.Property(p => p.CnHm).HasColumnType("numeric").HasPrecision(8, 3);
            a.Property(p => p.O2).HasColumnType("numeric").HasPrecision(8, 3);
         });
      }
   }
}
