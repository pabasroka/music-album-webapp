using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace music_album_webapp.Entities.Configurations;

public class DistributionEntityTypeConfiguration : IEntityTypeConfiguration<Distribution>
{
    public void Configure(EntityTypeBuilder<Distribution> builder)
    {
        builder.ToTable("Distributions");
        builder.Property(x => x.Name).IsRequired();
    }
}