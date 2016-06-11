namespace OlympicGamesApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PictureTableRelatedToManyEntities : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Athlete", "PictureId", c => c.Int());
            AddColumn("dbo.Country", "PictureId", c => c.Int());
            AddColumn("dbo.Modality", "PictureId", c => c.Int());
            AddColumn("dbo.Sport", "PictureId", c => c.Int());
            CreateIndex("dbo.Athlete", "PictureId");
            CreateIndex("dbo.Country", "PictureId");
            CreateIndex("dbo.Modality", "PictureId");
            CreateIndex("dbo.Sport", "PictureId");
            AddForeignKey("dbo.Modality", "PictureId", "dbo.Picture", "Id");
            AddForeignKey("dbo.Sport", "PictureId", "dbo.Picture", "Id");
            AddForeignKey("dbo.Country", "PictureId", "dbo.Picture", "Id");
            AddForeignKey("dbo.Athlete", "PictureId", "dbo.Picture", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Athlete", "PictureId", "dbo.Picture");
            DropForeignKey("dbo.Country", "PictureId", "dbo.Picture");
            DropForeignKey("dbo.Sport", "PictureId", "dbo.Picture");
            DropForeignKey("dbo.Modality", "PictureId", "dbo.Picture");
            DropIndex("dbo.Sport", new[] { "PictureId" });
            DropIndex("dbo.Modality", new[] { "PictureId" });
            DropIndex("dbo.Country", new[] { "PictureId" });
            DropIndex("dbo.Athlete", new[] { "PictureId" });
            DropColumn("dbo.Sport", "PictureId");
            DropColumn("dbo.Modality", "PictureId");
            DropColumn("dbo.Country", "PictureId");
            DropColumn("dbo.Athlete", "PictureId");
        }
    }
}
