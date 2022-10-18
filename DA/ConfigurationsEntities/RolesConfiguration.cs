using DA.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DA.ConfigurationsEntities
{
   public class RolesConfiguration : IEntityTypeConfiguration<Role>
   {
      public void Configure(EntityTypeBuilder<Role> builder)
      {
         string adminRoleName = "Admin";
         string userRoleName = "User";

         Role adminRole = new Role { Id = 1, Name = adminRoleName };
         Role userRole = new Role { Id = 2, Name = userRoleName };

         builder.ToTable("Roles");
         builder.HasKey(p => p.Id);

         builder.HasData(new Role[] { adminRole, userRole });
      }
   }
}
