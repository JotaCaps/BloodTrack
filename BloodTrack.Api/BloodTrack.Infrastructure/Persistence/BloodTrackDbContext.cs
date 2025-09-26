using BloodTrack.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace BloodTrack.Infrastructure.Persistence
{
    public class BloodTrackDbContext : DbContext
    {
        public BloodTrackDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Donor> Donors { get; set; }
        public DbSet<Donation> Donations { get; set; }
        public DbSet<BloodStock> BloodStocks { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.
                Entity<Donor>(e =>
                {
                    e.HasKey(e => e.Id);

                    e.HasMany(e => e.Donations)
                        .WithOne(d => d.Donor)
                        .HasForeignKey(d => d.DonorId)
                        .OnDelete(DeleteBehavior.Restrict);


                    e.OwnsOne(d => d.Address, a =>
                        {
                            a.Property(p => p.Logradouro).HasColumnName("Address_Logradouro").IsRequired(false);
                            a.Property(p => p.City).HasColumnName("Address_City").IsRequired(false);
                            a.Property(p => p.State).HasColumnName("Address_State").IsRequired(false);
                            a.Property(p => p.ZipCode).HasColumnName("Address_ZipCode").IsRequired(false);
                        }
                      
                    );
                });


            builder.
                Entity<Donation>(e =>
                {
                    e.HasKey(e => e.Id);

                    e.Property(e => e.Id).ValueGeneratedOnAdd();

                });

            builder.
                Entity<BloodStock>(e =>
                {
                    e.HasKey(e => e.Id);
                }); 
            
            
            
            base.OnModelCreating(builder);
        }
    }
}
