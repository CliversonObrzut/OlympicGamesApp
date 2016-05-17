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
        public DbSet Athletes { get; set; }
        public DbSet AthleteModalities { get; set; }
        public DbSet CompetitionEvents { get; set; }
        public DbSet CompetitionEventTickets { get; set; }
        public DbSet CompetitionPhases { get; set; }
        public DbSet CompetitionSessions { get; set; }
        public DbSet Countries { get; set; }
        public DbSet Customers { get; set; }
        public DbSet FavoriteAthletes { get; set; }
        public DbSet FavoriteCountries { get; set; }
        public DbSet FavoriteModalities { get; set; }
        public DbSet FavoriteSports { get; set; }
        public DbSet Genders { get; set; }
        public DbSet Modalities { get; set; }
        public DbSet ModalityCategories { get; set; }
        public DbSet Sports { get; set; }
        public DbSet TicketEvents { get; set; }
        public DbSet TicketOrders { get; set; }
        public DbSet TicketOrderItems { get; set; }
        public DbSet Venues { get; set; }
        public DbSet VenueSectors { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AthleteMap());
            modelBuilder.Configurations.Add(new AthleteModalityMap());
            modelBuilder.Configurations.Add(new CompetitionEventMap());
            modelBuilder.Configurations.Add(new CompetitionEventTicketMap());
            modelBuilder.Configurations.Add(new CompetitionPhaseMap());
            modelBuilder.Configurations.Add(new CompetitionSessionMap());
            modelBuilder.Configurations.Add(new CountryMap());
            modelBuilder.Configurations.Add(new CustomerMap());

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}
