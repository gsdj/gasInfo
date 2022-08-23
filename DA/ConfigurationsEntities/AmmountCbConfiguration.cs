using DA.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DA.ConfigurationsEntities
{
   public class AmmountCbConfiguration : IEntityTypeConfiguration<AmmountCb>
   {
      public void Configure(EntityTypeBuilder<AmmountCb> builder)
      {
         builder.ToTable("AmmountCb");
         builder.HasKey(p => p.Id);
         builder.HasIndex(p => p.Date).IsUnique();
         builder.Property(p => p.Date).IsRequired().HasColumnType("Date");
      }
   }
}
