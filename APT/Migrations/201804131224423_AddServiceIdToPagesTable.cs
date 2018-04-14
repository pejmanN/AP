namespace APT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddServiceIdToPagesTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pages", "ServiceId", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pages", "ServiceId");
        }
    }
}
