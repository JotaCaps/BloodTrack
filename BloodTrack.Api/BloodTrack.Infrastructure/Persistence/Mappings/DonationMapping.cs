using BloodTrack.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodTrack.Infrastructure.Persistence.Mappings
{
    public class DonationMapping : IEntityTypeConfiguration<Donation>
    {
        public void Configure(EntityTypeBuilder<Donation> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).ValueGeneratedOnAdd()
            .UseIdentityColumn();

            builder.Property(e => e.DonationDate).IsRequired();
            builder.Property(e => e.AmountMl).IsRequired();
        }
    }
    
    }
