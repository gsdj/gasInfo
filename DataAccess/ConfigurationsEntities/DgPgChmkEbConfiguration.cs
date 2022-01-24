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
   public class DgPgChmkEbConfiguration : IEntityTypeConfiguration<DgPgChmkEb>
   {
      public void Configure(EntityTypeBuilder<DgPgChmkEb> builder)
      {
         builder.ToTable("DgPgChmkEb");
         builder.HasKey(p => p.Id);
         builder.HasIndex(p => p.Date).IsUnique();
         builder.Property(p => p.Date).IsRequired().HasColumnType("Date");
         //builder.Property(p => p.ConsDgCb1).HasColumnType("numeric");
         //builder.Property(p => p.ConsDgCb2).HasColumnType("numeric");
         //builder.Property(p => p.ConsDgCb3).HasColumnType("numeric");
         //builder.Property(p => p.ConsDgCb4).HasColumnType("numeric");
         //builder.Property(p => p.ConsPgGru1).HasColumnType("numeric");
         //builder.Property(p => p.ConsPgGru2).HasColumnType("numeric");
      }
   }
}
