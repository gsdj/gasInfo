using DA.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DA.ConfigurationsEntities
{
   public class DevicesKipConfiguration : IEntityTypeConfiguration<DevicesKip>
   {
      public DevicesKipConfiguration() { }
      public DevicesKipConfiguration(InitialDataSettings initialData)
      {
         InitialData = initialData;
      }
      private InitialDataSettings InitialData;
      public void Configure(EntityTypeBuilder<DevicesKip> builder)
      {
         IEnumerable<DevicesKip> data;

         using (StreamReader r = new StreamReader(InitialData.Path))
         {
            string json = r.ReadToEnd();
            data = JsonConvert.DeserializeObject<IEnumerable<DevicesKip>>(json);
         }
         #region InitData
         var baseData = data.Select(x => new DevicesKip
         {
            Id = x.Id,
            Date = x.Date,
         });
         #region Cb
         var cb1Data = data.Select(x => new
         {
            DevicesKipId = x.Id,
            x.Cb1.Consumption,
            x.Cb1.Pressure,
            x.Cb1.Temperature,
         });

         var cb2Data = data.Select(x => new
         {
            DevicesKipId = x.Id,
            x.Cb2.Consumption,
            x.Cb2.Pressure,
            x.Cb2.Temperature,
         });

         var cb3Data = data.Select(x => new
         {
            DevicesKipId = x.Id,
            x.Cb3.Consumption,
            x.Cb3.Pressure,
            x.Cb3.Temperature,
         });

         var cb4Data = data.Select(x => new
         {
            DevicesKipId = x.Id,
            x.Cb4.Consumption,
            x.Cb4.Pressure,
            x.Cb4.Temperature,
         });

         var cb5Data = data.Select(x => new
         {
            DevicesKipId = x.Id,
            x.Cb5.Consumption,
            x.Cb5.Pressure,
            x.Cb5.Temperature,
            x.Cb5.TempBeforeHeating,
         });

         var cb6Data = data.Select(x => new
         {
            DevicesKipId = x.Id,
            x.Cb6.Consumption,
            x.Cb6.Pressure,
            x.Cb6.Temperature,
            x.Cb6.TempBeforeHeating,
         });

         var cb7Data = data.Select(x => new
         {
            DevicesKipId = x.Id,
            x.Cb7.Pressure,
            x.Cb7.Temperature,
            x.Cb7.TempBeforeHeating,
         });

         var cb7ConsData = data.Select(x => new
         {
            DeviceTBHMsKsDevicesKipId = x.Id,
            x.Cb7.Consumption.Ms,
            x.Cb7.Consumption.Ks,
         });

         var cb8Data = data.Select(x => new
         {
            DevicesKipId = x.Id,
            x.Cb8.Pressure,
            x.Cb8.Temperature,
            x.Cb8.TempBeforeHeating,
         });
         var cb8ConsData = data.Select(x => new
         {
            DeviceTBHMsKsDevicesKipId = x.Id,
            x.Cb8.Consumption.Ms,
            x.Cb8.Consumption.Ks,
         });
         #endregion
         #region Cu
         var cu1Data = data.Select(x => new
         {
            DevicesKipId = x.Id,
            x.Cu1.Consumption,
            x.Cu1.Pressure,
            x.Cu1.Temperature,
         });
         var cu2Data = data.Select(x => new
         {
            DevicesKipId = x.Id,
            x.Cu2.Consumption,
            x.Cu2.Pressure,
            x.Cu2.Temperature,
         });
         #endregion
         #region CpsPpk
         var spoData = data.Select(x => new
         {
            DevicesKipId = x.Id,
            x.Spo.Consumption,
            x.Spo.Pressure,
            x.Spo.Temperature,
         });
         var uvtpData = data.Select(x => new
         {
            DevicesKipId = x.Id,
            x.Uvtp.Consumption,
            x.Uvtp.Pressure,
            x.Uvtp.Temperature,
         });
         var gsufData = data.Select(x => new
         {
            DevicesKipId = x.Id,
            x.Gsuf45.Consumption,
            x.Gsuf45.Pressure,
            x.Gsuf45.Temperature,
         });
         #endregion
         #region Other
         var pkcData = data.Select(x => new
         {
            DevicesKipId = x.Id,
            x.Pkc.Pressure,
            x.Pkc.Temperature,
         });
         var pkcConsData = data.Select(x => new
         {
            DeviceMsKsDevicesKipId = x.Id,
            x.Pkc.Consumption.Ms,
            x.Pkc.Consumption.Ks,
         });
         var gru1Data = data.Select(x => new
         {
            DevicesKipId = x.Id,
            x.Gru1.Consumption,
            x.Gru1.Pressure,
            x.Gru1.Temperature,
         });
         var gru2Data = data.Select(x => new
         {
            DevicesKipId = x.Id,
            x.Gru2.Consumption,
            x.Gru2.Pressure,
            x.Gru2.Temperature,
         });
         var grp4Data = data.Select(x => new
         {
            DevicesKipId = x.Id,
            x.Grp4.Consumption,
            x.Grp4.Pressure,
            x.Grp4.Temperature,
         });
         #endregion
         #endregion
         #region Configuration
         builder.ToTable("DevicesKip");
         builder.HasKey(p => p.Id);
         builder.HasIndex(p => p.Date).IsUnique();
         builder.Property(p => p.Date).IsRequired().HasColumnType("Date");

         builder.HasData(baseData);

         builder.OwnsOne(p => p.Cb1, a =>
         {
            a.Property(p => p.Temperature).HasColumnType("numeric").HasPrecision(5, 1);
            a.HasData(cb1Data);
         });
         builder.OwnsOne(p => p.Cb2, a =>
         {
            a.Property(p => p.Temperature).HasColumnType("numeric").HasPrecision(5, 1);
            a.HasData(cb2Data);
         });
         builder.OwnsOne(p => p.Cb3, a =>
         {
            a.Property(p => p.Temperature).HasColumnType("numeric").HasPrecision(5, 1);
            a.HasData(cb3Data);
         });
         builder.OwnsOne(p => p.Cb4, a =>
         {
            a.Property(p => p.Temperature).HasColumnType("numeric").HasPrecision(5, 1);
            a.HasData(cb4Data);
         });

         builder.OwnsOne(p => p.Cu1, a =>
         {
            a.Property(p => p.Temperature).HasColumnType("numeric").HasPrecision(5, 1);
            a.HasData(cu1Data);
         });
         builder.OwnsOne(p => p.Cu2, a =>
         {
            a.Property(p => p.Temperature).HasColumnType("numeric").HasPrecision(5, 1);
            a.HasData(cu2Data);
         });

         builder.OwnsOne(p => p.Spo, a =>
         {
            a.Property(p => p.Temperature).HasColumnType("numeric").HasPrecision(5, 1);
            a.HasData(spoData);
         });
         builder.OwnsOne(p => p.Uvtp, a =>
         {
            a.Property(p => p.Temperature).HasColumnType("numeric").HasPrecision(5, 1);
            a.HasData(uvtpData);
         });
         builder.OwnsOne(p => p.Gsuf45, a =>
         {
            a.Property(p => p.Temperature).HasColumnType("numeric").HasPrecision(5, 1);
            a.HasData(gsufData);
         });
         builder.OwnsOne(p => p.Gru1, a =>
         {
            a.Property(p => p.Temperature).HasColumnType("numeric").HasPrecision(5, 1);
            a.HasData(gru1Data);
         });
         builder.OwnsOne(p => p.Gru2, a =>
         {
            a.Property(p => p.Temperature).HasColumnType("numeric").HasPrecision(5, 1);
            a.HasData(gru2Data);
         });
         builder.OwnsOne(p => p.Grp4, a =>
         {
            a.Property(p => p.Temperature).HasColumnType("numeric").HasPrecision(5, 1);
            a.HasData(grp4Data);
         });

         builder.OwnsOne(p => p.Pkc, a =>
         {
            a.Property(x => x.Temperature).HasColumnType("numeric").HasPrecision(5, 1);
            a.HasData(pkcData);
            a.OwnsOne(x => x.Consumption, a =>
            {
               a.Property(x => x.Ms).HasColumnType("numeric").HasPrecision(16, 6);
               a.Property(x => x.Ks).HasColumnType("numeric").HasPrecision(16, 6);
               a.HasData(pkcConsData);
            });
         });

         builder.OwnsOne(p => p.Cb5, a =>
         {
            a.Property(x => x.Temperature).HasColumnType("numeric").HasPrecision(5, 1);
            a.Property(x => x.TempBeforeHeating).HasColumnType("numeric").HasPrecision(5, 1);
            a.HasData(cb5Data);
         });

         builder.OwnsOne(p => p.Cb6, a =>
         {
            a.Property(x => x.Temperature).HasColumnType("numeric").HasPrecision(5, 1);
            a.Property(x => x.TempBeforeHeating).HasColumnType("numeric").HasPrecision(5, 1);
            a.HasData(cb6Data);
         });

         builder.OwnsOne(p => p.Cb7, a =>
         {
            a.Property(x => x.Temperature).HasColumnType("numeric").HasPrecision(5, 1);
            a.Property(x => x.TempBeforeHeating).HasColumnType("numeric").HasPrecision(5, 1);
            a.HasData(cb7Data);
            a.OwnsOne(x => x.Consumption, a =>
            {
               a.Property(x => x.Ms).HasColumnType("numeric").HasPrecision(16, 6);
               a.Property(x => x.Ks).HasColumnType("numeric").HasPrecision(16, 6);
               a.HasData(cb7ConsData);
            });
         });

         builder.OwnsOne(p => p.Cb8, a =>
         {
            a.Property(x => x.Temperature).HasColumnType("numeric").HasPrecision(5, 1);
            a.Property(x => x.TempBeforeHeating).HasColumnType("numeric").HasPrecision(5, 1);
            a.HasData(cb8Data);
            a.OwnsOne(x => x.Consumption, a =>
            {
               a.Property(x => x.Ms).HasColumnType("numeric").HasPrecision(16, 6);
               a.Property(x => x.Ks).HasColumnType("numeric").HasPrecision(16, 6);
               a.HasData(cb8ConsData);
            });
         });
         #endregion
      }
   }
}
