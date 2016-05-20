namespace OlympicGamesApp.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using OlympicGamesApp.DataAccess.Models;
    using System.Linq;
    using System.Collections.Generic;
    internal sealed class Configuration : DbMigrationsConfiguration<OlympicGamesApp.DataAccess.Models.OlympicDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(OlympicGamesApp.DataAccess.Models.OlympicDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            //To seed all the tables in once it is needed to start with the tables with no dependency (foreignkey)
            context.Countries.AddOrUpdate(
                c => c.Name,
                new Country { Name = "Brazil", GoldMedal = 2, SilverMedal = 3, BronzeMedal = 1 },
                new Country { Name = "USA", GoldMedal = 2, SilverMedal = 2, BronzeMedal = 1 },
                new Country { Name = "Australia", GoldMedal = 2, SilverMedal = 2, BronzeMedal = 1 },
                new Country { Name = "Malaysia", GoldMedal = 0, SilverMedal = 2, BronzeMedal = 2 }
                );
            context.SaveChanges(); //Seeding and saving changes for every table as soon as it's seeded because the dependet tables need this data filled in the database previously.

            context.Genders.AddOrUpdate(
                g => g.Name,
                new Gender { Name = "Male" },
                new Gender { Name = "Female" }
            );
            context.SaveChanges();

            context.Athletes.AddOrUpdate(
                a => new { a.FirstName, a.LastName, a.DateOfBirth},
                new Athlete { FirstName = "Michael", LastName = "Phelps", DateOfBirth = DateTime.Parse("17/05/1990"), GenderId = 1, CountryId = 2, GoldMedal = 2, SilverMedal = 2, BronzeMedal = 1 },
                new Athlete { FirstName = "Ian", LastName = "Thorpe", DateOfBirth = DateTime.Parse("25/06/1986"), GenderId = 1, CountryId = 3, GoldMedal = 1, SilverMedal = 2, BronzeMedal = 1 },
                new Athlete { FirstName = "Lleyton", LastName = "Hewitt", DateOfBirth = DateTime.Parse("02/09/1983"), GenderId = 1, CountryId = 3, GoldMedal = 1, SilverMedal = 0, BronzeMedal = 0 },
                new Athlete { FirstName = "Cesar", LastName = "Cielo", DateOfBirth = DateTime.Parse("06/08/1989"), GenderId = 1, CountryId = 1, GoldMedal = 2, SilverMedal = 3, BronzeMedal = 1 }
            );
            context.SaveChanges();

            context.Sports.AddOrUpdate(
                s => s.Name,
                new Sport { Name = "Swimming"},
                new Sport { Name = "Basketball"},
                new Sport { Name = "Tennis"},
                new Sport { Name = "Judo"}
                );
            context.SaveChanges();

            context.ModalityCategories.AddOrUpdate(
                m => m.Name,
                new ModalityCategory { Name = "Individual"},
                new ModalityCategory { Name = "Team"}
                );
            context.SaveChanges();

            context.Modalities.AddOrUpdate(
                m => m.Name,
                new Modality { Name = "Men 100m freestyle", ModalityCategoryId = 1, SportId = 1},
                new Modality { Name = "Men 200m freestyle", ModalityCategoryId = 1, SportId = 1},
                new Modality { Name = "Men 4x100m medley", ModalityCategoryId = 2, SportId = 1},
                new Modality { Name = "Men tennis single", ModalityCategoryId = 1, SportId = 3},
                new Modality { Name = "Men tennis double", ModalityCategoryId = 2, SportId = 3},
                new Modality { Name = "Men 66-73kg (lightweight)", ModalityCategoryId = 1, SportId = 4},
                new Modality { Name = "Men basketball", ModalityCategoryId = 2, SportId = 2}
                );
            context.SaveChanges();

            context.CompetitionSessions.AddOrUpdate(
                c => c.Name,
                new CompetitionSession { Name = "Session1"},
                new CompetitionSession { Name = "Session2"},
                new CompetitionSession { Name = "Session3"},
                new CompetitionSession { Name = "Session4"},
                new CompetitionSession { Name = "Session8"},
                new CompetitionSession { Name = "Session9"},
                new CompetitionSession { Name = "Session10"},
                new CompetitionSession { Name = "Session22"},
                new CompetitionSession { Name = "Session25"},
                new CompetitionSession { Name = "Session38"}
                );
            context.SaveChanges();

            context.CompetitionPhases.AddOrUpdate(
                c => c.Name,
                new CompetitionPhase { Name = "Heats"},
                new CompetitionPhase { Name = "Preliminary"},
                new CompetitionPhase { Name = "FirstRound"},
                new CompetitionPhase { Name = "SecondRound"},
                new CompetitionPhase { Name = "ThirdRound"},
                new CompetitionPhase { Name = "Repechage"},
                new CompetitionPhase { Name = "Bronze match"},
                new CompetitionPhase { Name = "Quarters"},
                new CompetitionPhase { Name = "Semi-Final"},
                new CompetitionPhase { Name = "Final"}
                );
            context.SaveChanges();

            context.Venues.AddOrUpdate(
                v => v.Name,
                new Venue { Name = "Carioca Arena", StreetAddress = "R. Mal. Floriano, 234", Suburb = "Barra", City = "Rio de Janeiro", State = "RJ", PostCode = "64585-269"},
                new Venue { Name = "Youth Arena", StreetAddress = "R. Mal. Deodoro, 658", Suburb = "Botafogo", City = "Rio de Janeiro", State = "RJ", PostCode = "63348-684"},
                new Venue { Name = "Aquatic Olympic Stadium", StreetAddress = "Av. Iguacu, 345", Suburb = "Flamengo", City = "Rio de Janeiro", State = "RJ", PostCode = "69484-131"},
                new Venue { Name = "Tennis Olympic Center", StreetAddress = "Av. Brasil, 23", Suburb = "Copacabana", City = "Rio de Janeiro", State = "RJ", PostCode = "63215-987"}
                );
            context.SaveChanges();

            context.CompetitionEvents.AddOrUpdate(
                c => new {c.ModalityId, c.CompetitionPhaseId, c.CompetitionSessionId},
                new CompetitionEvent { Date = DateTime.Parse("06/08/2016"), Time = TimeSpan.Parse("14:00:00"), ModalityId = 7, CompetitionSessionId = 1, CompetitionPhaseId = 2, VenueId = 2, BasePrice = 35 },
                new CompetitionEvent { Date = DateTime.Parse("21/08/2016"), Time = TimeSpan.Parse("15:00:00"), ModalityId = 7, CompetitionSessionId = 10, CompetitionPhaseId = 10, VenueId = 2, BasePrice = 120 },
                new CompetitionEvent { Date = DateTime.Parse("06/08/2016"), Time = TimeSpan.Parse("09:00:00"), ModalityId = 1, CompetitionSessionId = 1, CompetitionPhaseId = 1, VenueId = 3, BasePrice = 80 },
                new CompetitionEvent { Date = DateTime.Parse("06/08/2016"), Time = TimeSpan.Parse("09:12:00"), ModalityId = 1, CompetitionSessionId = 2, CompetitionPhaseId = 1, VenueId = 3, BasePrice = 80 },
                new CompetitionEvent { Date = DateTime.Parse("06/08/2016"), Time = TimeSpan.Parse("09:30:00"), ModalityId = 1, CompetitionSessionId = 4, CompetitionPhaseId = 1, VenueId = 3, BasePrice = 80 },
                new CompetitionEvent { Date = DateTime.Parse("06/08/2016"), Time = TimeSpan.Parse("16:00:00"), ModalityId = 1, CompetitionSessionId = 5, CompetitionPhaseId = 9, VenueId = 3, BasePrice = 80 },
                new CompetitionEvent { Date = DateTime.Parse("06/08/2016"), Time = TimeSpan.Parse("16:12:00"), ModalityId = 1, CompetitionSessionId = 6, CompetitionPhaseId = 9, VenueId = 3, BasePrice = 80 },
                new CompetitionEvent { Date = DateTime.Parse("07/08/2016"), Time = TimeSpan.Parse("11:00:00"), ModalityId = 1, CompetitionSessionId = 7, CompetitionPhaseId = 10, VenueId = 3, BasePrice = 80 },
                new CompetitionEvent { Date = DateTime.Parse("09/08/2016"), Time = TimeSpan.Parse("10:00:00"), ModalityId = 4, CompetitionSessionId = 8, CompetitionPhaseId = 10, VenueId = 4, BasePrice = 70 },
                new CompetitionEvent { Date = DateTime.Parse("13/08/2016"), Time = TimeSpan.Parse("11:00:00"), ModalityId = 3, CompetitionSessionId = 7, CompetitionPhaseId = 10, VenueId = 3, BasePrice = 80 }
                );
            context.SaveChanges();

            context.VenueSectors.AddOrUpdate(
                v => new {v.Name, v.VenueId},
                new VenueSector { Name = "Sector A", Multiplier = 1, VenueId = 2},
                new VenueSector { Name = "Sector B", Multiplier = 1.3m, VenueId = 2},
                new VenueSector { Name = "Sector C", Multiplier = 1.5m, VenueId = 2},
                new VenueSector { Name = "Sector D", Multiplier = 1.7m, VenueId = 2},
                new VenueSector { Name = "Sector A", Multiplier = 1, VenueId = 3},
                new VenueSector { Name = "Sector B", Multiplier = 1.5m, VenueId = 3},
                new VenueSector { Name = "Sector C", Multiplier = 2, VenueId = 3},
                new VenueSector { Name = "Sector A", Multiplier = 1, VenueId = 4},
                new VenueSector { Name = "Sector B", Multiplier = 1.8m, VenueId = 4}
                );
            context.SaveChanges();

            context.TicketEvents.AddOrUpdate(
                t => new {t.Description, t.VenueSectorId},
                new TicketEvent { Description = "06/08/2016 - 14:00 - Men Basketball Preliminary Session 1", TicketPrice = 45.5m, TicketsAvailable = 1994, VenueSectorId = 2 },
                new TicketEvent { Description = "21/08/2016 - 15:00 - Men Basketball Finals Session 38", TicketPrice = 180m, TicketsAvailable = 1995, VenueSectorId = 3 },
                new TicketEvent { Description = "07/08/2016 - 09:00 - Swimming morning multisession", TicketPrice = 160m, TicketsAvailable = 1996, VenueSectorId = 7 },
                new TicketEvent { Description = "13/08/2016 - 09:00 - Swimming morning multisession", TicketPrice = 120m, TicketsAvailable = 1992, VenueSectorId = 6 },
                new TicketEvent { Description = "09/08/2016 - 10:00 - Men tennis single Final Session 22", TicketPrice = 126m, TicketsAvailable = 1993, VenueSectorId = 9 },
                new TicketEvent { Description = "06/08/2016 - 09:00 - Swimming morning multisession", TicketPrice = 120m, TicketsAvailable = 1994, VenueSectorId = 6 }
                );
            context.SaveChanges();

            context.Customers.AddOrUpdate(
                c => new {c.Login, c.Password},
                new Customer { FirstName = "Cliverson", MiddleNames = "Thomas", LastName = "Obrzut", DateOfBirth = DateTime.Parse("30/04/1982"), GenderId = 1, StreetAddress = "57, Howard Ave", Suburb = "Dee Why", City = "Sydney", State = "NSW", Country = "Australia", PostCode = "2099", Login = "cliver_82@hotmail.com", Password = "olympic1" },
                new Customer { FirstName = "Vera", MiddleNames = "Lucia", LastName = "Obrzut", DateOfBirth = DateTime.Parse("25/01/1959"), GenderId = 2, StreetAddress = "456, Alberto Panek", Suburb = "Orleans", City = "Curitiba", State = "PR", Country = "Brasil", PostCode = "81280-270", Login = "vera_obrzut@yahoo.com.br", Password = "olympic2" },
                new Customer { FirstName = "Ling", MiddleNames = "Yew", LastName = "Hang", DateOfBirth = DateTime.Parse("26/04/1979"), GenderId = 1, StreetAddress = "F-12 3A Garden Park", Suburb = "Bandar Sg Long", City = "Kajang", State = "Selangor", Country = "Malaysia", PostCode = "43000", Login = "kenling@hotmail.com", Password = "olympic3" }
                );
            context.SaveChanges();

            context.TicketOrders.AddOrUpdate(
                t => new {t.CustomerId, t.PurchaseDate},
                new TicketOrder { CustomerId = 1, PurchaseDate = DateTime.Parse("05/05/2016 19:15:23"), TotalCost = 1676.5m},
                new TicketOrder { CustomerId = 2, PurchaseDate = DateTime.Parse("08/05/2016 8:34:53"), TotalCost = 1096.5m},
                new TicketOrder { CustomerId = 3, PurchaseDate = DateTime.Parse("13/05/2016 0:11:20"), TotalCost = 882m}
                );
            context.SaveChanges();

            context.TicketOrderItems.AddOrUpdate(
                t => new {t.TicketEventId, t.TicketOrderId},
                new TicketOrderItem { TicketEventId = 1, TicketOrderId = 1, Quantity = 3, TotalLinePrice = 136.5m},
                new TicketOrderItem { TicketEventId = 2, TicketOrderId = 1, Quantity = 5, TotalLinePrice = 900m},
                new TicketOrderItem { TicketEventId = 3, TicketOrderId = 1, Quantity = 4, TotalLinePrice = 640m},
                new TicketOrderItem { TicketEventId = 4, TicketOrderId = 2, Quantity = 8, TotalLinePrice = 960m},
                new TicketOrderItem { TicketEventId = 5, TicketOrderId = 3, Quantity = 7, TotalLinePrice = 882m},
                new TicketOrderItem { TicketEventId = 2, TicketOrderId = 2, Quantity = 3, TotalLinePrice = 136.5m},
                new TicketOrderItem { TicketEventId = 6, TicketOrderId = 3, Quantity = 3, TotalLinePrice = 360m}
                );
            context.SaveChanges();
        }
    }
}
