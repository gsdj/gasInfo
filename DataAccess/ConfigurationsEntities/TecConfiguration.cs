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
   public class TecConfiguration : IEntityTypeConfiguration<Tec>
   {
      public void Configure(EntityTypeBuilder<Tec> builder)
      {
         builder.ToTable("Tec");
         builder.HasKey(p => p.Id);
         builder.HasIndex(p => p.Date).IsUnique();
         builder.Property(p => p.Date).IsRequired().HasColumnType("Date");
         builder.Property(p => p.TecNorth).HasColumnType("numeric").HasPrecision(16, 10);
         builder.Property(p => p.TecSouth).HasColumnType("numeric").HasPrecision(16, 10);
         builder.Property(p => p.Chmk).HasColumnType("numeric").HasPrecision(16, 10);
      }
   }
}
