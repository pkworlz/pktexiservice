namespace pktexiservice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedCabInfo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cabs",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        RegNo = c.Int(nullable: false),
                        Name = c.String(),
                        SeatCapacity = c.Int(nullable: false),
                        Color = c.String(),
                        Model = c.String(),
                        Type = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Rides",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        PikupLocation = c.String(),
                        DropLocation = c.String(),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                        Rating = c.Int(nullable: false),
                        Fare = c.Int(nullable: false),
                        Distance = c.String(),
                        Offer = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Rides");
            DropTable("dbo.Cabs");
        }
    }
}
