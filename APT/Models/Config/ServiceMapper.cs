using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace APT.Models.Config
{
    public class ServiceMapper : EntityTypeConfiguration<Service>
    {
        public ServiceMapper()
        {
            ToTable("Services")
              .HasKey(a => a.Id)
              .Property(a => a.Id)
              .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

        }
    }
}