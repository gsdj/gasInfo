using DA.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DA.ConfigurationsEntities
{
   public class KgChmkEbConfiguration : IEntityTypeConfiguration<KgChmkEb>
   {
      public void Configure(EntityTypeBuilder<KgChmkEb> builder)
      {
         builder.ToTable("KgChmkEb");
         builder.HasKey(p => p.Id);
         builder.HasIndex(p => p.Date).IsUnique();
         builder.Property(p => p.Date).IsRequired().HasColumnType("Date");
         builder.Property(p => p.Consumption).HasColumnType("numeric").HasPrecision(17, 10);
      }
   }
}
