namespace CinemaAdmin.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateDatabase01 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Movies", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Movies", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.Movies", "Language", c => c.String(nullable: false));
            AlterColumn("dbo.Movies", "Subtitle", c => c.String(nullable: false));
            AlterColumn("dbo.Movies", "Writer", c => c.String(nullable: false));
            AlterColumn("dbo.Movies", "Stars", c => c.String(nullable: false));
            AlterColumn("dbo.Movies", "Website", c => c.String(nullable: false));
            AlterColumn("dbo.Movies", "IMDB", c => c.String(nullable: false));
            AlterColumn("dbo.Movies", "Trailer", c => c.String(nullable: false));
            AlterColumn("dbo.Movies", "Kijkwijzer", c => c.String(nullable: false));
            AlterColumn("dbo.Movies", "ThumbnailData", c => c.String(nullable: false));
            AlterColumn("dbo.Movies", "Type", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "Type", c => c.String());
            AlterColumn("dbo.Movies", "ThumbnailData", c => c.String());
            AlterColumn("dbo.Movies", "Kijkwijzer", c => c.String());
            AlterColumn("dbo.Movies", "Trailer", c => c.String());
            AlterColumn("dbo.Movies", "IMDB", c => c.String());
            AlterColumn("dbo.Movies", "Website", c => c.String());
            AlterColumn("dbo.Movies", "Stars", c => c.String());
            AlterColumn("dbo.Movies", "Writer", c => c.String());
            AlterColumn("dbo.Movies", "Subtitle", c => c.String());
            AlterColumn("dbo.Movies", "Language", c => c.String());
            AlterColumn("dbo.Movies", "Description", c => c.String());
            AlterColumn("dbo.Movies", "Name", c => c.String());
        }
    }
}
