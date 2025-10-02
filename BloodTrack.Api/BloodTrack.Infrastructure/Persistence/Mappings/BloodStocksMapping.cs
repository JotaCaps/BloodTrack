using BloodTrack.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BloodTrack.Infrastructure.Persistence.Mappings
{
    public class BloodStocksMapping : IEntityTypeConfiguration<BloodStock>
    {
        public void Configure(EntityTypeBuilder<BloodStock> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).ValueGeneratedOnAdd()
            .UseIdentityColumn();
            
            builder.Property(e => e.BloodType).IsRequired();
        }

    }
}
