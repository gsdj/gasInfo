using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.ConfigurationsEntities
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
