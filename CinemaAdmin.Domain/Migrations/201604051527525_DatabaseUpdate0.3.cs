namespace CinemaAdmin.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DatabaseUpdate03 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tickets", "Popcorn", c => c.Boolean(nullable: false));
            AddColumn("dbo.Tickets", "Ladies", c => c.Boolean(nullable: false));
            AddColumn("dbo.Tickets", "TotalPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tickets", "TotalPrice");
            DropColumn("dbo.Tickets", "Ladies");
            DropColumn("dbo.Tickets", "Popcorn");
        }
    }
}
