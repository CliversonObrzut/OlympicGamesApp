namespace OlympicGamesApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PictureTableChanged : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Picture", "EntityId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Picture", "EntityId", c => c.Int());
        }
    }
}
