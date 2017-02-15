namespace mysqltry1
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<athathlete> athathlete { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<athathlete>()
                .Property(e => e.athAthleteName)
                .IsUnicode(false);

            modelBuilder.Entity<athathlete>()
                .Property(e => e.athAthleteAgonisma)
                .IsUnicode(false);

            modelBuilder.Entity<athathlete>()
                .Property(e => e.athAthleteAddress)
                .IsUnicode(false);

            modelBuilder.Entity<athathlete>()
                .Property(e => e.athAthleteTelephone1)
                .IsUnicode(false);

            modelBuilder.Entity<athathlete>()
                .Property(e => e.athAthleteTelephone2)
                .IsUnicode(false);

            modelBuilder.Entity<athathlete>()
                .Property(e => e.athAthleteEmail)
                .IsUnicode(false);

            modelBuilder.Entity<athathlete>()
                .Property(e => e.athAthleteTraumatismoi)
                .IsUnicode(false);
        }
    }
}
