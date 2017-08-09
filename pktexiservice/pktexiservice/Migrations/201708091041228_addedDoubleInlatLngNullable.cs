namespace pktexiservice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedDoubleInlatLngNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Rides", "PikupLat", c => c.Double());
            AlterColumn("dbo.Rides", "PikupLng", c => c.Double());
            AlterColumn("dbo.Rides", "DropLat", c => c.Double());
            AlterColumn("dbo.Rides", "DropLng", c => c.Double());
            AlterColumn("dbo.Rides", "Rating", c => c.Int());
            AlterColumn("dbo.Rides", "Fare", c => c.Single());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Rides", "Fare", c => c.Single(nullable: false));
            AlterColumn("dbo.Rides", "Rating", c => c.Int(nullable: false));
            AlterColumn("dbo.Rides", "DropLng", c => c.Double(nullable: false));
            AlterColumn("dbo.Rides", "DropLat", c => c.Double(nullable: false));
            AlterColumn("dbo.Rides", "PikupLng", c => c.Double(nullable: false));
            AlterColumn("dbo.Rides", "PikupLat", c => c.Double(nullable: false));
        }
    }
}
