using DA.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DA.ConfigurationsEntities
{
   public class AsdueConfiguration : IEntityTypeConfiguration<Asdue>
   {
      public void Configure(EntityTypeBuilder<Asdue> builder)
      {
         builder.ToTable("Asdue");
         builder.HasKey(p => p.Id);
         builder.HasIndex(p => p.Date).IsUnique();
         builder.Property(p => p.Date).IsRequired().HasColumnType("Date");
         builder.Property(p => p.TecNorth).HasColumnType("numeric").HasPrecision(16, 6);
         builder.Property(p => p.TecSouth).HasColumnType("numeric").HasPrecision(16, 6);
         builder.Property(p => p.Gps2Gss1).HasColumnType("numeric").HasPrecision(16, 6);
         builder.Property(p => p.Gps2Gss2).HasColumnType("numeric").HasPrecision(16, 6);
         builder.Property(p => p.NaturalGasQn).HasColumnType("numeric").HasPrecision(8, 3);
         builder.Property(p => p.OutPkg).HasColumnType("numeric").HasPrecision(8, 3);
      }
   }
}
