namespace music_album_webapp.Entities;

public class Distribution
{
    public int Id { get; set; }
    public string Name { get; set; }
    
    public virtual IEnumerable<Album> Albums { get; set; }
}