using DA.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DA.ConfigurationsEntities
{
   public class RolesConfiguration : IEntityTypeConfiguration<Role>
   {
      public void Configure(EntityTypeBuilder<Role> builder)
      {
         builder.ToTable("Roles");
         builder.HasKey(p => p.Id);
      }
   }
}
