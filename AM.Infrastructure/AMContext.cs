using AirportManagementRevision.Domain;
using AM.ApplicationCore.Domain;
using AM.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;


namespace AM.Infrastructure
{
    public class AMContext:DbContext
    {
        /*public DbSet<Compteur> Compteurs { get; set; }
        public DbSet<Abonne> Abonnes { get; set; }
        public DbSet<Facture> Factures { get; set; }
        public DbSet<Periode> Periodes { get; set; }*/
        
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Plane> Planes { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<ReservationTicket> ReservationTickets { get; set; }
        public DbSet<Traveller> Travellers { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "Server=localhost;port=3306;Database=newdbtesttt;user=root;password=;Persist security Info=true";

            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));

            base.OnConfiguring(optionsBuilder);
        }
/*
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

           
            modelBuilder.Entity<Facture>()
                .HasKey(r => new { r.CompteurKey, r.PeriodeKey, r.Date });
            
            modelBuilder.Entity<Facture>()
                .HasOne(r => r.Compteur)
                .WithMany(l => l.Factures)
                .HasForeignKey(r => r.CompteurKey);

            modelBuilder.Entity<Facture>()
                .HasOne(r => r.Periode)
                .WithMany(v => v.Factures)
                .HasForeignKey(r => r.PeriodeKey);

            modelBuilder.Entity<Compteur>()
                .HasKey(v => v.Reference);

            modelBuilder.Entity<Periode>()
                .HasKey(l => l.Id);
        }
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            base.ConfigureConventions(configurationBuilder);
          configurationBuilder.Properties<string>().HaveMaxLength(200);

        }

*/


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FlightConfiguration());
            modelBuilder.ApplyConfiguration(new PlaneConfiguration());
            //2 eme methode de fluentAPI
            // config de type C - 2 eme methode de config
            modelBuilder.Entity<Passenger>().OwnsOne(p => p.FullName, full =>
            {
                full.Property(p => p.FirstName).HasColumnName("PassFirstName").IsRequired();
                full.Property(p => p.LastName).HasColumnName("PassLastName").HasMaxLength(30);

            });
            // config de la clé primaire composée de la reservation
            modelBuilder.Entity<ReservationTicket>().HasKey(p => new
            {
                p.PassengerFk,
                p.TicketFk,
                p.DateReservation
            });          
        }





    }
    
}