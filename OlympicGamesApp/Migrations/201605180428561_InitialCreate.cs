namespace OlympicGamesApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Athlete",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 50, unicode: false),
                        MiddleNames = c.String(maxLength: 100, unicode: false),
                        LastName = c.String(nullable: false, maxLength: 50, unicode: false),
                        DateOfBirth = c.DateTime(nullable: false),
                        CountryId = c.Int(nullable: false),
                        GenderId = c.Int(nullable: false),
                        GoldMedal = c.Int(nullable: false),
                        SilverMedal = c.Int(nullable: false),
                        BronzeMedal = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Country", t => t.CountryId)
                .ForeignKey("dbo.Gender", t => t.GenderId)
                .Index(t => t.CountryId)
                .Index(t => t.GenderId);
            
            CreateTable(
                "dbo.Country",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50, unicode: false),
                        GoldMedal = c.Int(nullable: false),
                        SilverMedal = c.Int(nullable: false),
                        BronzeMedal = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 50, unicode: false),
                        MiddleNames = c.String(maxLength: 100, unicode: false),
                        LastName = c.String(nullable: false, maxLength: 50, unicode: false),
                        DateOfBirth = c.DateTime(nullable: false),
                        GenderId = c.Int(nullable: false),
                        Login = c.String(nullable: false, maxLength: 100, unicode: false),
                        Password = c.String(nullable: false, maxLength: 50, unicode: false),
                        AddressStreet = c.String(nullable: false, maxLength: 100, unicode: false),
                        Suburb = c.String(nullable: false, maxLength: 50, unicode: false),
                        City = c.String(nullable: false, maxLength: 50, unicode: false),
                        Postal = c.String(nullable: false, maxLength: 10, unicode: false),
                        State = c.String(nullable: false, maxLength: 50, unicode: false),
                        Country = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Gender", t => t.GenderId)
                .Index(t => t.GenderId);
            
            CreateTable(
                "dbo.Gender",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Modality",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100, unicode: false),
                        ModalityCategoryId = c.Int(nullable: false),
                        SportId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ModalityCategory", t => t.ModalityCategoryId)
                .ForeignKey("dbo.Sport", t => t.SportId)
                .Index(t => t.ModalityCategoryId)
                .Index(t => t.SportId);
            
            CreateTable(
                "dbo.CompetitionEvent",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false, storeType: "date"),
                        Time = c.Time(nullable: false, precision: 7),
                        ModalityId = c.Int(nullable: false),
                        CompetitionSessionId = c.Int(nullable: false),
                        CompetitionPhaseId = c.Int(nullable: false),
                        VenueId = c.Int(nullable: false),
                        BasePrice = c.Decimal(nullable: false, storeType: "money"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CompetitionPhase", t => t.CompetitionPhaseId)
                .ForeignKey("dbo.CompetitionSession", t => t.CompetitionSessionId)
                .ForeignKey("dbo.Modality", t => t.ModalityId)
                .ForeignKey("dbo.Venue", t => t.VenueId)
                .Index(t => t.ModalityId)
                .Index(t => t.CompetitionSessionId)
                .Index(t => t.CompetitionPhaseId)
                .Index(t => t.VenueId);
            
            CreateTable(
                "dbo.CompetitionPhase",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CompetitionSession",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TicketEvent",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false, maxLength: 200, unicode: false),
                        TicketPrice = c.Decimal(nullable: false, storeType: "money"),
                        TicketsAvailable = c.Int(nullable: false),
                        VenueSectorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.VenueSector", t => t.VenueSectorId)
                .Index(t => t.VenueSectorId);
            
            CreateTable(
                "dbo.TicketOrderItem",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TicketOrderId = c.Int(nullable: false),
                        TicketEventId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        TotalLinePrice = c.Decimal(nullable: false, storeType: "money"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TicketEvent", t => t.TicketEventId)
                .ForeignKey("dbo.TicketOrder", t => t.TicketOrderId)
                .Index(t => t.TicketOrderId)
                .Index(t => t.TicketEventId);
            
            CreateTable(
                "dbo.TicketOrder",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        PurchaseDate = c.DateTime(nullable: false),
                        TotalCost = c.Decimal(nullable: false, storeType: "money"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customer", t => t.CustomerId)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.VenueSector",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50, unicode: false),
                        Multiplier = c.Decimal(nullable: false, storeType: "money"),
                        VenueId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Venue", t => t.VenueId)
                .Index(t => t.VenueId);
            
            CreateTable(
                "dbo.Venue",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100, unicode: false),
                        AddressStreet = c.String(nullable: false, maxLength: 100, unicode: false),
                        Suburb = c.String(nullable: false, maxLength: 50, unicode: false),
                        City = c.String(nullable: false, maxLength: 50, unicode: false),
                        Postal = c.String(nullable: false, maxLength: 10, unicode: false),
                        State = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ModalityCategory",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 10, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Sport",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CustomerAthlete",
                c => new
                    {
                        Customer_Id = c.Int(nullable: false),
                        Athlete_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Customer_Id, t.Athlete_Id })
                .ForeignKey("dbo.Customer", t => t.Customer_Id, cascadeDelete: true)
                .ForeignKey("dbo.Athlete", t => t.Athlete_Id, cascadeDelete: true)
                .Index(t => t.Customer_Id)
                .Index(t => t.Athlete_Id);
            
            CreateTable(
                "dbo.CustomerCountry",
                c => new
                    {
                        Customer_Id = c.Int(nullable: false),
                        Country_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Customer_Id, t.Country_Id })
                .ForeignKey("dbo.Customer", t => t.Customer_Id, cascadeDelete: true)
                .ForeignKey("dbo.Country", t => t.Country_Id, cascadeDelete: true)
                .Index(t => t.Customer_Id)
                .Index(t => t.Country_Id);
            
            CreateTable(
                "dbo.ModalityAthlete",
                c => new
                    {
                        Modality_Id = c.Int(nullable: false),
                        Athlete_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Modality_Id, t.Athlete_Id })
                .ForeignKey("dbo.Modality", t => t.Modality_Id, cascadeDelete: true)
                .ForeignKey("dbo.Athlete", t => t.Athlete_Id, cascadeDelete: true)
                .Index(t => t.Modality_Id)
                .Index(t => t.Athlete_Id);
            
            CreateTable(
                "dbo.TicketEventCompetitionEvent",
                c => new
                    {
                        TicketEvent_Id = c.Int(nullable: false),
                        CompetitionEvent_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.TicketEvent_Id, t.CompetitionEvent_Id })
                .ForeignKey("dbo.TicketEvent", t => t.TicketEvent_Id, cascadeDelete: true)
                .ForeignKey("dbo.CompetitionEvent", t => t.CompetitionEvent_Id, cascadeDelete: true)
                .Index(t => t.TicketEvent_Id)
                .Index(t => t.CompetitionEvent_Id);
            
            CreateTable(
                "dbo.ModalityCustomer",
                c => new
                    {
                        Modality_Id = c.Int(nullable: false),
                        Customer_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Modality_Id, t.Customer_Id })
                .ForeignKey("dbo.Modality", t => t.Modality_Id, cascadeDelete: true)
                .ForeignKey("dbo.Customer", t => t.Customer_Id, cascadeDelete: true)
                .Index(t => t.Modality_Id)
                .Index(t => t.Customer_Id);
            
            CreateTable(
                "dbo.SportCustomer",
                c => new
                    {
                        Sport_Id = c.Int(nullable: false),
                        Customer_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Sport_Id, t.Customer_Id })
                .ForeignKey("dbo.Sport", t => t.Sport_Id, cascadeDelete: true)
                .ForeignKey("dbo.Customer", t => t.Customer_Id, cascadeDelete: true)
                .Index(t => t.Sport_Id)
                .Index(t => t.Customer_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Modality", "SportId", "dbo.Sport");
            DropForeignKey("dbo.SportCustomer", "Customer_Id", "dbo.Customer");
            DropForeignKey("dbo.SportCustomer", "Sport_Id", "dbo.Sport");
            DropForeignKey("dbo.Modality", "ModalityCategoryId", "dbo.ModalityCategory");
            DropForeignKey("dbo.ModalityCustomer", "Customer_Id", "dbo.Customer");
            DropForeignKey("dbo.ModalityCustomer", "Modality_Id", "dbo.Modality");
            DropForeignKey("dbo.VenueSector", "VenueId", "dbo.Venue");
            DropForeignKey("dbo.CompetitionEvent", "VenueId", "dbo.Venue");
            DropForeignKey("dbo.TicketEvent", "VenueSectorId", "dbo.VenueSector");
            DropForeignKey("dbo.TicketOrderItem", "TicketOrderId", "dbo.TicketOrder");
            DropForeignKey("dbo.TicketOrder", "CustomerId", "dbo.Customer");
            DropForeignKey("dbo.TicketOrderItem", "TicketEventId", "dbo.TicketEvent");
            DropForeignKey("dbo.TicketEventCompetitionEvent", "CompetitionEvent_Id", "dbo.CompetitionEvent");
            DropForeignKey("dbo.TicketEventCompetitionEvent", "TicketEvent_Id", "dbo.TicketEvent");
            DropForeignKey("dbo.CompetitionEvent", "ModalityId", "dbo.Modality");
            DropForeignKey("dbo.CompetitionEvent", "CompetitionSessionId", "dbo.CompetitionSession");
            DropForeignKey("dbo.CompetitionEvent", "CompetitionPhaseId", "dbo.CompetitionPhase");
            DropForeignKey("dbo.ModalityAthlete", "Athlete_Id", "dbo.Athlete");
            DropForeignKey("dbo.ModalityAthlete", "Modality_Id", "dbo.Modality");
            DropForeignKey("dbo.Customer", "GenderId", "dbo.Gender");
            DropForeignKey("dbo.Athlete", "GenderId", "dbo.Gender");
            DropForeignKey("dbo.CustomerCountry", "Country_Id", "dbo.Country");
            DropForeignKey("dbo.CustomerCountry", "Customer_Id", "dbo.Customer");
            DropForeignKey("dbo.CustomerAthlete", "Athlete_Id", "dbo.Athlete");
            DropForeignKey("dbo.CustomerAthlete", "Customer_Id", "dbo.Customer");
            DropForeignKey("dbo.Athlete", "CountryId", "dbo.Country");
            DropIndex("dbo.SportCustomer", new[] { "Customer_Id" });
            DropIndex("dbo.SportCustomer", new[] { "Sport_Id" });
            DropIndex("dbo.ModalityCustomer", new[] { "Customer_Id" });
            DropIndex("dbo.ModalityCustomer", new[] { "Modality_Id" });
            DropIndex("dbo.TicketEventCompetitionEvent", new[] { "CompetitionEvent_Id" });
            DropIndex("dbo.TicketEventCompetitionEvent", new[] { "TicketEvent_Id" });
            DropIndex("dbo.ModalityAthlete", new[] { "Athlete_Id" });
            DropIndex("dbo.ModalityAthlete", new[] { "Modality_Id" });
            DropIndex("dbo.CustomerCountry", new[] { "Country_Id" });
            DropIndex("dbo.CustomerCountry", new[] { "Customer_Id" });
            DropIndex("dbo.CustomerAthlete", new[] { "Athlete_Id" });
            DropIndex("dbo.CustomerAthlete", new[] { "Customer_Id" });
            DropIndex("dbo.VenueSector", new[] { "VenueId" });
            DropIndex("dbo.TicketOrder", new[] { "CustomerId" });
            DropIndex("dbo.TicketOrderItem", new[] { "TicketEventId" });
            DropIndex("dbo.TicketOrderItem", new[] { "TicketOrderId" });
            DropIndex("dbo.TicketEvent", new[] { "VenueSectorId" });
            DropIndex("dbo.CompetitionEvent", new[] { "VenueId" });
            DropIndex("dbo.CompetitionEvent", new[] { "CompetitionPhaseId" });
            DropIndex("dbo.CompetitionEvent", new[] { "CompetitionSessionId" });
            DropIndex("dbo.CompetitionEvent", new[] { "ModalityId" });
            DropIndex("dbo.Modality", new[] { "SportId" });
            DropIndex("dbo.Modality", new[] { "ModalityCategoryId" });
            DropIndex("dbo.Customer", new[] { "GenderId" });
            DropIndex("dbo.Athlete", new[] { "GenderId" });
            DropIndex("dbo.Athlete", new[] { "CountryId" });
            DropTable("dbo.SportCustomer");
            DropTable("dbo.ModalityCustomer");
            DropTable("dbo.TicketEventCompetitionEvent");
            DropTable("dbo.ModalityAthlete");
            DropTable("dbo.CustomerCountry");
            DropTable("dbo.CustomerAthlete");
            DropTable("dbo.Sport");
            DropTable("dbo.ModalityCategory");
            DropTable("dbo.Venue");
            DropTable("dbo.VenueSector");
            DropTable("dbo.TicketOrder");
            DropTable("dbo.TicketOrderItem");
            DropTable("dbo.TicketEvent");
            DropTable("dbo.CompetitionSession");
            DropTable("dbo.CompetitionPhase");
            DropTable("dbo.CompetitionEvent");
            DropTable("dbo.Modality");
            DropTable("dbo.Gender");
            DropTable("dbo.Customer");
            DropTable("dbo.Country");
            DropTable("dbo.Athlete");
        }
    }
}
