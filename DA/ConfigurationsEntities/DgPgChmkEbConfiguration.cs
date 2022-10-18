using DA.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace DA.ConfigurationsEntities
{
   public class DgPgChmkEbConfiguration : IEntityTypeConfiguration<DgPgChmkEb>
   {
      public DgPgChmkEbConfiguration() { }
      public DgPgChmkEbConfiguration(InitialDataSettings initialData)
      {
         InitialData = initialData;
      }
      private InitialDataSettings InitialData;
      public void Configure(EntityTypeBuilder<DgPgChmkEb> builder)
      {
         IEnumerable<DgPgChmkEb> data;

         using (StreamReader r = new StreamReader(InitialData.Path))
         {
            string json = r.ReadToEnd();
            data = JsonConvert.DeserializeObject<IEnumerable<DgPgChmkEb>>(json);
         }

         builder.ToTable("DgPgChmkEb");
         builder.HasKey(p => p.Id);
         builder.HasIndex(p => p.Date).IsUnique();
         builder.Property(p => p.Date).IsRequired().HasColumnType("Date");
         builder.Property(p => p.ConsDgCb1).HasColumnType("numeric");
         builder.Property(p => p.ConsDgCb2).HasColumnType("numeric");
         builder.Property(p => p.ConsDgCb3).HasColumnType("numeric");
         builder.Property(p => p.ConsDgCb4).HasColumnType("numeric");
         builder.Property(p => p.ConsPgGru1).HasColumnType("numeric");
         builder.Property(p => p.ConsPgGru2).HasColumnType("numeric");

         builder.HasData(data);
      }
   }
}
