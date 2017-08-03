namespace pktexiservice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedFairDataTye : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Rides", "Fare", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Rides", "Fare", c => c.Int(nullable: false));
        }
    }
}
