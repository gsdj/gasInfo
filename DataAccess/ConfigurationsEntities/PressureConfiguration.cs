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
