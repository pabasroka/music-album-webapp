namespace music_album_webapp.Models;

public class AlbumDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string Version { get; set; }
    public int ReleaseYear { get; set; }
    public string DistributionName { get; set; }
    public IEnumerable<TrackDto> Tracks { get; set; }
}