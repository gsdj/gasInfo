using DataAccess.Entities;
using DataAccess.Entities.Devices;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.ConfigurationsEntities
{
   public class DevicesKipConfiguration : IEntityTypeConfiguration<DevicesKip>
   {
      public void Configure(EntityTypeBuilder<DevicesKip> builder)
      {
         builder.ToTable("DevicesKip");
         builder.HasKey(p => p.Id);
         builder.HasIndex(p => p.Date).IsUnique();
         builder.Property(p => p.Date).IsRequired().HasColumnType("Date");
         ///
         var cb1 = builder.OwnsOne(p => p.Cb1);
         var cb1SC = cb1.OwnsOne(p => p.SteamCharacteristics);
         cb1.Property(p => p.Temperature).HasColumnType("numeric").HasPrecision(5, 1);
         cb1SC.Property(p => p.Fkg).HasColumnType("numeric").HasPrecision(15);
         cb1SC.Property(p => p.PKg).HasColumnType("numeric").HasPrecision(15);
         cb1SC.Property(p => p.PPa).HasColumnType("numeric").HasPrecision(15);
         cb1SC.Property(p => p.Rh).HasColumnType("numeric").HasPrecision(15);
         ///

         builder.Property(p => p.Cu1.Temperature).HasColumnType("numeric").HasPrecision(5, 1);
         builder.Property(p => p.Cu2.Temperature).HasColumnType("numeric").HasPrecision(5, 1);
         builder.Property(p => p.Spo.Temperature).HasColumnType("numeric").HasPrecision(5, 1);
         builder.Property(p => p.Uvtp.Temperature).HasColumnType("numeric").HasPrecision(5, 1);
         builder.Property(p => p.Pkc.Temperature).HasColumnType("numeric").HasPrecision(5, 1);
         builder.Property(p => p.Gsuf45.Temperature).HasColumnType("numeric").HasPrecision(5, 1);
         builder.Property(p => p.Gru1.Temperature).HasColumnType("numeric").HasPrecision(5, 1);
         builder.Property(p => p.Gru2.Temperature).HasColumnType("numeric").HasPrecision(5, 1);
         builder.Property(p => p.Grp4.Temperature).HasColumnType("numeric").HasPrecision(5, 1);

         builder.Property(p => p.Cb1.Temperature).HasColumnType("numeric").HasPrecision(5, 1);
         builder.Property(p => p.Cb2.Temperature).HasColumnType("numeric").HasPrecision(5, 1);
         builder.Property(p => p.Cb3.Temperature).HasColumnType("numeric").HasPrecision(5, 1);
         builder.Property(p => p.Cb4.Temperature).HasColumnType("numeric").HasPrecision(5, 1);

         builder.Property(p => p.Cb5.Temperature).HasColumnType("numeric").HasPrecision(5, 1);
         builder.Property(p => p.Cb5.TempBeforeHeating).HasColumnType("numeric").HasPrecision(5, 1);

         builder.Property(p => p.Cb6.Temperature).HasColumnType("numeric").HasPrecision(5, 1);
         builder.Property(p => p.Cb6.TempBeforeHeating).HasColumnType("numeric").HasPrecision(5, 1);

         builder.Property(p => p.Cb7.Temperature).HasColumnType("numeric").HasPrecision(5, 1);
         builder.Property(p => p.Cb7.TempBeforeHeating).HasColumnType("numeric").HasPrecision(5, 1);

         builder.Property(p => p.Cb8.Temperature).HasColumnType("numeric").HasPrecision(5, 1);
         builder.Property(p => p.Cb8.TempBeforeHeating).HasColumnType("numeric").HasPrecision(5, 1);
      }
   }
}
