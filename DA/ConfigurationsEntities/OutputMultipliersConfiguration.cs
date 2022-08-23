using DA.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DA.ConfigurationsEntities
{
   public class OutputMultipliersConfiguration : IEntityTypeConfiguration<OutputMultipliers>
   {
      public void Configure(EntityTypeBuilder<OutputMultipliers> builder)
      {
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
      }
   }
}
