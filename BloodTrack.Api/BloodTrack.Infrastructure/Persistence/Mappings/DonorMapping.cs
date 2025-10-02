using BloodTrack.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BloodTrack.Infrastructure.Persistence.Mappings
{
    public class DonorMapping : IEntityTypeConfiguration<Donor>
    {
        public void Configure(EntityTypeBuilder<Donor> builder)
        {
            
        builder.HasKey(e => e.Id);

        builder.HasMany(e => e.Donations)
            .WithOne(d => d.Donor)
            .HasForeignKey(d => d.DonorId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(e => e.Id).ValueGeneratedOnAdd()
                .UseIdentityColumn();


        builder.OwnsOne(d => d.Address, a =>
        {
            a.Property(p => p.Logradouro).HasColumnName("Address_Logradouro").IsRequired(false);
            a.Property(p => p.City).HasColumnName("Address_City").IsRequired(false);
            a.Property(p => p.State).HasColumnName("Address_State").IsRequired(false);
            a.Property(p => p.ZipCode).HasColumnName("Address_ZipCode").IsRequired(false);
        }

        );
    }
        }
    }

