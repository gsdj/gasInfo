using DA.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DA.ConfigurationsEntities
{
   public class QualityConfiguration : IEntityTypeConfiguration<QualityAll>
   {
      public void Configure(EntityTypeBuilder<QualityAll> builder)
      {
         builder.ToTable("Quality");
         builder.HasKey(p => p.Id);
         builder.HasIndex(p => p.Date).IsUnique();
         builder.Property(p => p.Date).IsRequired().HasColumnType("Date");
         builder.Property(p => p.Kc1.W).HasColumnType("numeric").HasPrecision(8, 3);
         builder.Property(p => p.Kc1.A).HasColumnType("numeric").HasPrecision(8, 3);
         builder.Property(p => p.Kc1.V).HasColumnType("numeric").HasPrecision(8, 3);

         builder.Property(p => p.Kc2.W).HasColumnType("numeric").HasPrecision(8, 3);
         builder.Property(p => p.Kc2.A).HasColumnType("numeric").HasPrecision(8, 3);
         builder.Property(p => p.Kc2.V).HasColumnType("numeric").HasPrecision(8, 3);
      }
   }
}
