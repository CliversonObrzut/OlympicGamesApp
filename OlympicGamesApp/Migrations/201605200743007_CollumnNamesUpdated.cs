namespace OlympicGamesApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CollumnNamesUpdated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customer", "StreetAddress", c => c.String(nullable: false, maxLength: 100, unicode: false));
            AddColumn("dbo.Customer", "PostCode", c => c.String(nullable: false, maxLength: 10, unicode: false));
            AddColumn("dbo.Venue", "StreetAddress", c => c.String(nullable: false, maxLength: 100, unicode: false));
            AddColumn("dbo.Venue", "PostCode", c => c.String(nullable: false, maxLength: 10, unicode: false));
            DropColumn("dbo.Customer", "AddressStreet");
            DropColumn("dbo.Customer", "Postal");
            DropColumn("dbo.Venue", "AddressStreet");
            DropColumn("dbo.Venue", "Postal");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Venue", "Postal", c => c.String(nullable: false, maxLength: 10, unicode: false));
            AddColumn("dbo.Venue", "AddressStreet", c => c.String(nullable: false, maxLength: 100, unicode: false));
            AddColumn("dbo.Customer", "Postal", c => c.String(nullable: false, maxLength: 10, unicode: false));
            AddColumn("dbo.Customer", "AddressStreet", c => c.String(nullable: false, maxLength: 100, unicode: false));
            DropColumn("dbo.Venue", "PostCode");
            DropColumn("dbo.Venue", "StreetAddress");
            DropColumn("dbo.Customer", "PostCode");
            DropColumn("dbo.Customer", "StreetAddress");
        }
    }
}
