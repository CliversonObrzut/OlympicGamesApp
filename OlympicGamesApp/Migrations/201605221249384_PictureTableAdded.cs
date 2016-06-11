namespace OlympicGamesApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PictureTableAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Picture",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Image = c.Binary(),
                        ImageContentType = c.String(),
                        ImageFileName = c.String(),
                        Thumbnail = c.Binary(),
                        ThumbnailContentType = c.String(),
                        ThumbnailFileName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Customer", "PictureId", c => c.Int());
            CreateIndex("dbo.Customer", "PictureId");
            AddForeignKey("dbo.Customer", "PictureId", "dbo.Picture", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customer", "PictureId", "dbo.Picture");
            DropIndex("dbo.Customer", new[] { "PictureId" });
            DropColumn("dbo.Customer", "PictureId");
            DropTable("dbo.Picture");
        }
    }
}
