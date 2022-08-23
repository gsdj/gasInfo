using DA.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DA.ConfigurationsEntities
{
   public class PressureConfiguration : IEntityTypeConfiguration<Pressure>
   {
      public void Configure(EntityTypeBuilder<Pressure> builder)
      {
         builder.ToTable("Pressure");
         builder.HasKey(p => p.Id);
         builder.HasIndex(p => p.Date).IsUnique();
         builder.Property(p => p.Date).IsRequired().HasColumnType("Date");
         builder.Property(p => p.Value).IsRequired().HasColumnType("numeric").HasPrecision(8, 3);
      }
   }
}
