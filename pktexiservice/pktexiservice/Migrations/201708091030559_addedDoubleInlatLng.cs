namespace pktexiservice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedDoubleInlatLng : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rides", "PikupLat", c => c.Double(nullable: false));
            AddColumn("dbo.Rides", "PikupLng", c => c.Double(nullable: false));
            AddColumn("dbo.Rides", "DropLat", c => c.Double(nullable: false));
            AddColumn("dbo.Rides", "DropLng", c => c.Double(nullable: false));
            DropColumn("dbo.Rides", "PikupLocation");
            DropColumn("dbo.Rides", "DropLocation");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Rides", "DropLocation", c => c.String());
            AddColumn("dbo.Rides", "PikupLocation", c => c.String());
            DropColumn("dbo.Rides", "DropLng");
            DropColumn("dbo.Rides", "DropLat");
            DropColumn("dbo.Rides", "PikupLng");
            DropColumn("dbo.Rides", "PikupLat");
        }
    }
}
