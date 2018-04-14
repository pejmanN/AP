using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace APT.Models.Config
{
    public class MenuMapper : EntityTypeConfiguration<Menu>
    {
        public MenuMapper()
        {
            ToTable("Menus")
                 .HasKey(a => a.Id)
                 .Property(a => a.Id)
                 .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.ParentId).IsOptional();
            HasMany(x => x.Pages).WithOptional(x => x.Menu).HasForeignKey(x => x.MenuId);
        }
    }
}