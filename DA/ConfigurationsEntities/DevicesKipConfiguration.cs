using DA.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DA.ConfigurationsEntities
{
   public class DevicesKipConfiguration : IEntityTypeConfiguration<DevicesKip>
   {
      public void Configure(EntityTypeBuilder<DevicesKip> builder)
      {
         builder.ToTable("DevicesKip");
         builder.HasKey(p => p.Id);
         builder.HasIndex(p => p.Date).IsUnique();
         builder.Property(p => p.Date).IsRequired().HasColumnType("Date");

         builder.OwnsOne(p => p.Cb1).Property(p => p.Temperature).HasColumnType("numeric").HasPrecision(5, 1);
         builder.OwnsOne(p => p.Cb2).Property(p => p.Temperature).HasColumnType("numeric").HasPrecision(5, 1);
         builder.OwnsOne(p => p.Cb3).Property(p => p.Temperature).HasColumnType("numeric").HasPrecision(5, 1);
         builder.OwnsOne(p => p.Cb4).Property(p => p.Temperature).HasColumnType("numeric").HasPrecision(5, 1);

         builder.OwnsOne(p => p.Cu1).Property(p => p.Temperature).HasColumnType("numeric").HasPrecision(5, 1);
         builder.OwnsOne(p => p.Cu2).Property(p => p.Temperature).HasColumnType("numeric").HasPrecision(5, 1);
         builder.OwnsOne(p => p.Spo).Property(p => p.Temperature).HasColumnType("numeric").HasPrecision(5, 1);
         builder.OwnsOne(p => p.Uvtp).Property(p => p.Temperature).HasColumnType("numeric").HasPrecision(5, 1);
         builder.OwnsOne(p => p.Gsuf45).Property(p => p.Temperature).HasColumnType("numeric").HasPrecision(5, 1);
         builder.OwnsOne(p => p.Gru1).Property(p => p.Temperature).HasColumnType("numeric").HasPrecision(5, 1);
         builder.OwnsOne(p => p.Gru2).Property(p => p.Temperature).HasColumnType("numeric").HasPrecision(5, 1);
         builder.OwnsOne(p => p.Grp4).Property(p => p.Temperature).HasColumnType("numeric").HasPrecision(5, 1);

         builder.OwnsOne(p => p.Pkc, a =>
         {
            a.Property(x => x.Temperature).HasColumnType("numeric").HasPrecision(5, 1);
            a.OwnsOne(x => x.Consumption, a =>
            {
               a.Property(x => x.Ms).HasColumnType("numeric").HasPrecision(16, 6);
               a.Property(x => x.Ks).HasColumnType("numeric").HasPrecision(16, 6);
            });
         });

         builder.OwnsOne(p => p.Cb5, a =>
         {
            a.Property(x => x.Temperature).HasColumnType("numeric").HasPrecision(5, 1);
            a.Property(x => x.TempBeforeHeating).HasColumnType("numeric").HasPrecision(5, 1);
         });

         builder.OwnsOne(p => p.Cb6, a =>
         {
            a.Property(x => x.Temperature).HasColumnType("numeric").HasPrecision(5, 1);
            a.Property(x => x.TempBeforeHeating).HasColumnType("numeric").HasPrecision(5, 1);
         });

         builder.OwnsOne(p => p.Cb7, a =>
         {
            a.Property(x => x.Temperature).HasColumnType("numeric").HasPrecision(5, 1);
            a.Property(x => x.TempBeforeHeating).HasColumnType("numeric").HasPrecision(5, 1);
            a.OwnsOne(x => x.Consumption, a =>
            {
               a.Property(x => x.Ms).HasColumnType("numeric").HasPrecision(16, 6);
               a.Property(x => x.Ks).HasColumnType("numeric").HasPrecision(16, 6);
            });
         });

         builder.OwnsOne(p => p.Cb8, a =>
         {
            a.Property(x => x.Temperature).HasColumnType("numeric").HasPrecision(5, 1);
            a.Property(x => x.TempBeforeHeating).HasColumnType("numeric").HasPrecision(5, 1);
            a.OwnsOne(x => x.Consumption, a =>
            {
               a.Property(x => x.Ms).HasColumnType("numeric").HasPrecision(16, 6);
               a.Property(x => x.Ks).HasColumnType("numeric").HasPrecision(16, 6);
            });
         });
      }
   }
}
