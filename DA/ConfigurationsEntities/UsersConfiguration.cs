using DA.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DA.ConfigurationsEntities
{
   public class UsersConfiguration : IEntityTypeConfiguration<User>
   {
      public void Configure(EntityTypeBuilder<User> builder)
      {
         string adminLogin = "AsupAdmin";
         string adminPassword = "55914";

         User adminUser = new User { Id = 1, Login = adminLogin, Password = adminPassword, RoleId = 1 };

         builder.ToTable("Users");
         builder.HasKey(p => p.Id);

         builder.HasData(new User[] { adminUser });
      }
   }
}
