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
      }
   }
}
