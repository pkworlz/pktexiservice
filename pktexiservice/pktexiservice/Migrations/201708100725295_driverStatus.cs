namespace pktexiservice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class driverStatus : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DriverStatus",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        DriverId = c.String(),
                        Lat = c.Double(nullable: false),
                        Lng = c.Double(nullable: false),
                        isOnline = c.Boolean(nullable: false),
                        lastSeen = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.DriverStatus");
        }
    }
}
