using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace music_album_webapp.Entities.Configurations;

public class AlbumEntityTypeConfiguration : IEntityTypeConfiguration<Album>
{
    public void Configure(EntityTypeBuilder<Album> builder)
    {
        builder.ToTable("Albums");
        
        builder.Property(x => x.Title).IsRequired();
        builder.Property(x => x.Author).IsRequired();
        builder.Property(x => x.ReleaseYear).IsRequired();
    }
}