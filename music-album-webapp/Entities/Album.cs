namespace music_album_webapp.Entities;

public class Album
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string Version { get; set; }
    public int ReleaseYear { get; set; } 
    
    public int DistributionId { get; set; }
    public virtual Distribution Distribution { get; set; }
    
    public virtual List<Track> Tracks { get; set; }
}