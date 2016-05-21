namespace OlympicGamesApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TicketOrderItemColumnsUpdated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TicketOrderItem", "UnitItemPrice", c => c.Decimal(nullable: false, storeType: "money"));
            AddColumn("dbo.TicketOrderItem", "TotalItemPrice", c => c.Decimal(nullable: false, storeType: "money"));
            DropColumn("dbo.TicketOrderItem", "TotalLinePrice");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TicketOrderItem", "TotalLinePrice", c => c.Decimal(nullable: false, storeType: "money"));
            DropColumn("dbo.TicketOrderItem", "TotalItemPrice");
            DropColumn("dbo.TicketOrderItem", "UnitItemPrice");
        }
    }
}
