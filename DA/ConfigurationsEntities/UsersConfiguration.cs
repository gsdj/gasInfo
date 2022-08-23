using DA.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DA.ConfigurationsEntities
{
   public class UsersConfiguration : IEntityTypeConfiguration<User>
   {
      public void Configure(EntityTypeBuilder<User> builder)
      {
         builder.ToTable("Users");
         builder.HasKey(p => p.Id);
      }
   }
}
