namespace Adly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAdvertisementViews : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Advertisements", "Views", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Advertisements", "Views");
        }
    }
}
