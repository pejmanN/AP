using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace APT.Models.Config
{
    public class PageMapper : EntityTypeConfiguration<Page>
    {
        public PageMapper()
        {
            ToTable("Pages")
                .HasKey(a => a.Id)
                .Property(a => a.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.PrevioudPageId).IsOptional();
            Property(x => x.NextPageId).IsOptional();
            Property(x => x.MenuId).IsOptional();
            Property(x => x.HasService).IsOptional();
            Property(x => x.ServiceId).IsOptional();

            //HasRequired(x => x.Menu).WithOptional(x => x.Page);
        }
    }
}