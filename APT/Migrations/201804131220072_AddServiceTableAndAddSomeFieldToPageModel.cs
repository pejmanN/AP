namespace APT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddServiceTableAndAddSomeFieldToPageModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        SuceessPageId = c.Int(nullable: false),
                        FailPageId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Pages", "HasService", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pages", "HasService");
            DropTable("dbo.Services");
        }
    }
}
