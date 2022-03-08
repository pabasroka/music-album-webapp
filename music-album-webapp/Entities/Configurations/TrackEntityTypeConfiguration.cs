using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace music_album_webapp.Entities.Configurations;

public class TrackEntityTypeConfiguration : IEntityTypeConfiguration<Track>
{
    public void Configure(EntityTypeBuilder<Track> builder)
    {
        builder.ToTable("Tracks");
        
        builder.Property(x => x.Title).IsRequired();
        builder.Property(x => x.Author).IsRequired();
    }
}