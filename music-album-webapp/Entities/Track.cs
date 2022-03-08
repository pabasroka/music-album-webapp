namespace music_album_webapp.Entities;

public class Track
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public int ReleaseYear { get; set; }
    public int Duration { get; set; } // seconds
    public int AlbumId { get; set; }
    public virtual Album Album { get; set; }
}