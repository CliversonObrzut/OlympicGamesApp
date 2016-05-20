using OlympicGamesApp.DataAccess.Models.Mapping;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlympicGamesApp.DataAccess.Models
{
    class OlympicDbContext : DbContext
    {
        public DbSet<Athlete> Athletes { get; set; }
        public DbSet<CompetitionEvent> CompetitionEvents { get; set; }
        public DbSet<CompetitionPhase> CompetitionPhases { get; set; }
        public DbSet<CompetitionSession> CompetitionSessions { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Modality> Modalities { get; set; }
        public DbSet<ModalityCategory> ModalityCategories { get; set; }
        public DbSet<Sport> Sports { get; set; }
        public DbSet<TicketEvent> TicketEvents { get; set; }
        public DbSet<TicketOrder> TicketOrders { get; set; }
        public DbSet<TicketOrderItem> TicketOrderItems { get; set; }
        public DbSet<Venue> Venues { get; set; }
        public DbSet<VenueSector> VenueSectors { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AthleteMap());
            modelBuilder.Configurations.Add(new CompetitionEventMap());
            modelBuilder.Configurations.Add(new CompetitionPhaseMap());
            modelBuilder.Configurations.Add(new CompetitionSessionMap());
            modelBuilder.Configurations.Add(new CountryMap());
            modelBuilder.Configurations.Add(new CustomerMap());
            modelBuilder.Configurations.Add(new GenderMap());
            modelBuilder.Configurations.Add(new ModalityMap());
            modelBuilder.Configurations.Add(new ModalityCategoryMap());
            modelBuilder.Configurations.Add(new SportMap());
            modelBuilder.Configurations.Add(new TicketEventMap());
            modelBuilder.Configurations.Add(new TicketOrderMap());
            modelBuilder.Configurations.Add(new TicketOrderItemMap());
            modelBuilder.Configurations.Add(new VenueMap());
            modelBuilder.Configurations.Add(new VenueSectorMap());

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}
